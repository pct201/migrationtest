<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_Recommendation.aspx.cs"
    Inherits="SONIC_Exposures_AuditTrail_Recommendation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS :: Recommendation Audit Trail</title>

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

</head>
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
                <div style="overflow: hidden; width: 600px;" id="divRecommendation_Audit_Header"
                    runat="server">
                    <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;">
                        <tbody>
                            <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                align="left">
                                <th class="cols">
                                    <span style="display: inline-block; width: 110px">Audit_DateTime</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 285px">PK_Enviro_Equipment_Recommendations_ID</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 110px">Foreign_Table</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 110px">Foreign_Key</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 110px">Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 190px">Number</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 190px">Made_by</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 110px">Status</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 190px">Title</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 600px">Description</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 190px">Assigned_to</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 110px">Due_date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px">Assigned_to_phone</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 210px">Assigned_to_email</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 210px">estimated_cost</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 210px">final_cost</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 600px">resolution</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 110px">Date_closed</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 110px">Updated_by</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 127px">Update_Date</span>
                                </th>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div style="overflow: scroll; width: 600px; height: 425px;" id="divRecommendation_Audit_Grid"
                    runat="server">
                    <asp:GridView ID="gvRecommendation_Audit" runat="server" AutoGenerateColumns="False"
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
                            <asp:TemplateField HeaderText="PK_Enviro_Equipment_Recommendations_ID">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="PK_Enviro_Equipment_Recommendations_ID" runat="server" Text='<%# Bind("PK_Enviro_Equipment_Recommendations_ID") %>'
                                        Width="285px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Foreign_Table">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Foreign_Table") %>' Width="110px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Foreign_Key">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Foreign_Key") %>' Width="110px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date")) %>'
                                        Width="110px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Number">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("Number") %>' Width="190px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Made_by">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("Made_by") %>' Width="190px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="status">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("status") %>' Width="110px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="title">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Label10" runat="server" Text='<%# Bind("title") %>' Width="190px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="description">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("description") %>' Width="600px"
                                        CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Assigned_to">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Label11" runat="server" Text='<%# Bind("Assigned_to") %>' Width="190px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Due_date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Label12" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Due_date")) %>'
                                        Width="110px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Assigned_to_phone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Label13" runat="server" Text='<%# Bind("Assigned_to_phone") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Assigned_to_email">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Label14" runat="server" Text='<%# Bind("Assigned_to_email") %>' Width="210px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="resolution">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Label15" runat="server" Text='<%# Bind("estimated_cost") %>' Width="210px"
                                        CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="resolution">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Label15" runat="server" Text='<%# Bind("final_cost") %>' Width="210px"
                                        CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="resolution">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Label15" runat="server" Text='<%# Bind("resolution") %>' Width="600px"
                                        CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date_closed">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Label16" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_closed")) %>'
                                        Width="110px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Updated_by">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Label17" runat="server" Text='<%# Bind("Updated_by") %>' Width="110px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Update_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Label18" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Update_Date")) %>'
                                        Width="110px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SONICConn %>"
                        SelectCommand="Enviro_Recommendations_AuditView" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="85" Name="PK_Enviro_Equipment_Recommendations_ID" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
