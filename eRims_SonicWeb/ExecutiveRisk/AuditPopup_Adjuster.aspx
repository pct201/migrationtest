<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_Adjuster.aspx.cs" Inherits="ExecutiveRisk_AuditPopup_Adjuster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: Adjustor_Notes Audit Trail</title>
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
                    <div style="overflow: hidden; width: 600px;" id="divAdjustor_Notes_Audit_Header" runat="server">
                        <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                    align="left">
                                    <td class="cols">
                                        <span style="display: inline-block; width: 110px">Audit_DateTime</span>
                                    </td>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">PK_Adjustor_Notes_ID</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px">Table_Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px">FK_Table_Name</span>
                                    </th>
                                     <th class="cols">
                                        <span style="display: inline-block; width: 130px">Activity_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">Date_Of_Note</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">Author_Of_Note</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">Note_Type</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px">Update_By</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 400px">Notes</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px">Updated_By</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 117px">Update_Date</span>
                                    </th>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="overflow: scroll; width: 600px; height: 425px;" id="divAdjustor_Notes_Audit_Grid"
                        runat="server">
                        <asp:GridView ID="gvAdjustor_Notes_Audit" runat="server" AutoGenerateColumns="False"
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
                                <asp:TemplateField HeaderText="PK_Adjustor_Notes_ID" SortExpression="PK_Adjustor_Notes_ID">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="PK_Adjustor_Notes_ID" runat="server" Text='<%# Bind("PK_Adjustor_Notes_ID") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Table_Name" SortExpression="Table_Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Table_Name" runat="server" Text='<%# Bind("Table_Name") %>'
                                            Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_Table_Name" SortExpression="FK_Table_Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="FK_Table_Name" runat="server" Text='<%# Bind("FK_Table_Name") %>' Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Activity_Date" SortExpression="Activity_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Activity_Date" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Eval("Activity_Date") != DBNull.Value  ? Convert.ToDateTime(Eval("Activity_Date")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                         Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Of_Note" SortExpression="Date_Of_Note">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Date_Of_Note" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Eval("Date_Of_Note") != DBNull.Value  ? Convert.ToDateTime(Eval("Date_Of_Note")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                         Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Author_Of_Note" SortExpression="Author_Of_Note">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Author_Of_Note" runat="server" Text='<%# (Eval("Author_Of_Note")) %>' Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Note_Type" SortExpression="Note_Type">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Note_Type" runat="server" Text='<%# Bind("Note_Type") %>' Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Update_By" SortExpression="Update_By">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Update_By" runat="server" Text='<%# Bind("Update_By") %>' Width="110px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Notes" SortExpression="Notes">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Notes" runat="server" Text='<%# Bind("Notes") %>' Width="400px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Updated_By" SortExpression="Updated_By">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="User_Name" runat="server" Text='<%# Bind("User_Name") %>' Width="110px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Update_Date" SortExpression="Update_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Update_Date" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Eval("Update_Date") != DBNull.Value  ? Convert.ToDateTime(Eval("Update_Date")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>' 
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
