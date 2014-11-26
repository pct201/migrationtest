<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_RE_Repair_Maint.aspx.cs" Inherits="SONIC_RealEstate_AuditPopup_RE_Repair_Maint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: RE_Repair_Maintenance Audit Trail</title>
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
	                                    <span style="display: inline-block;width:100px;">Audit_DateTime</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:200px;">PK_RE_Repair_Maintenance</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:130px;">FK_RE_Information</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:150px;">Type of Repair</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:150px;">Date PCA Ordered</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:150px;">Date PCA Conducted</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:150px;">PCA Conducted By</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:200px;">Scope of Work</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:300px;">General Repair/Damage Description</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:350px;">Detailed Description of Repair/Damage</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:200px;">Contractor</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:130px;">Estimate Amount</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:130px;">Proposal Amount</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:130px;">Actual Amount</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:150px;">Estaimted Start Date</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:150px;">Actual Start Date</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:100px;">End Date</span>
                                    </th>
                                     <th class="cols">
	                                    <span style="display: inline-block;width:110px;">Updated_By</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:117px;">Updated_Date</span>
                                    </th>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="overflow: scroll; width: 600px; height: 425px;" id="dvGrid" runat="server">
                        <asp:GridView ID="gvRepair_Maintenance" runat="server" AutoGenerateColumns="False"
                            CellPadding="4" EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
                            <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <Columns>
                                <asp:TemplateField HeaderText="Audit_DateTime" >
	                                <ItemStyle CssClass="cols" Width="100px" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            ToolTip='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            Width="100px"></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PK_RE_Repair_Maintenance" >
	                                <ItemStyle CssClass="cols" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblPK_RE_Repair_Maintenance" runat="server" Text='<%#Eval("PK_RE_Repair_Maintenance")%>' Width="200px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_RE_Information" >
	                                <ItemStyle CssClass="cols" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblFK_RE_Information" runat="server" Text='<%#Eval("FK_RE_Information")%>' Width="130px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_LU_Repair_Type" >
	                                <ItemStyle CssClass="cols" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblFK_LU_Repair_Type" runat="server" Text='<%#Eval("FK_LU_Repair_Type")%>' Width="150px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_PCA_Ordered" >
	                                <ItemStyle CssClass="cols" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblDate_PCA_Ordered" runat="server" Text='<%#Eval("Date_PCA_Ordered") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_PCA_Ordered"))) : ""%>' Width="150px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_PCA_Conducted" >
	                                <ItemStyle CssClass="cols" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblDate_PCA_Conducted" runat="server" Text='<%#Eval("Date_PCA_Conducted") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_PCA_Conducted"))) : ""%>' Width="150px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PCA_Conducted_By" >
	                                <ItemStyle CssClass="cols" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblPCA_Conducted_By" runat="server" Text='<%#Eval("PCA_Conducted_By")%>' Width="150px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_LU_Work_Scope" >
	                                <ItemStyle CssClass="cols" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblFK_LU_Work_Scope" runat="server" Text='<%#Eval("FK_LU_Work_Scope")%>' Width="200px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Damage_Description" >
	                                <ItemStyle CssClass="cols" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblDamage_Description" runat="server" Text='<%#Eval("Damage_Description")%>' Width="300px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Detailed_Description" >
	                                <ItemStyle CssClass="cols" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblDetailed_Description" runat="server" Text='<%#Eval("Detailed_Description")%>' Width="350px" CssClass="TextClip"></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_RE_Contractor" >
	                                <ItemStyle CssClass="cols" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblFK_RE_Contractor" runat="server" Text='<%#Eval("FK_RE_Contractor")%>' Width="200px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estimate_Amount" >
	                                <ItemStyle CssClass="cols" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblEstimate_Amount" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Estimate_Amount"))%>' Width="130px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Proposal_Amount" >
	                                <ItemStyle CssClass="cols" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblProposal_Amount" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Proposal_Amount"))%>' Width="130px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Actual_Amount" >
	                                <ItemStyle CssClass="cols" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblActual_Amount" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Actual_Amount"))%>' Width="130px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estaimted_Start_Date" >
	                                <ItemStyle CssClass="cols" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblEstaimted_Start_Date" runat="server" Text='<%#Eval("Estaimted_Start_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Estaimted_Start_Date"))) : ""%>' Width="150px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Actual_Start_Date" >
	                                <ItemStyle CssClass="cols" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblActual_Start_Date" runat="server" Text='<%#Eval("Actual_Start_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Actual_Start_Date"))) : ""%>' Width="150px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="End_Date" >
	                                <ItemStyle CssClass="cols" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblEnd_Date" runat="server" Text='<%#Eval("End_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("End_Date"))) : ""%>' Width="100px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Updated_By" >
	                                <ItemStyle CssClass="cols" Width="110px" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblUpdated_By" runat="server" Text='<%#Eval("user_Name")%>' Width="110px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Updated_Date" >
	                                <ItemStyle CssClass="cols" Width="100px" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblUpdated_Date" runat="server" Text='<%#Eval("Update_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Update_Date"))) : ""%>' Width="100px" ></asp:Label>
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
