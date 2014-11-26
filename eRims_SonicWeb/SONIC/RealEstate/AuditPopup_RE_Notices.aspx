<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_RE_Notices.aspx.cs" Inherits="SONIC_RealEstate_AuditPopup_RE_Notices" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: RE_Notices Audit Trail</title>
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
	                                <span style="display: inline-block;width:150px;">PK_RE_Notices</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">FK_RE_Information</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Landlord_Company</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Landlord_Contact</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Landlord_Address1</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Landlord_Address2</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Landlord_City</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">FK_State_Landlord</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Landlord_Zip_Code</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Landlord_Telephone</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Landlord_Facsimile</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Landlord_Email</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Landlord_Copy_Company</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Landlord_Copy_Contact</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Landlord_Copy_Address1</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Landlord_Copy_Address2</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Landlord_Copy_City</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">FK_State_Landlord_Copy</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Landlord_Copy_Zip_Code</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Landlord_Copy_Telephone</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Landlord_Copy_Facsimile</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Landlord_Copy_Email</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Tenant_Company</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Tenant_Contact</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Tenant_Address1</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Tenant_Address2</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Tenant_City</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">FK_State_Tenant</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Tenant_Zip_Code</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Tenant_Telephone</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Tenant_Facsimile</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Tenant_Email</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Tenant_Copy_Company</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Tenant_Copy_Contact</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Tenant_Copy_Address1</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Tenant_Copy_Address2</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Tenant_Copy_City</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">FK_State_Tenant_Copy</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Tenant_Copy_Zip_Code</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:180px;">Tenant_Copy_Telephone</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:180px;">Tenant_Copy_Facsimile</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Tenant_Copy_Email</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Subtenant_Company</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Subtenant_Contact</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Subtenant_Address1</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Subtenant_Address2</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Subtenant_City</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">FK_State_Subtenant</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Subtenant_Zip_Code</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Subtenant_Telephone</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Subtenant_Facsimile</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Subtenant_Email</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Subtenant_Copy_Company</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Subtenant_Copy_Contact</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Subtenant_Copy_Address1</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Subtenant_Copy_Address2</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Subtenant_Copy_City</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">FK_State_Subtenant_Copy</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Subtenant_Copy_Zip_Code</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Subtenant_Copy_Telephone</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Subtenant_Copy_Facsimile</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Subtenant_Copy_Email</span>
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
                    <asp:GridView ID="gvRE_Notices" runat="server" AutoGenerateColumns="False" CellPadding="4"
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
                            <asp:TemplateField HeaderText="PK_RE_Notices" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblPK_RE_Notices" runat="server" Text='<%#Eval("PK_RE_Notices")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_RE_Information" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblFK_RE_Information" runat="server" Text='<%#Eval("FK_RE_Information")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord_Company" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblLandlord_Company" runat="server" Text='<%#Eval("Landlord_Company")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord_Contact" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblLandlord_Contact" runat="server" Text='<%#Eval("Landlord_Contact")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord_Address1" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblLandlord_Address1" runat="server" Text='<%#Eval("Landlord_Address1")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord_Address2" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblLandlord_Address2" runat="server" Text='<%#Eval("Landlord_Address2")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord_City" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblLandlord_City" runat="server" Text='<%#Eval("Landlord_City")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_State_Landlord" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblFK_State_Landlord" runat="server" Text='<%#Eval("FK_State_Landlord")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord_Zip_Code" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblLandlord_Zip_Code" runat="server" Text='<%#Eval("Landlord_Zip_Code")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord_Telephone" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblLandlord_Telephone" runat="server" Text='<%#Eval("Landlord_Telephone")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord_Facsimile" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblLandlord_Facsimile" runat="server" Text='<%#Eval("Landlord_Facsimile")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord_Email" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblLandlord_Email" runat="server" Text='<%#Eval("Landlord_Email")%>' Width="200px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord_Copy_Company" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblLandlord_Copy_Company" runat="server" Text='<%#Eval("Landlord_Copy_Company")%>' Width="200px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord_Copy_Contact" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblLandlord_Copy_Contact" runat="server" Text='<%#Eval("Landlord_Copy_Contact")%>' Width="200px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord_Copy_Address1" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblLandlord_Copy_Address1" runat="server" Text='<%#Eval("Landlord_Copy_Address1")%>' Width="200px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord_Copy_Address2" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblLandlord_Copy_Address2" runat="server" Text='<%#Eval("Landlord_Copy_Address2")%>' Width="200px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord_Copy_City" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblLandlord_Copy_City" runat="server" Text='<%#Eval("Landlord_Copy_City")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_State_Landlord_Copy" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblFK_State_Landlord_Copy" runat="server" Text='<%#Eval("FK_State_Landlord_Copy")%>' Width="200px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord_Copy_Zip_Code" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblLandlord_Copy_Zip_Code" runat="server" Text='<%#Eval("Landlord_Copy_Zip_Code")%>' Width="200px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord_Copy_Telephone" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblLandlord_Copy_Telephone" runat="server" Text='<%#Eval("Landlord_Copy_Telephone")%>' Width="200px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord_Copy_Facsimile" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblLandlord_Copy_Facsimile" runat="server" Text='<%#Eval("Landlord_Copy_Facsimile")%>' Width="200px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord_Copy_Email" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblLandlord_Copy_Email" runat="server" Text='<%#Eval("Landlord_Copy_Email")%>' Width="200px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tenant_Company" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblTenant_Company" runat="server" Text='<%#Eval("Tenant_Company")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tenant_Contact" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblTenant_Contact" runat="server" Text='<%#Eval("Tenant_Contact")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tenant_Address1" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblTenant_Address1" runat="server" Text='<%#Eval("Tenant_Address1")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tenant_Address2" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblTenant_Address2" runat="server" Text='<%#Eval("Tenant_Address2")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tenant_City" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblTenant_City" runat="server" Text='<%#Eval("Tenant_City")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_State_Tenant" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblFK_State_Tenant" runat="server" Text='<%#Eval("FK_State_Tenant")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tenant_Zip_Code" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblTenant_Zip_Code" runat="server" Text='<%#Eval("Tenant_Zip_Code")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tenant_Telephone" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblTenant_Telephone" runat="server" Text='<%#Eval("Tenant_Telephone")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tenant_Facsimile" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblTenant_Facsimile" runat="server" Text='<%#Eval("Tenant_Facsimile")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tenant_Email" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblTenant_Email" runat="server" Text='<%#Eval("Tenant_Email")%>' Width="200px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tenant_Copy_Company" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblTenant_Copy_Company" runat="server" Text='<%#Eval("Tenant_Copy_Company")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tenant_Copy_Contact" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblTenant_Copy_Contact" runat="server" Text='<%#Eval("Tenant_Copy_Contact")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tenant_Copy_Address1" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblTenant_Copy_Address1" runat="server" Text='<%#Eval("Tenant_Copy_Address1")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tenant_Copy_Address2" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblTenant_Copy_Address2" runat="server" Text='<%#Eval("Tenant_Copy_Address2")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tenant_Copy_City" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblTenant_Copy_City" runat="server" Text='<%#Eval("Tenant_Copy_City")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_State_Tenant_Copy" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblFK_State_Tenant_Copy" runat="server" Text='<%#Eval("FK_State_Tenant_Copy")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tenant_Copy_Zip_Code" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblTenant_Copy_Zip_Code" runat="server" Text='<%#Eval("Tenant_Copy_Zip_Code")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tenant_Copy_Telephone" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblTenant_Copy_Telephone" runat="server" Text='<%#Eval("Tenant_Copy_Telephone")%>' Width="180px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tenant_Copy_Facsimile" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblTenant_Copy_Facsimile" runat="server" Text='<%#Eval("Tenant_Copy_Facsimile")%>' Width="180px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tenant_Copy_Email" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblTenant_Copy_Email" runat="server" Text='<%#Eval("Tenant_Copy_Email")%>' Width="200px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subtenant_Company" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblSubtenant_Company" runat="server" Text='<%#Eval("Subtenant_Company")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subtenant_Contact" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblSubtenant_Contact" runat="server" Text='<%#Eval("Subtenant_Contact")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subtenant_Address1" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblSubtenant_Address1" runat="server" Text='<%#Eval("Subtenant_Address1")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subtenant_Address2" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblSubtenant_Address2" runat="server" Text='<%#Eval("Subtenant_Address2")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subtenant_City" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblSubtenant_City" runat="server" Text='<%#Eval("Subtenant_City")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_State_Subtenant" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblFK_State_Subtenant" runat="server" Text='<%#Eval("FK_State_Subtenant")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subtenant_Zip_Code" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblSubtenant_Zip_Code" runat="server" Text='<%#Eval("Subtenant_Zip_Code")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subtenant_Telephone" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblSubtenant_Telephone" runat="server" Text='<%#Eval("Subtenant_Telephone")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subtenant_Facsimile" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblSubtenant_Facsimile" runat="server" Text='<%#Eval("Subtenant_Facsimile")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subtenant_Email" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblSubtenant_Email" runat="server" Text='<%#Eval("Subtenant_Email")%>' Width="200px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subtenant_Copy_Company" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblSubtenant_Copy_Company" runat="server" Text='<%#Eval("Subtenant_Copy_Company")%>' Width="200px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subtenant_Copy_Contact" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblSubtenant_Copy_Contact" runat="server" Text='<%#Eval("Subtenant_Copy_Contact")%>' Width="200px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subtenant_Copy_Address1" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblSubtenant_Copy_Address1" runat="server" Text='<%#Eval("Subtenant_Copy_Address1")%>' Width="200px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subtenant_Copy_Address2" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblSubtenant_Copy_Address2" runat="server" Text='<%#Eval("Subtenant_Copy_Address2")%>' Width="200px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subtenant_Copy_City" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblSubtenant_Copy_City" runat="server" Text='<%#Eval("Subtenant_Copy_City")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_State_Subtenant_Copy" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblFK_State_Subtenant_Copy" runat="server" Text='<%#Eval("FK_State_Subtenant_Copy")%>' Width="200px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subtenant_Copy_Zip_Code" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblSubtenant_Copy_Zip_Code" runat="server" Text='<%#Eval("Subtenant_Copy_Zip_Code")%>' Width="200px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subtenant_Copy_Telephone" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblSubtenant_Copy_Telephone" runat="server" Text='<%#Eval("Subtenant_Copy_Telephone")%>' Width="200px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subtenant_Copy_Facsimile" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblSubtenant_Copy_Facsimile" runat="server" Text='<%#Eval("Subtenant_Copy_Facsimile")%>' Width="200px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subtenant_Copy_Email" >
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
	                                <asp:Label ID="lblSubtenant_Copy_Email" runat="server" Text='<%#Eval("Subtenant_Copy_Email")%>' Width="200px" ></asp:Label>
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
