<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_Building_GGKL.aspx.cs"
    Inherits="SONIC_Exposures_AuditPopup_Building_GGKL" %>

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
                                <th class="cols">	                                <span style="display: inline-block;width:120px;">PK_Building_GGKL</span>                                </th>
                                <th class="cols">	                                <span style="display: inline-block;width:120px;">FK_Building_Id</span>                                </th>
                                <th class="cols">	                                <span style="display: inline-block;width:100px;">Date</span>                                </th>
                                <th class="cols">	                                <span style="display: inline-block;width:200px;">Operators_With_Demos</span>                                </th>
                                <th class="cols">	                                <span style="display: inline-block;width:200px;">Operators_Without_Demos</span>                                </th>
                                <th class="cols">	                                <span style="display: inline-block;width:180px;">Non_Employee_Demos</span>                                </th>
                                <th class="cols">	                                <span style="display: inline-block;width:180px;">All_Other_Associates</span>                                </th>
                                <th class="cols">	                                <span style="display: inline-block;width:150px;">Dealer_Plates</span>                                </th>
                                <th class="cols">	                                <span style="display: inline-block;width:250px;">Associates_Work_On_Vehicles</span>                                </th>
                                <th class="cols">	                                <span style="display: inline-block;width:300px;">Notes</span>                                </th>
                                <th class="cols">	                                <span style="display: inline-block;width:130px;">Total</span>                                </th>
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
                            <asp:TemplateField HeaderText="PK_Building_GGKL" >	                            <ItemStyle CssClass="cols" />	                            <ItemTemplate>		                            <asp:Label ID="lblPK_Building_GGKL" runat="server" Text='<%#Eval("PK_Building_GGKL")%>' Width="120px" ></asp:Label>	                            </ItemTemplate>                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_Building_Id" >	                            <ItemStyle CssClass="cols" />	                            <ItemTemplate>		                            <asp:Label ID="lblFK_Building_Id" runat="server" Text='<%#Eval("FK_Building_Id")%>' Width="120px" ></asp:Label>	                            </ItemTemplate>                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date" >	                            <ItemStyle CssClass="cols" />	                            <ItemTemplate>		                            <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date"))) : ""%>' Width="100px" ></asp:Label>	                            </ItemTemplate>                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Operators_With_Demos" >	                            <ItemStyle CssClass="cols" />	                            <ItemTemplate>		                            <asp:Label ID="lblOperators_With_Demos" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Operators_With_Demos")).Replace(".00", "")%>' Width="200px" ></asp:Label>	                            </ItemTemplate>                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Operators_Without_Demos" >	                            <ItemStyle CssClass="cols" />	                            <ItemTemplate>		                            <asp:Label ID="lblOperators_Without_Demos" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Operators_Without_Demos")).Replace(".00", "")%>' Width="200px" ></asp:Label>	                            </ItemTemplate>                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Non_Employee_Demos" >	                            <ItemStyle CssClass="cols" />	                            <ItemTemplate>		                            <asp:Label ID="lblNon_Employee_Demos" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Non_Employee_Demos")).Replace(".00", "")%>' Width="180px" ></asp:Label>	                            </ItemTemplate>                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="All_Other_Associates" >	                            <ItemStyle CssClass="cols" />	                            <ItemTemplate>		                            <asp:Label ID="lblAll_Other_Associates" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("All_Other_Associates")).Replace(".00", "")%>' Width="180px" ></asp:Label>	                            </ItemTemplate>                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Dealer_Plates" >	                            <ItemStyle CssClass="cols" />	                            <ItemTemplate>		                            <asp:Label ID="lblDealer_Plates" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Dealer_Plates")).Replace(".00", "")%>' Width="150px" ></asp:Label>	                            </ItemTemplate>                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Associates_Work_On_Vehicles" >	                            <ItemStyle CssClass="cols" />	                            <ItemTemplate>		                            <asp:Label ID="lblAssociates_Work_On_Vehicles" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Associates_Work_On_Vehicles")).Replace(".00", "")%>' Width="250px" ></asp:Label>	                            </ItemTemplate>                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Notes" >	                            <ItemStyle CssClass="cols" />	                            <ItemTemplate>		                            <asp:Label ID="lblNotes" runat="server" Text='<%#Eval("Notes")%>' Width="300px" CssClass="TextClip"></asp:Label>	                            </ItemTemplate>                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total" >	                            <ItemStyle CssClass="cols" />	                            <ItemTemplate>		                            <asp:Label ID="lblTotal" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Total")).Replace(".00", "")%>' Width="130px" ></asp:Label>	                            </ItemTemplate>                            </asp:TemplateField>
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
