<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PolicyFeatureAuditPopup.aspx.cs"
    Inherits="Policy_PolicyFeatureAuditPopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: Policy_Features_Audit Audit Trail</title>

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
        <div>
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
                        <div style="overflow: hidden; width: 600px;" id="divPolicyFeature_Header" runat="server">
                            <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;">
                                <tbody>
                                    <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                        align="left">
                                        <td class="cols">
                                            <span style="display: inline-block; width: 160px">Audit_DateTime</span>
                                        </td>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 120px">PK_Policy_Features</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 120px">FK_Policy</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 120px">Feature</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 135px">Limit</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 135px">Deductible</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 600px">Notes</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 135px">Updated_By</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 152px">Update_Date</span>
                                        </th>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div style="overflow-y: scroll; width: 600px; height: 425px;" id="divPolicyFeature_Grid"
                            runat="server">
                            <asp:GridView ID="gvPolicyFeature" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                EnableTheming="true" EmptyDataText="No records found!" ShowHeader="false">
                                <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%#Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                                ToolTip='<%#Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                                Width="160px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="PK_Policy_Id" runat="server" Text='<%#Eval("PK_Policy_Features")%>'
                                                Width="120px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Policy_Type" runat="server" Text='<%#Eval("FK_Policy")%>' Width="120px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Policy_Number" runat="server" Text='<%#Eval("Feature")%>' Width="120px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Carrier" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Limit"))%>' Width="135px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Deductible" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Deductible"))%>' Width="135px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Notes" runat="server" Text='<%#Eval("Notes")%>' CssClass="TextClip"
                                                Width="600px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Updated_By" runat="server" Text='<%#Eval("USER_NAME")%>' Width="135px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="Update_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Updated_Date"))%>'
                                                Width="135px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
