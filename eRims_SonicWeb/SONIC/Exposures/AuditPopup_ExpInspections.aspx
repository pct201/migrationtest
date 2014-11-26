<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_ExpInspections.aspx.cs"
    Inherits="SONIC_Exposures_AuditPopup_ExpInspections" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: Inspection Audit Trail</title>
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
                    <asp:Label ID="lbltable_Name" runat="server" Font-Bold="true"></asp:Label><br />
                    Focus Area :&nbsp;<b><span><%=Request.QueryString["focusarea"].Replace("'","")%></span></b>
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
                                        <span style="display: inline-block; width: 120px;">PK_Inspection_ID</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">FK_LU_Location_ID</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Inspector_Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 250px;">Item_Number_Focus_Area</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Question_Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 300px;">Question_Text</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 300px;">Guidance_Text</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">PK_Inspection_Responses_ID</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">FK_Inspection_ID</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">FK_Inspection_Question_ID</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 300px;">Deficiency_Noted</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 300px;">Department</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Date_Opened</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 300px;">Recommended_Action</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 170px;">Target_Completion_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 170px;">Actual_Completion_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 300px;">Notes</span>
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
                        <asp:GridView ID="gvInspections" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvInspections_RowDataBound"
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
                                <asp:TemplateField HeaderText="PK_Inspection_ID">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblPK_Inspection_ID" runat="server" Text='<%# Eval("PK_Inspection_ID") %>'
                                            Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_LU_Location_ID">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFK_LU_Location_ID" runat="server" Text='<%# Eval("dba") %>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lbldate" runat="server" Text='<%#Eval("date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("date"))) : ""%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Inspector_Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblInspector_Name" runat="server" Text='<%#Eval("Inspector_Name")%>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item_Number_Focus_Area">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_Number_Focus_Area" runat="server" Text='<%#Eval("Item_Number_Focus_Area")%>'
                                            Width="250px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Question_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblQuestion_Number" runat="server" Text='<%#Eval("Question_Number")%>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Question_Text">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblQuestion_Text" runat="server" Text='<%#Eval("Question_Text")%>'
                                            Width="300px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Guidance_Text">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGuidance_Text" runat="server" Text='<%#Eval("Guidance_Text")%>'
                                            Width="300px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PK_Inspection_Responses_ID">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblPK_Inspection_Responses_ID" runat="server" Text='<%# Eval("PK_Inspection_Responses_ID")%>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_Inspection_ID">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFK_Inspection_ID" runat="server" Text='<%# Eval("FK_Inspection_ID") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_Inspection_Question_ID">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFK_Inspection_Question_ID" runat="server" Text='<%# Eval("FK_Inspection_Question_ID")%>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Deficiency_Noted">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDeficiency_Noted" runat="server" Text='<%# Eval("Deficiency_Noted")%>'
                                            Width="300px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Department">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDepartment" runat="server" Text='<%#Eval("Department")%>' Width="300px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Opened">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate_Opened" runat="server" Text='<%#Eval("Date_Opened") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Opened"))) : ""%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Recommended_Action">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRecommended_Action" runat="server" Text='<%#Eval("Recommended_Action")%>'
                                            Width="300px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Target_Completion_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblTarget_Completion_Date" runat="server" Text='<%#Eval("Target_Completion_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Target_Completion_Date"))) : ""%>'
                                            Width="170px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Actual_Completion_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblActual_Completion_Date" runat="server" Text='<%#Eval("Actual_Completion_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Actual_Completion_Date"))) : ""%>'
                                            Width="170px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Notes">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblNotes" runat="server" Text='<%#Eval("Notes")%>' Width="300px" CssClass="TextClip"></asp:Label>
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
