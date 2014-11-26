<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_Franchise.aspx.cs"
    Inherits="SONIC_Franchise_AuditPopup_Franchise" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: Franchise Audit Trail</title>
    
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
                <div style="overflow: hidden; width: 600px;" id="divFranchise_Header" runat="server">
                    <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;">
                        <tbody>
                            <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                align="left">
                                <th class="cols">
                                    <span style="display: inline-block; width: 110px;">Audit DateTime</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">PK_Franchise</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">FK_Building_Id</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 120px;">Construction Start</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Franchise Brand</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Construction Finish</span>
                                </th>
                                <%--<th class="cols">
                                    <span style="display: inline-block; width: 140px;">Franchise Brand Image</span>
                                </th>--%>
                                <th class="cols">
                                    <span style="display: inline-block; width: 160px;">Anticipated Completion</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px;">Franchise Plans Submitted</span>
                                </th>
                                <%--<th class="cols">
                                    <span style="display: inline-block; width: 160px;">Franchise Additional Land</span>
                                </th>--%>
                                <th class="cols">
                                    <span style="display: inline-block; width: 170px;">Franchise Permit Secured</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 160px;">Franchise Renewal Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 160px;">Proposed Improvements Costs ($)</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 160px;">Signage Ordered</span>
                                </th>
                                <%--<th class="cols">
                                    <span style="display: inline-block; width: 165px;">Additional Tracking Field 1 </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Date 1</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 165px;">Additional Tracking Field 2 </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Date 2</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 165px;">Additional Tracking Field 3 </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Date 3</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 165px;">Additional Tracking Field 4 </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Date 4</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 165px;">Additional Tracking Field 5</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Date 5</span>
                                </th>--%>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Additional Land Comments</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Renewal Options</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Scope of Improvements</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Additional Notes</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Updated By</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 167px;">Update Date</span>
                                </th>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div style="overflow: scroll; width: 600px; height: 500px;" id="divFranchise_Grid"
                    runat="server">
                    <asp:GridView ID="gvFranchise" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
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
                            <asp:TemplateField HeaderText="PK_Franchise">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPK_Franchise" runat="server" Text='<%#Eval("PK_Franchise")%>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_Building_Id">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_Building_Id" runat="server" Text='<%#Eval("FK_Building_Id")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Construction_Start">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblConstruction_Start" runat="server" Text='<%#Eval("Construction_Start") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Construction_Start"))) : ""%>'
                                        Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_LU_Franchise_Brand">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_Franchise_Brand" runat="server" Text='<%#Eval("FK_LU_Franchise_Brand")%>'
                                        Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Construction_Finish">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblConstruction_Finish" runat="server" Text='<%#Eval("Construction_Finish") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Construction_Finish"))) : ""%>'
                                        Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Anticipated_Completion">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAnticipated_Completion" runat="server" Text='<%#Eval("Anticipated_Completion") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Anticipated_Completion"))) : ""%>'
                                        Width="160px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_LU_Franchise_Plans_Submitted">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_Franchise_Plans_Submitted" runat="server" Text='<%#Eval("FK_LU_Franchise_Plans_Submitted") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("FK_LU_Franchise_Plans_Submitted"))) : ""%>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_LU_Franchise_Permit_Secured">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_Franchise_Permit_Secured" runat="server" Text='<%#Eval("FK_LU_Franchise_Permit_Secured") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("FK_LU_Franchise_Permit_Secured"))) : ""%>'
                                        Width="170px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Franchise_Renewal_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFranchise_Renewal_Date" runat="server" Text='<%#Eval("Franchise_Renewal_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Franchise_Renewal_Date"))) : ""%>'
                                        Width="160px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Proposed_Improvements_Costs ">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblProposed_Improvements_Costs" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Proposed_Improvements_Costs","{0:N2}")%>'
                                        Width="160px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Signage_Ordered">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSignageOrdered" runat="server" Text='<%#Eval("Signage_Ordered") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Signage_Ordered"))) : ""%>'
                                        Width="160px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                     
                            <asp:TemplateField HeaderText="Additional Land Comments">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRenewal_Options" runat="server" Text='<%#Eval("Additional_Land_Comments")%>'
                                        Width="300px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Renewal_Options">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRenewal_Options" runat="server" Text='<%#Eval("Renewal_Options")%>'
                                        Width="300px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Scope_of_Improvements">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblScope_of_Improvements" runat="server" Text='<%#Eval("Scope_of_Improvements")%>'
                                        Width="300px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Additional_Notes">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAdditional_Notes" runat="server" Text='<%#Eval("Additional_Notes")%>'
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
