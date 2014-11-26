<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_ServiceContract.aspx.cs"
    Inherits="SONIC_Purchasing_AuditPopup_ServiceContract" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: Purchasing_Service_Contract Audit Trail</title>
</head>

<script language="javascript" type="text/javascript">
    function showAudit(divHeader,divGrid)
    {        
        var divheight,i;
       
        divHeader.style.width = window.screen.availWidth - 225 + "px";
        divGrid.style.width = window.screen.availWidth - 225 + "px";
        
        divheight = divGrid.style.height;        
        i = divheight.indexOf('px');        
        
        if(i > -1)        
            divheight = divheight.substring(0,i);
        if (divheight > (window.screen.availHeight - 350) && divGrid.style.height != "")
        {            
            divGrid.style.height = window.screen.availHeight - 350;
        }
    }
    
    function ChangeScrollBar(f,s)
    {
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
                    <div style="overflow: hidden; width: 600px;" id="divPurchasing_Service_Contract_Header"
                        runat="server">
                        <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                    align="left">
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px;">Audit_DateTime</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 300px;">PK_Purchasing_Service_Contract</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 250px;">Supplier</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 250px;">Service Type</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Start Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 80px;">End Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px;">Term In Months</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 170px;">Service Frequency</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px;">Monthly Cost</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px;">Annual Cost</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Contract Level</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px;">Total Committed</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px;">Legal Confidential</span>
                                    </th>
                                     <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Customer/Contract Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Auto Renew Options</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Auto Renew Other</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Notification Method</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 170px;">Notification Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">Contract Notes</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px;">Renewal_Terms</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">Notification_Terms</span>
                                    </th>
                                     <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Is COI Needed?</span>
                                    </th>
                                  <%--  <th class="cols">
                                        <span style="display: inline-block; width: 180px;">Applicable Dealers</span>
                                    </th> --%>                                   
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Updated_By</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 167px;">Update_Date</span>
                                    </th>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="overflow: scroll; width: 600px; height: 425px;" id="divPurchasing_Service_Contract_Grid"
                        runat="server">
                        <asp:GridView ID="gvPurchasing_Service_Contract" runat="server" AutoGenerateColumns="False"
                            CellPadding="4" EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
                            <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <Columns>
                                <asp:TemplateField HeaderText="Audit_DateTime" SortExpression="Audit_DateTime">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            ToolTip='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            Width="110px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PK_Purchasing_Service_Contract" SortExpression="PK_Purchasing_Service_Contract">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblPK_Purchasing_Service_Contract" runat="server" Text='<%#Eval("PK_Purchasing_Service_Contract")%>'
                                            Width="300px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Supplier" SortExpression="Supplier">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSupplier" runat="server" Text='<%#Eval("Supplier")%>' Width="250px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Service_Type" SortExpression="Service_Type">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblService_Type" runat="server" Text='<%#Eval("Service_Type")%>' Width="250px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Start_Date" SortExpression="Start_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblStart_Date" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Start_Date"))) ? Convert.ToDateTime(Eval("Start_Date")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="End_Date" SortExpression="End_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblEnd_Date" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("End_Date"))) ? Convert.ToDateTime(Eval("End_Date")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)%>'
                                            Width="80px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Term_In_Months" SortExpression="Term_In_Months">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblTerm_In_Months" runat="server" Text='<%#Eval("Term_In_Months")%>'
                                            Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Service_Frequency" SortExpression="Service_Frequency">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblService_Frequency" runat="server" Text='<%#Eval("Service_Frequency")%>'
                                            Width="170px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Monthly_Cost" SortExpression="Monthly_Cost">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblMonthly_Cost" runat="server" Text='<%#Eval("Monthly_Cost")%>' Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Annual_Cost" SortExpression="Annual_Cost">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAnnual_Cost" runat="server" Text='<%#Eval("Annual_Cost")%>' Width="110px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_LU_Service_Contract" SortExpression="FK_LU_Service_Contract">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFK_LU_Service_Contract" runat="server" Text='<%#Eval("FK_LU_Service_Contract")%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total_Committed" SortExpression="Total_Committed">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotal_Committed" runat="server" Text='<%#Eval("Total_Committed")%>'
                                            Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Legal_Confidential" SortExpression="Legal_Confidential">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblLegal_Confidential" runat="server" Text='<%# (Eval("Legal_Confidential").ToString() == "Y") ? "Yes" : "No"%>'
                                            Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Customer_Contract_Number" SortExpression="Customer_Contract_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustomer_Contract_Number" runat="server" Text='<%#Eval("Customer_Contract_Number")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_LU_Auto_Renew" SortExpression="FK_LU_Auto_Renew">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFK_LU_Auto_Renew" runat="server" Text='<%#Eval("FK_LU_Auto_Renew")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                                <asp:TemplateField HeaderText="Auto_Renew_Other" SortExpression="Auto_Renew_Other">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAuto_Renew_Other" runat="server" Text='<%#Eval("Auto_Renew_Other")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Notification_Method" SortExpression="Notification_Method">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblNotification_Method" runat="server" Text='<%#Eval("Notification_Method")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Notification_Date" SortExpression="Notification_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblNotification_Date" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Notification_Date"))) ? Convert.ToDateTime(Eval("Notification_Date")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)%>'
                                            Width="170px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Notification_Content" SortExpression="Notification_Content">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblNotification_Content" runat="server" Text='<%#Eval("Notification_Content")%>'
                                            Width="200px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Renewal_Terms" SortExpression="Renewal_Terms">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRenewal_Terms" runat="server" Text='<%#Eval("Renewal_Terms")%>'
                                            Width="130px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Notification_Terms" SortExpression="Notification_Terms">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblNotification_Terms" runat="server" Text='<%#Eval("Notification_Terms")%>'
                                            Width="180px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="COI_Needed" SortExpression="COI_Needed">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCOI_Needed" runat="server" Text='<%#Eval("COI_Needed")%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <%-- <asp:TemplateField HeaderText="Applicable_Dealers" SortExpression="Applicable_Dealers">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblApplicable_Dealers" runat="server" Text='<%#Eval("Applicable_Dealers")%>'
                                            Width="180px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>  --%>                             
                                <asp:TemplateField HeaderText="Updated_By" SortExpression="Updated_By">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="User_Name" runat="server" Text='<%# Bind("Updated_By") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Update_Date" SortExpression="Update_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Update_Date" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Update_Date"))) ? Convert.ToDateTime(Eval("Update_Date")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
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
