﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_PM_Phase_I.aspx.cs"
    Inherits="SONIC_Pollution_AuditPopup_PM_Phase_I" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: PM Phase I Audit Trail</title>
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
                <div style="overflow: hidden; width: 300px;" id="divPM_Phase_Header" runat="server">
                    <table cellpadding="4" cellspacing="0" style="width: 300px; border-collapse: collapse;">
                        <tbody>
                            <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                align="left">
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 110px;">Audit DateTime</span>
                                </th>
                                <%--<th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">PK_PM_Phase_I</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 160px;">FK_PM_Site_Information</span>
                                </th>--%>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Assessor</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Contact Name</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Contact Telephone</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 120px;">Report Date</span>
                                </th>
                                <th class="cols" align="right">
                                    <span style="display: inline-block; width: 120px;">Cost</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Next Review Date</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Next Report Date</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 200px;">Phase II Recommendations</span>
                                </th>
                                 <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Was Phase II Recommended?</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 200px;">Notes</span>
                                </th>
                                
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 120px;">Updated By</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 117px;">Update Date</span>
                                </th>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div style="overflow: scroll; width: 300px; height: 400px;" id="divPM_Phase_Grid"
                    runat="server">
                    <asp:GridView ID="gvPMPhaseI" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
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
                            <%--<asp:TemplateField HeaderText="PK_PM_Phase_I">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPK_PM_Phase_I" runat="server" Text='<%#Eval("PK_PM_Phase_I")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_PM_Site_Information">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_PM_Site_Information" runat="server" Text='<%#Eval("FK_PM_Site_Information")%>'
                                        Width="160px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Assessor">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAssessor" runat="server" Text='<%#Eval("Assessor")%>' Width="150px"></asp:Label>
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
                            <asp:TemplateField HeaderText="Report_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblReport_Date" runat="server" Text='<%#Eval("Report_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Report_Date"))) : ""%>'
                                        Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cost" ItemStyle-HorizontalAlign="Right">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCost" runat="server" Text='<%#string.Format("{0:C2}",Eval("Cost"))%>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Next_Review_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblNext_Review_Date" runat="server" Text='<%#Eval("Next_Review_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Next_Review_Date"))) : ""%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Next_Report_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblNext_Report_Date" runat="server" Text='<%#Eval("Next_Report_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Next_Report_Date"))) : ""%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Recommendations">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRecommendations" runat="server" Text='<%#Eval("Recommendations")%>'
                                        Width="200px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="PhaseII_Recommended">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPhaseII_Recommended" runat="server" Text='<%#Eval("PhaseII_Recommended")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Notes">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblNotes" runat="server" Text='<%#Eval("Notes")%>' Width="200px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Updated_By">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdated_By" runat="server" Text='<%#Eval("Updated_By")%>' Width="120px"></asp:Label>
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
