<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_Project_Management.aspx.cs"
    Inherits="SONIC_Exposures_AuditPopup_Project_Management" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: Project Management Audit Trail</title>
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
                <div style="overflow: hidden; width: 650px;" id="dvHeader" runat="server">
                    <table cellpadding="4" cellspacing="0" style="width: 1547px; border-collapse: collapse;">
                        <tbody>
                            <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                align="left">
                                <th class="cols">
                                    <span style="display: inline-block; width: 110px">Audit DateTime</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px">Companion to Project</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px">Project Number</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px">Project Type</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px">Project Description</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px">Requesting Entity</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 250px">Person Requesting Work</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 250px">Title of Person Requesting Work</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 250px">Other Requesting Entity Description</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 120px">Updated By</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 117px">Updated Date</span>
                                </th>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div style="overflow: scroll; width: 1547px; height: 400px;" id="dvGrid" runat="server">
                    <asp:GridView ID="gvProjectManagement" runat="server" AutoGenerateColumns="False"
                        CellPadding="4" EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
                        <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <Columns>
                            <asp:TemplateField HeaderText="Audit_DateTime">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                        ToolTip='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                        Width="110px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Companion_to_Project">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCompanion_to_Project" runat="server" Text='<%# Eval("Companion_to_Project") %>'
                                        Width="200px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Project_Number">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblProject_Number" runat="server" Text='<%# Eval("Project_Number") %>'
                                        Width="200px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Project_Type">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblProject_Type" runat="server" Text='<%# Eval("Project_Type") %>'
                                        Width="150px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Project_Description">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblProject_Description" runat="server" Text='<%# Eval("Project_Description") %>'
                                        Width="200px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Requesting_Entity">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRequesting_Entity" runat="server" Text='<%# Eval("Requesting_Entity") %>'
                                        Width="200px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Person_Requesting_Work ">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPerson_Requesting_Work" runat="server" Text='<%# Eval("Person_Requesting_Work") %>'
                                        Width="250px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Title_of_Person_Requesting_Work">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblTitle_of_Person_Requesting_Work" runat="server" Text='<%# Eval("Title_of_Person_Requesting_Work") %>'
                                        Width="250px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Requesting_Entity_Description">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRequesting_Entity_Description" runat="server" Text='<%# Eval("Requesting_Entity_Description") %>'
                                        Width="250px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Updated_By">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="User_Name" runat="server" Text='<%# Eval("Updated_By") %>' Width="120px"
                                        CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Updated_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Update_Date" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Update_Date"))) %>'
                                        Width="100px" CssClass="TextClip"></asp:Label>
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
