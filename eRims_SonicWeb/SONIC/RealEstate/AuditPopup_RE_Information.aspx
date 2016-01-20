<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_RE_Information.aspx.cs" Inherits="SONIC_RealEstate_AuditPopup_RE_Information" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: RE_Information Audit Trail</title>
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
	                                <span style="display: inline-block;width:130px;">PK_RE_Information</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Dealership DBA</span>
                                </th>
                              <%--  <th class="cols">
	                                <span style="display: inline-block;width:100px;">Federal Id</span>
                                </th>--%>
                                <th class="cols">
	                                <span style="display: inline-block;width:100px;">Status</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Tax Parcel Number</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Lease Type</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:120px;">Landlord</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Landlord Legal Entity</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Landlord Location Address 1</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Landlord Location Address 2</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Landlord Location City</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Landlord Location State</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:210px;">Landlord Location Zip Code</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:210px;">Landlord Mailing Address 1</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:210px;">Landlord Mailing Address 2</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Landlord Mailing City</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Landlord Mailing State</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:210px;">Landlord Mailing Zip Code</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:130px;">Landlord Telephone</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:130px;">Landlord E-mail</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:100px;">Sublease?</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:120px;">Subtenant</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:120px;">Lease Id</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:300px;">Lease Commencement Date</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Project Type</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Lease Expiration Date</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:100px;">Date Acquired</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Lease Term In Months</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:100px;">Date Sold</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:250px;">Prior Lease Commencement Date</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Renewals</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:100px;">Year Built</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:100px;">Reminder Date</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:100px;">Year Remodeled</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Landlord Notification Date</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Regional Vice President</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Regional Controller</span>
                                </th>  
                                <th class="cols">
	                                <span style="display: inline-block;width:100px;">Vacate Date</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:120px;">General Manager</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:120px;">Primary Use</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:110px;">Controller</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:120px;">Lease Codes</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Loss Control Manager</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:130px;">Total Acres</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:150px;">Number of Buildings</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:210px;">Total Gross Leaseable Area</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:130px;">Land Value</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:300px;">Amendment Info</span>
                                </th>
                                <th class="cols">
	                                <span style="display: inline-block;width:300px;">Assignment Info</span>
                                </th>  
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">HVAC Repairs</span>
                                </th>  
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">HVAC Capital</span>
                                </th> 
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Roof Repairs </span>
                                </th> 
                                <th class="cols">
	                                <span style="display: inline-block;width:200px;">Roof Capital</span>
                                </th> 
                                <th class="cols">
	                                <span style="display: inline-block;width:300px;">Other Repairs</span>
                                </th> 
                                <th class="cols">
	                                <span style="display: inline-block;width:300px;">Maintenance Notes</span>
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
                    <asp:GridView ID="gvRE_Information" runat="server" AutoGenerateColumns="False" CellPadding="4"
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
                            <asp:TemplateField HeaderText="PK_RE_Information" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblPK_RE_Information" runat="server" Text='<%#Eval("PK_RE_Information")%>' Width="130px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_LU_Location" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblFK_LU_Location" runat="server" Text='<%#Eval("FK_LU_Location")%>' Width="200px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Federal_Id" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblFederal_Id" runat="server" Text='<%#Eval("Federal_Id")%>' Width="100px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="FK_LU_Status" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblFK_LU_Status" runat="server" Text='<%#Eval("FK_LU_Status")%>' Width="100px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tax_Parcel_Number" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblTax_Parcel_Number" runat="server" Text='<%#Eval("Tax_Parcel_Number")%>' Width="150px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_LU_Lease_Type" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblFK_LU_Lease_Type" runat="server" Text='<%#Eval("FK_LU_Lease_Type")%>' Width="150px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblLandlord" runat="server" Text='<%#Eval("Landlord")%>' Width="120px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord Leagal Entity" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblLandlordLegalEntity" runat="server" Text='<%#Eval("Landlord_Legal_Entity")%>' Width="200px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord_Location_Address1" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblLandlord_Location_Address1" runat="server" Text='<%#Eval("Landlord_Location_Address1")%>' Width="200px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord_Location_Address2" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblLandlord_Location_Address2" runat="server" Text='<%#Eval("Landlord_Location_Address2")%>' Width="200px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord_Location_City" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblLandlord_Location_City" runat="server" Text='<%#Eval("Landlord_Location_City")%>' Width="150px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PK_Landlord_Location_State" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblPK_Landlord_Location_State" runat="server" Text='<%#Eval("PK_Landlord_Location_State")%>' Width="200px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord_Location_Zip_Code" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblLandlord_Location_Zip_Code" runat="server" Text='<%#Eval("Landlord_Location_Zip_Code")%>' Width="210px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord_Mailing_Address1" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblLandlord_Mailing_Address1" runat="server" Text='<%#Eval("Landlord_Mailing_Address1")%>' Width="210px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord_Mailing_Address2" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblLandlord_Mailing_Address2" runat="server" Text='<%#Eval("Landlord_Mailing_Address2")%>' Width="210px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord_Mailing_City" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblLandlord_Mailing_City" runat="server" Text='<%#Eval("Landlord_Mailing_City")%>' Width="150px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PK_Landlord_Mailing_State" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblPK_Landlord_Mailing_State" runat="server" Text='<%#Eval("PK_Landlord_Mailing_State")%>' Width="200px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord_Mailing_Zip_Code" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblLandlord_Mailing_Zip_Code" runat="server" Text='<%#Eval("Landlord_Mailing_Zip_Code")%>' Width="210px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord_Telephone" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblLandlord_Telephone" runat="server" Text='<%#Eval("Landlord_Telephone")%>' Width="130px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord_Email" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblLandlord_Email" runat="server" Text='<%#Eval("Landlord_Email")%>' Width="130px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sublease" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblSublease" runat="server" Text='<%#Eval("Sublease").ToString() == "Y" ? "Yes" : "No" %>' Width="100px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subtenant" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblSubtenant" runat="server" Text='<%#Eval("Subtenant")%>' Width="120px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Lease_Id" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblLease_Id" runat="server" Text='<%#Eval("Lease_Id")%>' Width="120px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Lease_Commencement_Date" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblLease_Commencement_Date" runat="server" Text='<%#Eval("Lease_Commencement_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Lease_Commencement_Date"))) : ""%>' Width="300px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_LU_Project_Type" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblFK_LU_Project_Type" runat="server" Text='<%#Eval("FK_LU_Project_Type")%>' Width="200px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Lease_Expiration_Date" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblLease_Expiration_Date" runat="server" Text='<%#Eval("Lease_Expiration_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Lease_Expiration_Date"))) : ""%>' Width="200px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date_Acquired" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblDate_Acquired" runat="server" Text='<%#Eval("Date_Acquired") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Acquired"))) : ""%>' Width="100px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Lease_Term_Months" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblLease_Term_Months" runat="server" Text='<%#Eval("Lease_Term_Months")%>' Width="200px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date_Sold" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblDate_Sold" runat="server" Text='<%#Eval("Date_Sold") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Sold"))) : ""%>' Width="100px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Prior_Lease_Commencement_Date" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblPrior_Lease_Commencement_Date" runat="server" Text='<%#Eval("Prior_Lease_Commencement_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Prior_Lease_Commencement_Date"))) : ""%>' Width="250px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Renewals" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblRenewals" runat="server" Text='<%#Eval("Renewals")%>' Width="200px" Style="word-wrap: normal; word-break: break-all;"></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Year_Built" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblYear_Built" runat="server" Text='<%#Eval("Year_Built")%>' Width="100px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Reminder_Date" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblReminder_Date" runat="server" Text='<%#Eval("Reminder_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Reminder_Date"))) : ""%>' Width="100px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Year_Remodeled" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblYear_Remodeled" runat="server" Text='<%#Eval("Year_Remodeled")%>' Width="100px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord_Notification_Date" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblLandlord_Notification_Date" runat="server" Text='<%#Eval("Landlord_Notification_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Landlord_Notification_Date"))) : ""%>' Width="200px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Regional_Vice_President" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblRegional_Vice_President" runat="server" Text='<%#Eval("Regional_Vice_President")%>' Width="150px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Regional_Controller" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblRegional_Controller" runat="server" Text='<%#Eval("Regional_Controller")%>' Width="150px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Vacate_Date" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblVacate_Date" runat="server" Text='<%#Eval("Vacate_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Vacate_Date"))) : ""%>' Width="100px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="General_Manager" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblGeneral_Manager" runat="server" Text='<%#Eval("General_Manager")%>' Width="120px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Primary_Use" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblPrimary_Use" runat="server" Text='<%#Eval("Primary_Use")%>' Width="120px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Controller" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblController" runat="server" Text='<%#Eval("Controller")%>' Width="110px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Lease_Codes" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblLease_Codes" runat="server" Text='<%#Eval("Lease_Codes")%>' Width="120px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Loss_Control_Manager" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblLoss_Control_Manager" runat="server" Text='<%#Eval("Loss_Control_Manager")%>' Width="200px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total_Acres" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblTotal_Acres" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Total_Acres")).Replace(".00", "")%>' Width="130px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Number_of_Buildings" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblNumber_of_Buildings" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Number_of_Buildings")).Replace(".00", "")%>' Width="150px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total_Gross_Leaseable_Area" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblTotal_Gross_Leaseable_Area" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Total_Gross_Leaseable_Area")).Replace(".00", "")%>' Width="210px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Land_Value" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblLand_Value" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Land_Value")).Replace(".00", "")%>' Width="130px" ></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amendment_Info" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblAmendment_Info" runat="server" Text='<%# Eval("Amendment_Info")%>' Width="300px" CssClass="TextClip"></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Assignment_Info" >
                                 <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblAssignment_Info" runat="server" Text='<%# Eval("Assignment_Info")%>' Width="300px" CssClass="TextClip"></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="HVAC Repairs" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                             <asp:Label ID="lblFK_HVAC_Repairs" runat="server" Text='<%# Eval("FK_HVAC_Repairs")%>' Width="200px"></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="HVAC Capital" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblFK_HVAC_Capital" runat="server" Text='<%# Eval("FK_HVAC_Capital")%>' Width="200px"></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Roof Repairs" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblFK_Roof_Repairs" runat="server" Text='<%# Eval("FK_Roof_Repairs")%>' Width="200px"></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Roof Capital" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblFK_Roof_Capital" runat="server" Text='<%# Eval("FK_Roof_Capital")%>' Width="200px"></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Other Repairs" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblOtherRepairs" runat="server" Text='<%# Eval("Other_Repairs")%>' Width="300px" CssClass="TextClip"></asp:Label>
	                            </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Maintenance Notes" >
	                            <ItemStyle CssClass="cols" />
	                            <ItemTemplate>
		                            <asp:Label ID="lblMaintenance_Notes" runat="server" Text='<%# Eval("Maintenance_Notes")%>' Width="300px" CssClass="TextClip"></asp:Label>
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
