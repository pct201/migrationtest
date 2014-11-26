<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_BuildingOwnership_Sublease.aspx.cs"
    Inherits="SONIC_Exposures_AuditPopup_BuildingOwnership_Sublease" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: Building_Ownership_Sublease Audit Trail</title>
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
                                    <span style="display: inline-block; width: 230px;">PK_Building_Ownership_Sublease</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">FK_Building_Ownership</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Sublease Name</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Address 1</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Address 2</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">City</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">State</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Zip</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">SubLease Landlord</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Sublease FirstName</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Sublease LastName</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Sublease Title</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Phone</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Fax</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Email</span>
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
                    <asp:GridView ID="gvBuildingOwnership_Sublease" runat="server" AutoGenerateColumns="False"
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
                            <asp:TemplateField HeaderText="PK_Building_Ownership_Sublease_ID">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPK_Building_Ownership_Sublease_ID" runat="server" Text='<%#Eval("PK_Building_Ownership_Sublease")%>'
                                        Width="230px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_Building_Ownership_ID">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_Building_Ownership_ID" runat="server" Text='<%# Eval("FK_Building_Ownership")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sublease_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSublease_Name" runat="server" Text='<%#Eval("Sublease_Name")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address 1">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSublease_Address_1" runat="server" Text='<%#Eval("Sublease_Address_1")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address 2">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSublease_Address_2" runat="server" Text='<%#Eval("Sublease_Address_2")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="City">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSublease_City" runat="server" Text='<%#Eval("Sublease_City")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="State">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSublease_State" runat="server" Text='<%#Eval("Sublease_State")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Zip">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSublease_Zip" runat="server" Text='<%#Eval("Sublease_Zip")%>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SubLease Landlord">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSubLease_Landlord" runat="server" Text='<%#Eval("SubLease_Landlord")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sublease FirstName">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSublease_FirstName" runat="server" Text='<%#Eval("Sublease_FirstName")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sublease LastName">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSublease_LastName" runat="server" Text='<%#Eval("Sublease_LastName")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Title">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSublease_Title" runat="server" Text='<%#Eval("Sublease_Title")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Phone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSublease_Phone" runat="server" Text='<%#Eval("Sublease_Phone")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fax">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSublease_Fax" runat="server" Text='<%#Eval("Sublease_Fax")%>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSublease_Fax" runat="server" Text='<%#Eval("Sublease_Email")%>' Width="100px"></asp:Label>
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
