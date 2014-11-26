<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_RE_Surrender.aspx.cs" Inherits="SONIC_RealEstate_AuditPopup_RE_Surrender" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: RE_Surrender_Obligations Audit Trail</title>
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
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Audit_DateTime</span>
                                </th>                                
                                <th class="cols">
                                    <span style="display: inline-block;width:250px;">PK_RE_Surrender_Obligations</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block;width:120px;">FK_RE_Information</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block;width:200px;">Condition_At_Commencement</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block;width:200px;">Permitted Use</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block;width:200px;">Alterations</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block;width:200px;">Tenants Obligations</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block;width:200px;">Environmental_Matters</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block;width:200px;">Landlords Obligations</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 110px;">Updated_By</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 117px;">Updated_Date</span>
                                </th>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div style="overflow: scroll; width: 600px; height: 425px;" id="dvGrid" runat="server">
                    <asp:GridView ID="gvRE_Surrender" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
                        <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <Columns>
                            <asp:TemplateField HeaderText="Audit_DateTime">
                                <ItemStyle CssClass="cols" Width="100px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            ToolTip='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PK_RE_Surrender_Obligations" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblPK_RE_Surrender_Obligations" runat="server" Text='<%#Eval("PK_RE_Surrender_Obligations")%>' Width="250px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_RE_Information" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblFK_RE_Information" runat="server" Text='<%#Eval("FK_RE_Information")%>' Width="120px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Condition_At_Commencement" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblCondition_At_Commencement" runat="server" Text='<%#Eval("Condition_At_Commencement")%>' Width="200px" CssClass="TextClip"></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Permitted_Use" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblPermitted_Use" runat="server" Text='<%#Eval("Permitted_Use")%>' Width="200px" CssClass="TextClip"></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Alterations" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblAlterations" runat="server" Text='<%#Eval("Alterations")%>' Width="200px" CssClass="TextClip"></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tenants_Obligations" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblTenants_Obligations" runat="server" Text='<%#Eval("Tenants_Obligations")%>' Width="200px" CssClass="TextClip"></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Environmental_Matters" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblEnvironmental_Matters" runat="server" Text='<%#Eval("Environmental_Matters")%>' Width="200px" CssClass="TextClip"></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlords_Obligations" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblLandlords_Obligations" runat="server" Text='<%#Eval("Landlords_Obligations")%>' Width="200px" CssClass="TextClip"></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Updated_By">
                                <ItemStyle CssClass="cols" Width="110px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdated_By" runat="server" Text='<%#Eval("user_Name")%>' Width="110px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Updated_Date">
                                <ItemStyle CssClass="cols" Width="100px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdated_Date" runat="server" Text='<%#Eval("Update_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Update_Date"))) : ""%>'
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
