<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_CRM_NonCustomer.aspx.cs" Inherits="SONIC_CRM_AuditPopup_CRM_NonCustomer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: CRM Non Customer Audit Trail</title>
</head>
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
                <div style="overflow: hidden; width: 600px;" id="divNonCustomer_Header"
                    runat="server">
                    <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;">
                        <tbody>
                            <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                align="left">
                                <th class="cols">
                                    <span style="display: inline-block; width: 110px;">Audit DateTime</span>
                                </th>
                               <%-- <th class="cols">
                                    <span style="display: inline-block; width: 170px;">PK_CRM_Non_Customer</span>
                                </th>--%>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Contact Number</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 120px;">Date of Contact</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Source</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 140px;">Location D/B/A </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 140px;">Company Name</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Last Name</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">First Name </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">City </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">State</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">ZIP </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 160px;">Email </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Home Telephone</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Cell Telephone</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Work Telephone </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 170px;">Work Telephone Extension </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Comment/Call/Inquiry Summary </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Media Call Response Summary </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Action Summary </span>
                                </th> 
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Category </span>
                                </th>             
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Response Sent?  </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Method of Response </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Date Response Sent  </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Response N/A?  </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Days to Close  </span>
                                </th>                  
                                <th class="cols">
                                    <span style="display: inline-block; width: 130px;">Updated By</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 167px;">Update Date</span>
                                </th>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div style="overflow: scroll; width: 600px; height: 500px;" id="divNonCustomer_Grid"
                    runat="server">
                    <asp:GridView ID="gvNonCustomer" runat="server" AutoGenerateColumns="False"
                        CellPadding="4" EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
                        <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <Columns>
                            <asp:TemplateField HeaderText="Audit_DateTime" SortExpression="Audit_DateTime">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                        ToolTip='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                        Width="110px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           <%-- <asp:TemplateField HeaderText="PK_Franchise">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPK_Franchise" runat="server" Text='<%#Eval("PK_CRM_Non_Customer")%>' Width="170px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Customer Number">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPK_CRM_Non_Customer" runat="server" Text='<%#Eval("PK_CRM_Non_Customer")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date of Contact">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRecord_Date" runat="server" Text='<%#Eval("Record_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Record_Date"))) : ""%>'
                                        Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Source">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_CRM_Source" runat="server" Text='<%#Eval("FK_LU_CRM_Source")%>'
                                        Width="130px"></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField>
                            <asp:TemplateField HeaderText="Location D/B/A">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>                                  
                                    <asp:Label ID="lblFK_LU_Location" runat="server" Text='<%#Eval("FK_LU_Location")%>'
                                        Width="140px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Company Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCompany_Name" runat="server" Text='<%#Eval("Company_Name")%>'
                                        Width="140px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Last Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                   <asp:Label ID="lblLast_Name" runat="server" Text='<%#Eval("Last_Name")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="First Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFirst_Name" runat="server" Text='<%#Eval("First_Name")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="City">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCity" runat="server" Text='<%#Eval("City")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="State">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_State" runat="server" Text='<%#Eval("FK_State")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Zip">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                   <asp:Label ID="lblZip_Codee" runat="server" Text='<%#Eval("Zip_Code")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email ">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                   <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email")%>'
                                        Width="160px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Home Telephone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblHome_Telephone" runat="server" Text='<%#Eval("Home_Telephone")%>'
                                        Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cell Telephone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                   <asp:Label ID="lblCell_Telephone" runat="server" Text='<%#Eval("Cell_Telephone")%>'
                                        Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Work Telephone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblWork_Telephone" runat="server" Text='<%#Eval("Work_Telephone")%>'
                                        Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Work Telephone Extension">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                      <asp:Label ID="lblWork_Telephone_Extension" runat="server" Text='<%#Eval("Work_Telephone_Extension")%>'
                                        Width="170px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Comment_Call_Inquiry_Summary">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblComment_Call_Inquiry_Summary" runat="server" Text='<%#Eval("Comment_Call_Inquiry_Summary")%>'
                                        Width="300px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Media_Call_Response_Summary">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                       <asp:Label ID="lblMedia_Call_Response_Summary" runat="server" Text='<%#Eval("Media_Call_Response_Summary")%>'
                                        Width="300px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action_Summary">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAction_Summary" runat="server" Text='<%#Eval("Action_Summary")%>'
                                        Width="300px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Category">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                   <asp:Label ID="lblFK_LU_CRM_Category" runat="server" Text='<%#Eval("FK_LU_CRM_Category")%>'
                                        Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Response Sent">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblResponse_Sent" runat="server" Text='<%#(Eval("Response_Sent").ToString() == "Y" ? "Yes" : "No") %>'
                                        Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CRM_Response_Method">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                  <asp:Label ID="lblFK_LU_CRM_Response_Method" runat="server" Text='<%#Eval("FK_LU_CRM_Response_Method")%>'
                                        Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Response Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>                                   
                                  <asp:Label ID="lblResponse_Date" runat="server" Text='<%#Eval("Response_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Response_Date"))) : ""%>'
                                        Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Response_NA">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblResponse_NA" runat="server" Text='<%#(Eval("Response_NA").ToString() == "Y" ? "Yes" : "No") %>'
                                        Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Days To Close">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDays_To_Close" runat="server" Text='<%#Eval("Days_To_Close")%>'
                                        Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Updated_By">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdated_By" runat="server" Text='<%#Eval("Updated_By")%>' Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Update_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Update_Date" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(!string.IsNullOrEmpty(Convert.ToString(Eval("Update_Date"))) ? Convert.ToDateTime(Eval("Update_Date")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
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
