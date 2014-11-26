<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_RE_Subtenant_TRS.aspx.cs" Inherits="SONIC_RealEstate_AuditPopup_RE_Subtenant_TRS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: RE_Subtenant_TRS Audit Trail</title>
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
	                                    <span style="display: inline-block;width:200px;">PK_RE_Subtenant_TRS</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:130px;">FK_RE_Subtenant</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:100px;">Year</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:100px;">From Date</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:100px;">To Date</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:200px;">Number of Months</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:130px;">Monthly Rent</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:130px;">Additions</span>
                                    </th>
                                    <th class="cols">
	                                    <span style="display: inline-block;width:130px;">Percentage Rate</span>
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
                        <asp:GridView ID="gvSubtenant_TRS" runat="server" AutoGenerateColumns="False"
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
                                <asp:TemplateField HeaderText="PK_RE_Subtenant_TRS" >
	                                <ItemStyle CssClass="cols" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblPK_RE_Subtenant_TRS" runat="server" Text='<%#Eval("PK_RE_Subtenant_TRS")%>' Width="200px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_RE_Subtenant" >
	                                <ItemStyle CssClass="cols" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblFK_RE_Subtenant" runat="server" Text='<%#Eval("FK_RE_Subtenant")%>' Width="130px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Year" >
	                                <ItemStyle CssClass="cols" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblYear" runat="server" Text='<%#Eval("Year")%>' Width="100px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="From_Date" >
	                                <ItemStyle CssClass="cols" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblFrom_Date" runat="server" Text='<%#Eval("From_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("From_Date"))) : ""%>' Width="100px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="To_Date" >
	                                <ItemStyle CssClass="cols" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblTo_Date" runat="server" Text='<%#Eval("To_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("To_Date"))) : ""%>' Width="100px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Months" >
	                                <ItemStyle CssClass="cols" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblMonths" runat="server" Text='<%#Eval("Months")%>' Width="200px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Monthly_Rent" >
	                                <ItemStyle CssClass="cols" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblMonthly_Rent" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Monthly_Rent"))%>' Width="130px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Additions" >
	                                <ItemStyle CssClass="cols" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblAdditions" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Additions"))%>' Width="130px" ></asp:Label>
	                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Percentage_Rate" >
	                                <ItemStyle CssClass="cols" />
	                                <ItemTemplate>
		                                <asp:Label ID="lblPercentage_Rate" runat="server" Text='<%#Eval("Percentage_Rate")%>' Width="130px" ></asp:Label>
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
