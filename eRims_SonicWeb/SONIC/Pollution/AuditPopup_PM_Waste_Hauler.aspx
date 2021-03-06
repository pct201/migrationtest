﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_PM_Waste_Hauler.aspx.cs"
    Inherits="SONIC_Pollution_AuditPopup_PM_Waste_Hauler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: PM Waste Hauler Audit Trail</title>
</head>
<script language="javascript" type="text/javascript">
    function showAudit(divHeader, divGrid) {
        var divheight, i;

        divHeader.style.width = window.screen.availWidth - 520;
        divGrid.style.width = window.screen.availWidth - 520;

        divheight = divGrid.style.height;
        i = divheight.indexOf('px');

        if (i > -1)
            divheight = divheight.substring(0, i);
        if (divheight > (window.screen.availHeight - 400) && divGrid.style.height != "") {
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
                <div style="overflow: hidden; width: 300px;" id="divPM_Waste_Hauler_Header" runat="server">
                    <table cellpadding="4" cellspacing="0" style="width: 300px; border-collapse: collapse;">
                        <tbody>
                            <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                align="left">
                                <th class="cols" align="left" >
                                    <span style="display: inline-block; width: 110px;">Audit DateTime</span>
                                </th>                              
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Waste Hauler Name</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 200px;">Address 1</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 200px;">Address 2</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">City</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">State</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 100px;">Zip Code</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Contact Name</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Contact Telephone</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">EPA ID Number</span>
                                </th>
                                 <th class="cols" align="left">
                                    <span style="display: inline-block; width: 120px;">Updated By</span>
                                </th>
                                 <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Annual State Waste Hauler Registration on File?</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Certificate of Insurance on File Containing Adequate Amount of Pollution Coverage?</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 117px;">Update Date</span>
                                </th>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div style="overflow: scroll; width: 300px; height: 380px;" id="divPM_Waste_Hauler_Grid"
                    runat="server">
                    <asp:GridView ID="gvWasteHauler" runat="server" AutoGenerateColumns="False"
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
                           
                            <asp:TemplateField HeaderText="Waste_Hauler_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblWaste_Hauler_Name" runat="server" Text='<%#Eval("Waste_Hauler_Name")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address_1">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAddress_1" runat="server" Text='<%#Eval("Address_1")%>' Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address_2">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAddress_2" runat="server" Text='<%#Eval("Address_2")%>' Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="City">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCity" runat="server" Text='<%#Eval("City")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_State">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_State" runat="server" Text='<%#Eval("FK_State")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Zip_Code">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblZip_Code" runat="server" Text='<%#Eval("Zip_Code")%>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblContact_Name" runat="server" Text='<%#Eval("Contact_Name")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact_Telephone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblContact_Telephone" runat="server" Text='<%#Eval("Contact_Telephone")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="EPA_ID_Number">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblEPA_ID_Number" runat="server" Text='<%#Eval("EPA_ID_Number")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Updated_By">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdated_By" runat="server" Text='<%#Eval("Updated_By")%>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="State_Registration">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblState_Registration" runat="server" Text='<%#Eval("State_Registration")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Certification_On_File">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCertification_On_File" runat="server" Text='<%#Eval("Certification_On_File")%>' Width="150px"></asp:Label>
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
