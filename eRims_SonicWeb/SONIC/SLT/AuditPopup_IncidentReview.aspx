<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_IncidentReview.aspx.cs" Inherits="SONIC_SLT_AuditPopup_IncidentReview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: Incident Review Audit Trail</title>
</head>
<script language="javascript" type="text/javascript">
    function showAudit(divHeader, divGrid) {
        var divheight, i;

        divHeader.style.width = window.screen.availWidth - 419 + "px"; 
        divGrid.style.width = window.screen.availWidth - 419 + "px"; 

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
                <div style="overflow: hidden; width: 675px;" id="divIncidentReviewHeader" runat="server">
                    <table cellpadding="4" cellspacing="0" style="width: 625px; border-collapse: collapse;">
                        <tbody>
                            <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                align="left">
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Audit DateTime</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px;">PK_SLT_Incident_Review</span>
                                </th>
                                <%--<th class="cols">
                                    <span style="display: inline-block; width: 100px;">FK_SLT_Meeting</span>
                                </th>--%><%--
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">FK_WC_FR_ID</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">FK_Investigation_ID</span>
                                </th>--%>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Incident Type</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Root Cause</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Conclusions</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Confirmation Assigned To</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Target Comp Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Status Due On</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Comments</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Item Status</span>
                                </th><%--
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">FK_AL_FR_ID</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">FK_PL_FR_ID</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">FK_DPD_FR_ID</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">FK_Property_FR_ID</span>
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
                <div style="overflow: scroll; width: 625px; height: 425px;" id="divIncidentReview_Grid"
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
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PK_SLT_Incident_Review">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPK_SLT_Incident_Review" runat="server" Text='<%#Eval("PK_SLT_Incident_Review")%>'
                                        Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Incident Type">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_Incident_Type" runat="server" Text='<%#Eval("FK_LU_Incident_Type")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Root Cause">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRoot_Cause" runat="server" Text='<%#Eval("Root_Cause")%>' Width="300px"
                                        CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Conclusions">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblConclusions" runat="server" Text='<%#Eval("Conclusions")%>' Width="300px"
                                        CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Confirmation Assigned To">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblConfirmation_Assigned_To" runat="server" Text='<%#Eval("Confirmation_Assigned_To")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Target Comp Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblTarget_Comp_Date" runat="server" Text='<%#Eval("Target_Comp_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Target_Comp_Date"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status Due On">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus_Due_On" runat="server" Text='<%#Eval("Status_Due_On") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Status_Due_On"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Comments">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblComments" runat="server" Text='<%#Eval("Comments")%>' Width="300px"
                                        CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Item Status">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_Item_Status" runat="server" Text='<%#Eval("FK_LU_Item_Status")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Updated By">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdated_By" runat="server" Text='<%#Eval("Updated_By")%>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Update Date">
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
