<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_CRM_Customer.aspx.cs"
    Inherits="SONIC_CRM_AuditPopup_CRM_Customer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: CRM Customer Audit Trail</title>
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
                <div style="overflow: hidden; width: 600px;" id="divNonCustomer_Header" runat="server">
                    <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;">
                        <tbody>
                            <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                align="left">
                                <th class="cols">
                                    <span style="display: inline-block; width: 120px;">Audit_DateTime</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 120px;">Complaint Number</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 120px;">Date of Incident </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Source</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 120px;">Last Name</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 120px;">First Name</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Address</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">City</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">State</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Zip </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Email</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 140px;">Home Telephone </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 140px;">Cell Telephone </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 140px;">Work Telephone </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 165px;">Work Telephone Extension </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Summary </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Department </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Department Detail </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 120px;">Date of Service</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 140px;">Date of Service Estimated? </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 120px;">Dealer </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 120px;">Brand </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Model </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Year </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">CRM Contacted </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Resolution Manager </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 160px;">Resolution Manager Name </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 160px;">Resolution Manager Email </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 140px;">Customer Contacted GM? </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Date of Contact GM </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">GM Name </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Date of Contact RVP </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">RVP Name </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Date of Contact DFOD</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">DFOD </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 160px;">Other Contact Name </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Legal/Attorney General?</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Legal Email </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Demand Letter? </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Date of Last Update</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 160px;">Last Action </span>
                                </th>   
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Field Resolution Information  </span>
                                </th>                                
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Resolution Summary</span>
                                </th>                               
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Complete? </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Close Date </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Days to Close</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Customer Call Back After Resolved? </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 140px;">Resolution Letter to Customer? </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 140px;">Date Resolution Letter Sent </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 140px;">Sent By </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Letter N/A? </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Letter N/A Reason </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Letter N/A Note </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Updated_By</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 167px;">Updated_Date</span>
                                </th>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div style="overflow: scroll; width: 600px; height: 500px;" id="divNonCustomer_Grid"
                    runat="server">
                    <asp:GridView ID="gvNonCustomer" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
                        <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <Columns>
                            <asp:TemplateField HeaderText="Audit_DateTime" SortExpression="Audit_DateTime">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                        ToolTip='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                        Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                          
                            <asp:TemplateField HeaderText="Complaint Number">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPK_CRM_Non_Customer" runat="server" Text='<%#Eval("PK_CRM_Customer")%>'
                                        Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date of Contact">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRecord_Date" runat="server" Text='<%#Eval("Record_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Record_Date"))) : ""%>'
                                        Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Source">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_CRM_Source" runat="server" Text='<%#Eval("FK_LU_CRM_Source")%>'
                                        Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Last Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLast_Name" runat="server" Text='<%#Eval("Last_Name")%>'
                                        Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="First Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFirst_Name" runat="server" Text='<%#Eval("First_Name")%>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address")%>' Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="City">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCity" runat="server" Text='<%#Eval("City")%>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="State">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_State" runat="server" Text='<%#Eval("FK_State")%>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Zip (XXXXX-XXXX) ">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblZip_Code" runat="server" Text='<%#Eval("Zip_Code")%>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email")%>' Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Home_Telephone ">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblHome_Telephone" runat="server" Text='<%#Eval("Home_Telephone")%>' Width="140px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cell_Telephone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCell_Telephone" runat="server" Text='<%#Eval("Cell_Telephone")%>'
                                        Width="140px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Work_Telephone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblWork_Telephone" runat="server" Text='<%#Eval("Work_Telephone")%>'
                                        Width="140px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Work_Telephone_Extension">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblWork_Telephone_Extension" runat="server" Text='<%#Eval("Work_Telephone_Extension")%>'
                                        Width="165px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Summary">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSummary" runat="server" Text='<%#Eval("Summary")%>'
                                        Width="300px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_LU_CRM_Department">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_CRM_Department" runat="server" Text='<%#Eval("FK_LU_CRM_Department")%>'
                                        Width="130px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_LU_CRM_Dept_Desc_Detail">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_CRM_Dept_Desc_Detail" runat="server" Text='<%#Eval("FK_LU_CRM_Dept_Desc_Detail")%>'
                                        Width="130px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Service_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblService_Date" runat="server" Text='<%#Eval("Service_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Service_Date"))) : ""%>'
                                        Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Service_Date_Est">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblService_Date_Est" runat="server" Text='<%#(Eval("Service_Date_Est").ToString() == "Y" ? "Yes" : "No") %>'
                                        Width="140px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_LU_Location">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_Locationt" runat="server" Text='<%#Eval("FK_LU_Location")%>'
                                        Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_LU_CRM_Brand">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_CRM_Brand" runat="server" Text='<%#Eval("FK_LU_CRM_Brand")%>'
                                        Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Model">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblModel" runat="server" Text='<%#Eval("Model")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Year">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblYear" runat="server" Text='<%#Eval("Year")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="FK_LU_CRM_Contacted_Resolution_2">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_CRM_Contacted_Resolution_2" runat="server" Text='<%#Eval("FK_LU_CRM_Contacted_Resolution_2")%>'
                                        Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="FK_LU_CRM_Contacted_Resolution_1">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_CRM_Contacted_Resolution_1" runat="server" Text='<%#Eval("FK_LU_CRM_Contacted_Resolution_1")%>'
                                        Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Resolution_Manager">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblResolution_Manager" runat="server" Text='<%#Eval("Resolution_Manager")%>'
                                        Width="160px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Resolution_Manager_Email">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblResolution_Manager_Email" runat="server" Text='<%#Eval("Resolution_Manager_Email")%>'
                                        Width="160px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Customer_Contacted_GM">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCustomer_Contacted_GM" runat="server" Text='<%#(Eval("Customer_Contacted_GM").ToString() == "Y" ? "Yes" : "No") %>'
                                        Width="140px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="GM_Contact_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblGM_Contact_Date" runat="server" Text='<%#Eval("GM_Contact_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("GM_Contact_Date"))) : ""%>'
                                        Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="GM_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblGM_Name" runat="server" Text='<%#Eval("GM_Name")%>'
                                        Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="RVP_Contact_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>                                    
                                         <asp:Label ID="lblRVP_Contact_Date" runat="server" Text='<%#Eval("RVP_Contact_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("RVP_Contact_Date"))) : ""%>'
                                        Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="FK_LU_CRM_RVP">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_CRM_RVP" runat="server" Text='<%#Eval("FK_LU_CRM_RVP")%>'
                                        Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="DFOD_Contact_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                     <asp:Label ID="lblDFOD_Contact_Date" runat="server" Text='<%#Eval("DFOD_Contact_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("DFOD_Contact_Date"))) : ""%>'
                                        Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="FK_LU_CRM_DFOD">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_CRM_DFOD" runat="server" Text='<%#Eval("FK_LU_CRM_DFOD")%>'
                                        Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Other_Cotnact_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblOther_Cotnact_Name" runat="server" Text='<%#Eval("Other_Cotnact_Name")%>'
                                        Width="160px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Legal_Attorney_General">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLegal_Attorney_General" runat="server" Text='<%#(Eval("Legal_Attorney_General").ToString() == "Y" ? "Yes" : "No") %>'
                                        Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="FK_LU_CRM_Legal_Email">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lbFK_LU_CRM_Legal_Email" runat="server" Text='<%#Eval("FK_LU_CRM_Legal_Email")%>'
                                        Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Demand_Letter">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDemand_Letter" runat="server" Text='<%#(Eval("Demand_Letter").ToString() == "Y" ? "Yes" : "No") %>'
                                        Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="User_Update_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate> 
                                    <asp:Label ID="lblDateOfLastUpdate" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("User_Update_Date")) %>'
                                        Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Last_Action">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLast_Action" runat="server" Text='<%#Eval("Last_Action")%>'
                                        Width="160px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>    
                             <asp:TemplateField HeaderText="Field_Resolution_Information">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblField_Resolution_Information" runat="server" Text='<%#Eval("Field_Resolution_Information")%>'
                                        Width="300px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                          
                              <asp:TemplateField HeaderText="Resolution_Summary">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lbResolution_Summary" runat="server" Text='<%#Eval("Resolution_Summary")%>'
                                        Width="300px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Complete">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblComplete" runat="server" Text='<%#(Eval("Complete").ToString() == "Y" ? "Yes" : "No") %>'
                                        Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Close_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                     <asp:Label ID="lblClose_Date" runat="server" Text='<%#Eval("Close_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Close_Date"))) : ""%>'
                                        Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Days_To_Close">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDays_To_Close" runat="server" Text='<%#Eval("Days_To_Close")%>'
                                        Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Customer_Callback_After_Resolution">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCustomer_Callback_After_Resolution" runat="server" Text='<%#(Eval("Customer_Callback_After_Resolution").ToString() == "Y" ? "Yes" : "No") %>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Resolution_Letter_To_Customer">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblResolution_Letter_To_Customer" runat="server" Text='<%#(Eval("Resolution_Letter_To_Customer").ToString() == "Y" ? "Yes" : "No") %>'
                                        Width="140px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Date_Resolution_Letter_Sent">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                     <asp:Label ID="lblDate_Resolution_Letter_Sent" runat="server" Text='<%#Eval("Date_Resolution_Letter_Sent") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Resolution_Letter_Sent"))) : ""%>'
                                        Width="140px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="FK_LU_CRM_Response_Method">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_CRM_Response_Method" runat="server" Text='<%#Eval("FK_LU_CRM_Response_Method")%>'
                                        Width="140px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Letter_NA">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLetter_NA" runat="server" Text='<%#(Eval("Letter_NA").ToString() == "Y" ? "Yes" : "No") %>' 
                                        Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="FK_LU_CRM_Letter_NA_Reason">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_CRM_Letter_NA_Reason" runat="server" Text='<%#Eval("FK_LU_CRM_Letter_NA_Reason")%>'
                                        Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Letter_NA_Note">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLetter_NA_Note" runat="server" Text='<%#Eval("Letter_NA_Note")%>'
                                        Width="300px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Updated_By">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdated_By" runat="server" Text='<%#Eval("Updated_By")%>' Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Update_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Update_Date" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Update_Date"))) ? Convert.ToDateTime(Eval("Update_Date")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                        Width="120px"></asp:Label>
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
