<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_Event.aspx.cs"
    Inherits="Event_AuditPopup_Event" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Risk Insurance Management System :: Event</title>
    <script language="javascript" type="text/javascript">
        function showAudit(divHeader, divGrid) {
            var divheight, i;

            divHeader.style.width = window.screen.availWidth - 225 + "px";
            divGrid.style.width = window.screen.availWidth - 225 + "px";

            divheight = divGrid.style.height;
            i = divheight.indexOf('px');

            if (i > -1)
                divheight = divheight.substring(0, i);
            if (divheight > (window.screen.availHeight - 350) && divGrid.style.height != "") {
                divGrid.style.height = window.screen.availHeight - 350;
            }
        }

        function ChangeScrollBar(f, s) {
            s.scrollTop = f.scrollTop;
            s.scrollLeft = f.scrollLeft;
        }
    </script>
</head>
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
                <div style="overflow: hidden; width: 600px;" id="divgv_Event_Header" runat="server">
                    <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;"
                        width="100%">
                        <tbody>
                            <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                align="left">
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Audit DateTime</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Event Number</span>
                                </th>
                         <%--       <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Event Type</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Event Description</span>
                                </th>--%>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Location</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Camera Name</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Camera Number</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Other Type</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Other Description</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Sonic Event</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Date Sent to Sonic</span>
                                </th>
                                 <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Investigation Report Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Event Report Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Event Occurrence Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Event Start Time</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Event End Time</span>
                                </th>
                                <%--<th class="cols">
                                    <span style="display: inline-block; width: 150px;">Date Opened</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Date Sent</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 50px;">Sonic Event</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Company</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Location</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Company Address 1</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Company Address 2</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Company City</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">State</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Company ZIP</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Company County</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Company Contact First Name</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Company Contact Middle Name</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Company Contact Last Name</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Company Contact Phone</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Company Contact Email</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Company Contact Fax</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Vehicle Number</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">VIN</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Make</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Model</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Year</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Company Titled</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">License Tag</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">State Registered</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Police Dept. Name</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Police Phone</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Police Contact First Name</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Police Contact Middle Name</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Police Contact Last Name</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Badge Number</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Facsimile</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Police Contact Cell Phone</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Address 1</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Jurisdiction</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Address 2</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Police Report Number</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Police Contact City</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Police Dept. State</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">ZIP</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Case Number</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Report Ordered Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Report Received Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Incident</span>
                                </th>--%>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Updated By</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Update Date</span>
                                </th>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div style="overflow: scroll; width: 600px; height: 425px;word-wrap: normal; word-break: break-all;" id="divgvEvent_Audit_Grid"  
                    runat="server">
                    <asp:GridView ID="gvEvent_Audit" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        CellSpacing="0" EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false"
                        Width="93%">
                        <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <Columns>
                            <asp:TemplateField HeaderText="Audit_DateTime">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Event_Number">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblEvent_Number" runat="server" Text='<%#Eval("Event_Number")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           <%-- <asp:TemplateField HeaderText="EventType">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblEventType" runat="server" Text='<%#Eval("EventType")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Event_Desc">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblEvent_Desc" runat="server" Text='<%#Eval("Event_Desc")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Location">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("Location")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Camera_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCameraName" runat="server" Text='<%#Eval("Camera_Name")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Camera_Number">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCamera_Number" runat="server" Text='<%#Eval("Camera_Number")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Camera_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblOtherEventType" runat="server" Text='<%#Eval("Other_Event_Type")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Camera_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblOtherEventDesc" runat="server" Text='<%#Eval("Other_Event_Desc")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Camera_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSonicEvent" runat="server" Text='<%#Eval("Sonic_Event")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date_Sent">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDate_Sent" runat="server" Text='<%#Eval("Date_Sent") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Sent"))) : ""%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Investigation_Report_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblInvestigation_Report_Date" runat="server" Text='<%#Eval("Investigation_Report_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Investigation_Report_Date"))) : ""%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Event_Report_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblEvent_Report_Date" runat="server" Text='<%#Eval("Event_Report_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Event_Report_Date"))) : ""%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Event_Occurence_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblEvent_Occurence_Date" runat="server" Text='<%#Eval("Event_Occurence_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Event_Occurence_Date"))) : ""%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Camera_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblEventStartTime" runat="server" Text='<%#Eval("Event_Start_Time")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Camera_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblEventEndTime" runat="server" Text='<%#Eval("Event_End_Time")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                           <%-- <asp:TemplateField HeaderText="Date_Opened">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDate_Opened" runat="server" Text='<%#Eval("Date_Opened") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Opened"))) : ""%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sonic_Event">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSonic_Event" runat="server" Text='<%#Eval("Sonic_Event")%>' Width="50px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Company">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCompany" runat="server" Text='<%#Eval("Company")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Location">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("Location")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Company_Address_1">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCompany_Address_1" runat="server" Text='<%#Eval("Company_Address_1")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Company_Address_2">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCompany_Address_2" runat="server" Text='<%#Eval("Company_Address_2")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Company_City">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCompany_City" runat="server" Text='<%#Eval("Company_City")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="State">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblState" runat="server" Text='<%#Eval("State")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Company_ZIP">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCompany_ZIP" runat="server" Text='<%#Eval("Company_ZIP")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Company_County">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCompany_County" runat="server" Text='<%#Eval("Company_County")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Company_Contact_First_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCompany_Contact_First_Name" runat="server" Text='<%#Eval("Company_Contact_First_Name")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Company_Contact_Middle_name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCompany_Contact_Middle_name" runat="server" Text='<%#Eval("Company_Contact_Middle_name")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Company_Contact_Last_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCompany_Contact_Last_Name" runat="server" Text='<%#Eval("Company_Contact_Last_Name")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Company_Contact_Phone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCompany_Contact_Phone" runat="server" Text='<%#Eval("Company_Contact_Phone")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Company_Contact_Email">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCompany_Contact_Email" runat="server" Text='<%#Eval("Company_Contact_Email")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Company_Contact_Fax">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCompany_Contact_Fax" runat="server" Text='<%#Eval("Company_Contact_Fax")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Vehicle_Number">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblVehicle_Number" runat="server" Text='<%#Eval("Vehicle_Number")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="VIN">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblVIN" runat="server" Text='<%#Eval("VIN")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Make">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblMake" runat="server" Text='<%#Eval("Make")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Model">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblModel" runat="server" Text='<%#Eval("Model")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Year">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblYear" runat="server" Text='<%#Eval("Year")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Company_Titled">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCompany_Titled" runat="server" Text='<%#Eval("Company_Titled")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="License_Tag">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLicense_Tag" runat="server" Text='<%#Eval("License_Tag")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="StateRegistered">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblStateRegistered" runat="server" Text='<%#Eval("StateRegistered")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Police_Dept_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPolice_Dept_Name" runat="server" Text='<%#Eval("Police_Dept_Name")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Police_Phone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPolice_Phone" runat="server" Text='<%#Eval("Police_Phone")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Police_Contact_First_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPolice_Contact_First_Name" runat="server" Text='<%#Eval("Police_Contact_First_Name")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Police_Contact_Middle_name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPolice_Contact_Middle_name" runat="server" Text='<%#Eval("Police_Contact_Middle_name")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Police_Contact_Last_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPolice_Contact_Last_Name" runat="server" Text='<%#Eval("Police_Contact_Last_Name")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Badge_Number">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblBadge_Number" runat="server" Text='<%#Eval("Badge_Number")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Facsimile">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFacsimile" runat="server" Text='<%#Eval("Facsimile")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Police_Contact_Cell_Phone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPolice_Contact_Cell_Phone" runat="server" Text='<%#Eval("Police_Contact_Cell_Phone")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address_1">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAddress_1" runat="server" Text='<%#Eval("Address_1")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Jurisdiction">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblJurisdiction" runat="server" Text='<%#Eval("Jurisdiction")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address_2">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAddress_2" runat="server" Text='<%#Eval("Address_2")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Police_Report_Number">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPolice_Report_Number" runat="server" Text='<%#Eval("Police_Report_Number")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Police_Contact_City">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPolice_Contact_City" runat="server" Text='<%#Eval("Police_Contact_City")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PoliceDeptState">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPoliceDeptState" runat="server" Text='<%#Eval("PoliceDeptState")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ZIP">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblZIP" runat="server" Text='<%#Eval("ZIP")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Case_Number">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCase_Number" runat="server" Text='<%#Eval("Case_Number")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Report_Ordered_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblReport_Ordered_Date" runat="server" Text='<%#Eval("Report_Ordered_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Report_Ordered_Date"))) : ""%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Report_Recieved_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblReport_Recieved_Date" runat="server" Text='<%#Eval("Report_Recieved_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Report_Recieved_Date"))) : ""%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Incident">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblIncident" runat="server" Text='<%#Eval("Incident")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Updated_By">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdated_By" runat="server" Text='<%#Eval("Updated_By")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Update_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdate_Date" runat="server" Text='<%#Eval("Update_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Update_Date"))) : ""%>'
                                        Width="133px"></asp:Label>
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
