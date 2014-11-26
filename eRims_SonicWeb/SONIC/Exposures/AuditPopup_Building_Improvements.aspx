<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_Building_Improvements.aspx.cs" Inherits="SONIC_Exposures_AuditPopup_Building_Improvements" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: Building_Improvements Audit Trail</title>
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
                    <div style="overflow: hidden; width: 650px;" id="dvHeader" runat="server">
                        <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                    align="left">
                                    <th class="cols">	                                    <span style="display: inline-block;width:100px;">Audit_DateTime</span>                                    </th>
                                    <th class="cols">	                                    <span style="display: inline-block;width:180px;">PK_Building_Improvements</span>                                    </th>
                                    <th class="cols">	                                    <span style="display: inline-block;width:150px;">FK_Building</span>                                    </th>
                                    <th class="cols">	                                    <span style="display: inline-block;width:200px;">Improvement_Description</span>                                    </th>
                                    <th class="cols">	                                    <span style="display: inline-block;width:180px;">Service_Capacity_Increase</span>                                    </th>
                                    <th class="cols">	                                    <span style="display: inline-block;width:200px;">Revised_Square_Footage_Sales</span>                                    </th>
                                    <th class="cols">	                                    <span style="display: inline-block;width:250px;">Revised_Square_Footage_Service</span>                                    </th>
                                    <th class="cols">	                                    <span style="display: inline-block;width:200px;">Revised_Square_Footage_Parts</span>                                    </th>
                                    <th class="cols">	                                    <span style="display: inline-block;width:200px;">Revised_Square_Footage_Other</span>                                    </th>
                                    <th class="cols">	                                    <span style="display: inline-block;width:150px;">Improvement_Value</span>                                    </th>
                                    <th class="cols">	                                    <span style="display: inline-block;width:150px;">Completion_Date</span>                                    </th>
                                    <th class="cols">	                                    <span style="display: inline-block;width:110px;">Updated_By</span>                                    </th>
                                    <th class="cols">	                                    <span style="display: inline-block;width:117px;">Updated_Date</span>                                    </th>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="overflow: scroll; width: 600px; height: 425px;" id="dvGrid" runat="server">
                        <asp:GridView ID="gvBuildingImprovements" runat="server" AutoGenerateColumns="False"
                            CellPadding="4" EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
                            <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <Columns>
                                <asp:TemplateField HeaderText="Audit_DateTime" >	                                <ItemStyle CssClass="cols" Width="100px" />	                                <ItemTemplate>		                                <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%#Eval("Audit_DateTime") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Audit_DateTime"))) : ""%>' Width="100px" ></asp:Label>	                                </ItemTemplate>                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PK_Building_Improvements" >	                                <ItemStyle CssClass="cols" Width="180px" />	                                <ItemTemplate>		                                <asp:Label ID="lblPK_Building_Improvements" runat="server" Text='<%#Eval("PK_Building_Improvements")%>' Width="180px" ></asp:Label>	                                </ItemTemplate>                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_Building" >	                                <ItemStyle CssClass="cols" Width="150px" />	                                <ItemTemplate>		                                <asp:Label ID="lblFK_Building" runat="server" Text='<%#Eval("FK_Building")%>' Width="150px" ></asp:Label>	                                </ItemTemplate>                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Improvement_Description" >	                                <ItemStyle CssClass="cols" Width="200px" />	                                <ItemTemplate>		                                <asp:Label ID="lblImprovement_Description" runat="server" Text='<%#Eval("Improvement_Description")%>' Width="200px" ></asp:Label>	                                </ItemTemplate>                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Service_Capacity_Increase" >	                                <ItemStyle CssClass="cols" Width="180px" />	                                <ItemTemplate>		                                <asp:Label ID="lblService_Capacity_Increase" runat="server" Text='<%#Eval("Service_Capacity_Increase")%>' Width="180px" ></asp:Label>	                                </ItemTemplate>                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Revised_Square_Footage_Sales" >	                                <ItemStyle CssClass="cols" Width="200px" />	                                <ItemTemplate>		                                <asp:Label ID="lblRevised_Square_Footage_Sales" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Revised_Square_Footage_Sales")).Replace(".00","")%>' Width="200px" ></asp:Label>	                                </ItemTemplate>                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Revised_Square_Footage_Service" >	                                <ItemStyle CssClass="cols" Width="250px" />	                                <ItemTemplate>		                                <asp:Label ID="lblRevised_Square_Footage_Service" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Revised_Square_Footage_Service")).Replace(".00","")%>' Width="250px" ></asp:Label>	                                </ItemTemplate>                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Revised_Square_Footage_Parts" >	                                <ItemStyle CssClass="cols" Width="200px" />	                                <ItemTemplate>		                                <asp:Label ID="lblRevised_Square_Footage_Parts" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Revised_Square_Footage_Parts")).Replace(".00","")%>' Width="200px" ></asp:Label>	                                </ItemTemplate>                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Revised_Square_Footage_Other" >	                                <ItemStyle CssClass="cols" Width="200px" />	                                <ItemTemplate>		                                <asp:Label ID="lblRevised_Square_Footage_Other" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Revised_Square_Footage_Other")).Replace(".00","")%>' Width="200px" ></asp:Label>	                                </ItemTemplate>                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Improvement_Value" >	                                <ItemStyle CssClass="cols" Width="150px" />	                                <ItemTemplate>		                                <asp:Label ID="lblImprovement_Value" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Improvement_Value"))%>' Width="150px" ></asp:Label>	                                </ItemTemplate>                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Completion_Date" >	                                <ItemStyle CssClass="cols" Width="150px" />	                                <ItemTemplate>		                                <asp:Label ID="lblCompletion_Date" runat="server" Text='<%#Eval("Completion_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Completion_Date"))) : ""%>' Width="150px" ></asp:Label>	                                </ItemTemplate>                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Updated_By" >	                                <ItemStyle CssClass="cols" Width="110px" />	                                <ItemTemplate>		                                <asp:Label ID="lblUpdated_By" runat="server" Text='<%#Eval("user_Name")%>' Width="110px" ></asp:Label>	                                </ItemTemplate>                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Updated_Date" >	                                <ItemStyle CssClass="cols" Width="100px" />	                                <ItemTemplate>		                                <asp:Label ID="lblUpdated_Date" runat="server" Text='<%#Eval("Updated_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Updated_Date"))) : ""%>' Width="100px" ></asp:Label>	                                </ItemTemplate>                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
