<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_Property_Contact.aspx.cs"
    Inherits="SONIC_Exposures_AuditPopup_Property_Contact" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: Property_Contact Audit Trail</title>
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
                        <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                    align="left">
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px">Audit_DateTime</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">PK_Property_Contact_ID</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">FK_Building_ID</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Type</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Phone</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Cell_Phone</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 190px;">After_Hours_Contact_Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 190px;">After_Hours_Contact_Phone</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 220px;">After_Hours_Contact_Cell_Phone</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Organization</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">email</span>
                                    </th>                                    
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Fire Alarm Monitoring Company Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Fire Alarm Monitoring Contact Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Fire Alarm Monitoring Address</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Fire Alarm Monitoring City</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Fire Alarm Monitoring State</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Fire Alarm Monitoring Zip Code</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Fire Alarm MonitoringTelephone</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Fire Alarm Monitoring Account Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Fire Alarm Monitoring Monthly Amount</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Fire Alarm Monitoring Control Panel</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px">Updated_By</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 117px">Updated_Date</span>
                                    </th>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="overflow: scroll; width: 600px; height: 425px;" id="dvGrid" runat="server">
                        <asp:GridView ID="gvAdditionalIsured" runat="server" AutoGenerateColumns="False"
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
                                <asp:TemplateField HeaderText="PK_Property_Contact_ID">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblPK_Property_Contact_ID" runat="server" Text='<%# Eval("PK_Property_Contact_ID")%>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_Building_ID">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFK_Building_ID" runat="server" Text='<%#Eval("Building_Number")%>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Type">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblType" runat="server" Text='<%#Eval("Type")%>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name")%>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Phone">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblPhone" runat="server" Text='<%#Eval("Phone")%>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cell_Phone">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCell_Phone" runat="server" Text='<%#Eval("Cell_Phone")%>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="After_Hours_Contact_Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAfter_Hours_Contact_Name" runat="server" Text='<%#Eval("After_Hours_Contact_Name")%>'
                                            Width="190px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="After_Hours_Contact_Phone">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAfter_Hours_Contact_Phone" runat="server" Text='<%#Eval("After_Hours_Contact_Phone")%>'
                                            Width="190px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="After_Hours_Contact_Cell_Phone">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAfter_Hours_Contact_Cell_Phone" runat="server" Text='<%#Eval("After_Hours_Contact_Cell_Phone")%>'
                                            Width="220px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Organization">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOrganization" runat="server" Text='<%#Eval("Organization")%>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="email">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblemail" runat="server" Text='<%#Eval("email")%>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fire_Alarm_Monitoring_Company_Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFire_Alarm_Monitoring_Company_Name" runat="server" Text='<%#Eval("Fire_Alarm_Monitoring_Company_Name")%>' Width="150px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fire_Alarm_Monitoring_Contact_Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFire_Alarm_Monitoring_Contact_Name" runat="server" Text='<%#Eval("Fire_Alarm_Monitoring_Contact_Name")%>' Width="150px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fire_Alarm_Monitoring_Address">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFire_Alarm_Monitoring_Address" runat="server" Text='<%#Eval("Fire_Alarm_Monitoring_Address")%>' Width="150px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fire_Alarm_Monitoring_City">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFire_Alarm_Monitoring_City" runat="server" Text='<%#Eval("Fire_Alarm_Monitoring_City")%>' Width="150px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_Fire_Alarm_Monitoring_State">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFK_Fire_Alarm_Monitoring_State" runat="server" Text='<%#Eval("FK_Fire_Alarm_Monitoring_State")%>' Width="150px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fire_Alarm_Monitoring_Zip_Code">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFire_Alarm_Monitoring_Zip_Code" runat="server" Text='<%#Eval("Fire_Alarm_Monitoring_Zip_Code")%>' Width="150px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fire_Alarm_Monitoring_Telephone">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFire_Alarm_Monitoring_Telephone" runat="server" Text='<%#Eval("Fire_Alarm_Monitoring_Telephone")%>' Width="150px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Fire_Alarm_Monitoring_Account_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFire_Alarm_Monitoring_Account_Number" runat="server" Text='<%#Eval("Fire_Alarm_Monitoring_Account_Number")%>' Width="150px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Fire_Alarm_Monitoring_Monthly_Amount">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFire_Alarm_Monitoring_Monthly_Amount" runat="server" Text='<%#Eval("Fire_Alarm_Monitoring_Monthly_Amount")%>' Width="150px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Fire_Alarm_Monitoring_Control_Panel">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFire_Alarm_Monitoring_Control_Panel" runat="server" Text='<%#Eval("Fire_Alarm_Monitoring_Control_Panel")%>' Width="150px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Updated_By">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="User_Name" runat="server" Text='<%# Eval("User_Name") %>' Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Updated_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Update_Date" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Updated_Date"))) %>'
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
