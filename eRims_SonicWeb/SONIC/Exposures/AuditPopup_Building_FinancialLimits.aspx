<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_Building_FinancialLimits.aspx.cs"
    Inherits="SONIC_Exposures_AuditPopup_Building_FinancialLimits" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: Building_Financial_Limits Audit Trail</title>
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
                                    <span style="display: inline-block; width: 180px;">PK_Building_Financial_Limits</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">FK_Building_ID</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px;">Property_Valuation_Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px;">Building_Limit</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px;">Associate_Tools_Limit</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px;">Contents_Limit</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px;">Parts_Limit</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px;">Business_Interruption</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px;">Total</span>
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
                    <asp:GridView ID="gvBuildingFinancialLimits" runat="server" AutoGenerateColumns="False"
                        CellPadding="4" EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
                        <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <Columns>
                            <asp:TemplateField HeaderText="Audit_DateTime">
                                <ItemStyle CssClass="cols" Width="100px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%#Eval("Audit_DateTime") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Audit_DateTime"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PK_Building_Financial_Limits">
                                <ItemStyle CssClass="cols" Width="180px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPK_Building_Improvements" runat="server" Text='<%#Eval("PK_Building_Financial_Limits")%>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_Building_ID">
                                <ItemStyle CssClass="cols" Width="150px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_Building" runat="server" Text='<%#Eval("FK_Building_ID")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Property_Valuation_Date">
                                <ItemStyle CssClass="cols" Width="200px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCompletion_Date" runat="server" Text='<%#Eval("Property_Valuation_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Property_Valuation_Date"))) : ""%>'
                                        Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                            
                            <asp:TemplateField HeaderText="Building_Limit">
                                <ItemStyle CssClass="cols" Width="180px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRevised_Square_Footage_Sales" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Building_Limit")).Replace(".00","")%>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Associate_Tools_Limit">
                                <ItemStyle CssClass="cols" Width="200px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRevised_Square_Footage_Service" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Associate_Tools_Limit")).Replace(".00","")%>'
                                        Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contents_Limit">
                                <ItemStyle CssClass="cols" Width="200px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRevised_Square_Footage_Parts" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Contents_Limit")).Replace(".00","")%>'
                                        Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Parts_Limit">
                                <ItemStyle CssClass="cols" Width="200px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRevised_Square_Footage_Other" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Parts_Limit")).Replace(".00","")%>'
                                        Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Business_Interruption">
                                <ItemStyle CssClass="cols" Width="200px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblImprovement_Value" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Business_Interruption"))%>'
                                        Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Total">
                                <ItemStyle CssClass="cols" Width="200px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblImprovement_Value" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Total"))%>'
                                        Width="200px"></asp:Label>
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
