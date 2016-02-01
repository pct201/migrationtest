<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_Lu_Location.aspx.cs"
    Inherits="SONIC_RealEstate_AuditPopup_Lu_Location" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: Audit Trail</title>
</head>

<script language="javascript" type="text/javascript">
    function showAudit(divHeader,divGrid)
    {        
        var divheight,i;
       
        divHeader.style.width = window.screen.availWidth - 435 + "px";
        divGrid.style.width = window.screen.availWidth - 419 + "px";
        
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
            <td colspan="2" align="left">
                <div style="overflow: hidden; width: 675px;" id="dvHeader" runat="server">
                    <table cellpadding="4" cellspacing="0" style="width: 625px; border-collapse: collapse;">
                        <tbody>
                            <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                align="left">
                                <th class="cols">
                                    <span style="display: inline-block; width: 110px;">Audit_DateTime</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">PK_LU_Location_ID</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">RM Location Number</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 210px;">Location Description</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Address 1</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Address 2</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">City</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">State</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Zip Code</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Dealership Telephone</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Year of Acquisition</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">County</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Web Site</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Dba</span>
                                </th>
                                <%--<th class="cols">
                                    <span style="display: inline-block; width: 150px;">Legal Entity</span>
                                </th>--%>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px;">Regional Loss Control</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">ADP DMS</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Region</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Market</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Sonic Location Code</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Active</span>
                                </th>
                                 <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Parent Company LE</span>
                                </th>
                                 <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Parent Company LE FEIN</span>
                                </th>
                                 <th class="cols">
                                    <span style="display: inline-block; width: 150px;">LE Operations</span>
                                </th>
                                 <th class="cols">
                                    <span style="display: inline-block; width: 150px;">LE Operations FEIN</span>
                                </th>
                                 <th class="cols">
                                    <span style="display: inline-block; width: 150px;">LE Properties</span>
                                </th>
                                 <th class="cols">
                                    <span style="display: inline-block; width: 150px;">LE Properties FEIN</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 120px;">Updated_By</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 120px;">Updated_Date</span>
                                </th>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div style="overflow: scroll; width: 625px; height: 425px;" id="dvGrid" runat="server">
                    <asp:GridView ID="gvLocation" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false" >
                        <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <Columns>
                            <asp:TemplateField HeaderText="Audit_DateTime" ItemStyle-Width="110px">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAudit_DateTime" Width="110px" runat="server" Text='<%#Eval("Audit_DateTime") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Audit_DateTime"))):""%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PK_LU_Location_ID" ItemStyle-Width="150px">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPK_LU_Location_ID" runat="server" Text='<%#Eval("PK_LU_Location_ID")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="RM_Location_Number" ItemStyle-Width="150px">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRM_Location_Number" runat="server" Text='<%#Eval("RM_Location_Number")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Location_Description" ItemStyle-Width="210px">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLocation_Description" runat="server" Text='<%#Eval("Location_Description")%>'
                                        Width="210px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address_1" ItemStyle-Width="150px">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAddress_1" runat="server" Text='<%#Eval("Address_1")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address_2" ItemStyle-Width="150px">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAddress_2" runat="server" Text='<%#Eval("Address_2")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="City" ItemStyle-Width="100px">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCity" runat="server" Text='<%#Eval("City")%>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="State" ItemStyle-Width="100px">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblState" runat="server" Text='<%#Eval("Fld_State")%>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Zip_Code" ItemStyle-Width="100px">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblZip_Code" runat="server" Text='<%#Eval("Zip_Code")%>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Dealership_Telephone" ItemStyle-Width="150px">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDealership_Telephone" runat="server" Text='<%#Eval("Dealership_Telephone")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Year_of_Acquisition" ItemStyle-Width="150px">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblYear_of_Acquisition" runat="server" Text='<%#Eval("Year_of_Acquisition")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="County" ItemStyle-Width="100px">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCounty" runat="server" Text='<%#Eval("FLD_county")%>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Web_site" ItemStyle-Width="150px">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblWeb_site" runat="server" Text='<%#Eval("Web_site")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="dba" ItemStyle-Width="150px">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lbldba" runat="server" Text='<%#Eval("dba")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                          <%--  <asp:TemplateField HeaderText="legal_entity" ItemStyle-Width="150px">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lbllegal_entity" runat="server" Text='<%#Eval("legal_entity")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="FK_Regional_Loss_Control_ID" ItemStyle-Width="200px">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_Regional_Loss_Control_ID" runat="server" Text='<%#Eval("Manager")%>'
                                        Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ADP_DMS" ItemStyle-Width="100px">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblADP_DMS" runat="server" Text='<%#Eval("ADP_DMS")%>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Region" ItemStyle-Width="150px">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRegion" runat="server" Text='<%#Eval("Region")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Region" ItemStyle-Width="150px">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRegion" runat="server" Text='<%#Eval("Market")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sonic_Location_Code" ItemStyle-Width="150px">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSonic_Location_Code" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Sonic_Location_Code")).Replace(".00", "")%>'
                                        Width="150px"></asp:Label></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Active" ItemStyle-Width="100px">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblActive" runat="server" Text='<%#Eval("Active")%>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Parent_Company_LE" ItemStyle-Width="100px">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblParent_Company_LE" runat="server" Text='<%#Eval("Parent_Company_LE")%>' Width="150px" Style="word-wrap: normal; word-break: break-all"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Parent_Company_LE_FEIN" ItemStyle-Width="100px">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblParent_Company_LE_FEIN" runat="server" Text='<%#Eval("Parent_Company_LE_FEIN")%>' Width="150px" Style="word-wrap: normal; word-break: break-all"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="LE_Operations" ItemStyle-Width="100px">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLE_Operations" runat="server" Text='<%#Eval("LE_Operations")%>' Width="150px" Style="word-wrap: normal; word-break: break-all"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="LE_Operations_FEIN" ItemStyle-Width="100px">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLE_Operations_FEIN" runat="server" Text='<%#Eval("LE_Operations_FEIN")%>' Width="150px" Style="word-wrap: normal; word-break: break-all"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="LE_Properties" ItemStyle-Width="100px">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLE_Properties" runat="server" Text='<%#Eval("LE_Properties")%>' Width="150px" Style="word-wrap: normal; word-break: break-all"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="LE_Properties_FEIN" ItemStyle-Width="100px">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLE_Properties_FEIN" runat="server" Text='<%#Eval("LE_Properties_FEIN")%>' Width="150px" Style="word-wrap: normal; word-break: break-all"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Updated_By">
                                <ItemStyle CssClass="cols" Width="120px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdated_By" runat="server" Text='<%#Eval("UpdatedBy")%>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Updated_Date">
                                <ItemStyle CssClass="cols" Width="120px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdated_Date" runat="server" Text='<%#Eval("UpdatedDate") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("UpdatedDate"))) : ""%>'
                                        Width="120px"></asp:Label>
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
