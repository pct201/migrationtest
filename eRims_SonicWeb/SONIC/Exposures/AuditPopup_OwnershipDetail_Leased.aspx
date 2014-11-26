<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_OwnershipDetail_Leased.aspx.cs"
    Inherits="SONIC_Exposures_AuditPopup_OwnershipDetail_Leased" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: Building_Ownership Audit Trail</title>
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
                                        <span style="display: inline-block; width: 110px">Audit_DateTime</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">PK_Building_Ownership_ID</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">FK_Building_ID</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Lease_Sublease</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Landlord_Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Landlord_Address_1</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Landlord_Address_2</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Landlord_City</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Landlord_State</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Landlord_Zip</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">Landlord_Legal_Entity</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Lease_ID</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Sublease</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">SubLandlord</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Commencement_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Expiration_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 300px;">COI_Wording</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">REQ_WC</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">REQ_EL</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">REQ_GL</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px;">REQ_Pollution</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px;">REQ_Property</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px;">REQ_Flood</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">REQ_EQ</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">REQ_WaiverofSubrogation</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">SubResponsible_WC</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">SubResponsible_EL</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">SubResponsible_GL</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">SubResponsible_Pollution</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">SubResponsible_Property</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">SubResponsible_Flood</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">EQ</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">WaiverofSubrogation</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">COI_WC</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">COI_EL</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">COI_GL</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">COI_Pollution</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">COI_Property</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">COI_Flood</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">COI_EQ</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">COI_WaiverofSubrogation</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">COI_WC_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">COI_EL_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">COI_GL_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">COI_Pollution_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">COI_Property_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">COI_Flood_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">COI_EQ_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">COI_WaiverofSubrogation_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">ReqLim_WC</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">ReqLim_EL</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">ReqLim_GL</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">ReqLim_Pollution</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">ReqLim_Property</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">ReqLim_Flood</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">ReqLim_EQ</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">ReqLim_WaiverofSubrogation</span>
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
                        <asp:GridView ID="gvOwnershipDetails" runat="server" AutoGenerateColumns="False"
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
                                <asp:TemplateField HeaderText="PK_Building_Ownership_ID">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblPK_Building_Ownership_ID" runat="server" Text='<%# Eval("PK_Building_Ownership_ID") %>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_Building_ID">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFK_Building_ID" runat="server" Text='<%# Eval("Building_Number") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Lease_Sublease">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblLease_Sublease" runat="server" Text='<%#Eval("Lease_Sublease")%>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Landlord_Name">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblLandlord_Name" runat="server" Text='<%#Eval("Landlord_Name")%>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Landlord_Address_1">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblLandlord_Address_1" runat="server" Text='<%#Eval("Landlord_Address_1")%>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Landlord_Address_2">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblLandlord_Address_2" runat="server" Text='<%#Eval("Landlord_Address_2")%>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Landlord_City">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblLandlord_City" runat="server" Text='<%#Eval("Landlord_City")%>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Landlord_State">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblLandlord_State" runat="server" Text='<%#Eval("Landlord_State")%>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Landlord_Zip">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblLandlord_Zip" runat="server" Text='<%#Eval("Landlord_Zip")%>' Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Landlord_Legal_Entity">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblLandlord_Legal_Entity" runat="server" Text='<%#Eval("Landlord_Legal_Entity")%>' Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Lease_ID">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblLease_ID" runat="server" Text='<%#Eval("Lease_ID")%>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sublease">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSublease" runat="server" Text='<%#Eval("Sublease")%>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SubLandlord">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubLandlord" runat="server" Text='<%#Eval("SubLandlord")%>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Commencement_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCommencement_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Commencement_Date"))%>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Expiration_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblExpiration_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Expiration_Date"))%>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="COI_Wording">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCOI_Wording" runat="server" Text='<%#Eval("COI_Wording")%>' Width="300px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="REQ_WC">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblREQ_WC" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplayForView(Eval("REQ_WC"))%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="REQ_EL">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblREQ_EL" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplayForView(Eval("REQ_EL"))%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="REQ_GL">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblREQ_GL" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplayForView(Eval("REQ_GL"))%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="REQ_Pollution">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblREQ_Pollution" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplayForView(Eval("REQ_Pollution"))%>'
                                            Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="REQ_Property">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblREQ_Property" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplayForView(Eval("REQ_Property"))%>'
                                            Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="REQ_Flood">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblREQ_Flood" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplayForView(Eval("REQ_Flood"))%>'
                                            Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="REQ_EQ">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblREQ_EQ" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplayForView(Eval("REQ_EQ"))%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="REQ_WaiverofSubrogation">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblREQ_WaiverofSubrogation" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplayForView(Eval("REQ_WaiverofSubrogation"))%>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SubResponsible_WC">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubResponsible_WC" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplayForView(Eval("SubResponsible_WC"))%>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SubResponsible_EL">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubResponsible_EL" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplayForView(Eval("SubResponsible_EL"))%>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SubResponsible_GL">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubResponsible_GL" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplayForView(Eval("SubResponsible_GL"))%>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SubResponsible_Pollution">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubResponsible_Pollution" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplayForView(Eval("SubResponsible_Pollution"))%>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SubResponsible_Property">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubResponsible_Property" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplayForView(Eval("SubResponsible_Property"))%>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SubResponsible_Flood">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubResponsible_Flood" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplayForView(Eval("SubResponsible_Flood"))%>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="EQ">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblEQ" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplayForView(Eval("EQ"))%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="WaiverofSubrogation">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblWaiverofSubrogation" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplayForView(Eval("WaiverofSubrogation"))%>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="COI_WC">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCOI_WC" runat="server" Text='<%#Eval("COI_WC")%>' Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="COI_EL">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCOI_EL" runat="server" Text='<%#Eval("COI_EL")%>' Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="COI_GL">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCOI_GL" runat="server" Text='<%#Eval("COI_GL")%>' Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="COI_Pollution">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCOI_Pollution" runat="server" Text='<%#Eval("COI_Pollution")%>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="COI_Property">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCOI_Property" runat="server" Text='<%#Eval("COI_Property")%>' Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="COI_Flood">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCOI_Flood" runat="server" Text='<%#Eval("COI_Flood")%>' Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="COI_EQ">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCOI_EQ" runat="server" Text='<%#Eval("COI_EQ")%>' Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="COI_WaiverofSubrogation">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCOI_WaiverofSubrogation" runat="server" Text='<%#Eval("COI_WaiverofSubrogation")%>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="COI_WC_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCOI_WC_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("COI_WC_Date"))%>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="COI_EL_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCOI_EL_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("COI_EL_Date"))%>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="COI_GL_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCOI_GL_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("COI_GL_Date"))%>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="COI_Pollution_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCOI_Pollution_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("COI_Pollution_Date"))%>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="COI_Property_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCOI_Property_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("COI_Property_Date"))%>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="COI_Flood_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCOI_Flood_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("COI_Flood_Date"))%>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="COI_EQ_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCOI_EQ_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("COI_EQ_Date"))%>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="COI_WaiverofSubrogation_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCOI_WaiverofSubrogation_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("COI_WaiverofSubrogation_Date"))%>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ReqLim_WC">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblReqLim_WC" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("ReqLim_WC"))%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ReqLim_EL">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblReqLim_EL" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("ReqLim_EL"))%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ReqLim_GL">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblReqLim_GL" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("ReqLim_GL"))%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ReqLim_Pollution">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblReqLim_Pollution" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("ReqLim_Pollution"))%>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ReqLim_Property">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblReqLim_Property" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("ReqLim_Property"))%>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ReqLim_Flood">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblReqLim_Flood" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("ReqLim_Flood"))%>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ReqLim_EQ">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblReqLim_EQ" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("ReqLim_EQ"))%>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ReqLim_WaiverofSubrogation">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblReqLim_WaiverofSubrogation" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("ReqLim_WaiverofSubrogation"))%>'
                                            Width="200px"></asp:Label>
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
