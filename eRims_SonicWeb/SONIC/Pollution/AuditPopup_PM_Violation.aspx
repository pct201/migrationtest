<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_PM_Violation.aspx.cs"
    Inherits="SONIC_Pollution_AuditPopup_PM_Violation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: PM Violation Audit Trail</title>
</head>
<script language="javascript" type="text/javascript">
    function showAudit(divHeader, divGrid) {
        var divheight, i;

        divHeader.style.width = window.screen.availWidth - 525;
        divGrid.style.width = window.screen.availWidth - 525;

        divheight = divGrid.style.height;
        i = divheight.indexOf('px');

        if (i > -1)
            divheight = divheight.substring(0, i);
        if (divheight > (window.screen.availHeight - 500) && divGrid.style.height != "") {
            divGrid.style.height = window.screen.availHeight - 500;
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
                <div style="overflow: hidden; width: 300px;" id="divPM_Permits_Header" runat="server">
                    <table cellpadding="4" cellspacing="0" style="width: 300px; border-collapse: collapse;">
                        <tbody>
                            <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                align="left">
                                <th class="cols">
                                    <span style="display: inline-block; width: 110px;">Audit DateTime</span>
                                </th>                               
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Date Of Violation</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Regulatory/Notifying Agency </span>
                                </th>                               
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">If Other, Please Specify </span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Contact Name</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Contact Telephone</span>
                                </th>
                                 <th class="cols" >
                                    <span style="display: inline-block; width: 150px;">Is this a Repeat Violation?</span>
                                </th>
                                <th class="cols" align="right">
                                    <span style="display: inline-block; width: 100px;">Fine</span>
                                </th>
                                <th class="cols" align="right">
                                    <span style="display: inline-block; width: 100px;">Remediation Cost</span>
                                </th>
                                <th class="cols" align="right">
                                    <span style="display: inline-block; width: 100px;">Purchase of New Equipment</span>
                                </th>
                                <th class="cols" align="right">
                                    <span style="display: inline-block; width: 100px;">Consulting Fees</span>
                                </th>
                                <th class="cols" align="right">
                                    <span style="display: inline-block; width: 100px;">Attorney Fees</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Description Of Violations</span>
                                </th>
                                <th class="cols" align="right">
                                    <span style="display: inline-block; width: 100px;">Additional Costs</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 180px;">Describe What Additional Costs relate to</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Updated By</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 117px;">Update Date</span>
                                </th>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div style="overflow: scroll; width: 300px; height: 400px;" id="divPM_Permits_Grid"
                    runat="server">
                    <asp:GridView ID="gvSIUtilityProvider" runat="server" AutoGenerateColumns="False"
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
                            <asp:TemplateField HeaderText="Date_Of_Violation">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                      <asp:Label ID="lblDate_Of_Violation" runat="server" Text='<%#Eval("Date_Of_Violation") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Of_Violation"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_LU_Regulatory_Notifying_Agency">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                   <asp:Label ID="lblFK_LU_Regulatory_Notifying_Agency" runat="server" Text='<%#Eval("FK_LU_Regulatory_Notifying_Agency")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                          
                            <asp:TemplateField HeaderText="Other_Agency">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                   <asp:Label ID="lblOther_Agency" runat="server" Text='<%#Eval("Other_Agency")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblContact_Name" runat="server" Text='<%#Eval("Contact_Name")%>' Width="100px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact_Telephone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                 <asp:Label ID="lblContact_Telephone" runat="server" Text='<%#Eval("Contact_Telephone")%>' Width="100px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Repeat_Violation">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                   <asp:Label ID="lblRepeat_Violation" runat="server" Text='<%#Eval("Repeat_Violation")%>' Width="150px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fine">
                                <ItemStyle CssClass="cols" HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCost" runat="server" Text='<%#string.Format("{0:C2}", Eval("Cost"))%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Remediation_Cost">
                                <ItemStyle CssClass="cols" HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRemediation_Cost" runat="server" Text='<%#string.Format("{0:C2}", Eval("Remediation_Cost"))%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="New_Equipment">
                                <ItemStyle CssClass="cols" HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblNew_Equipment" runat="server" Text='<%#string.Format("{0:C2}", Eval("New_Equipment"))%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="consulting_Fees">
                                <ItemStyle CssClass="cols" HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblconsulting_Fees" runat="server" Text='<%#string.Format("{0:C2}", Eval("consulting_Fees"))%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Attorney_Fees">
                                <ItemStyle CssClass="cols" HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAttorney_Fees" runat="server" Text='<%#string.Format("{0:C2}", Eval("Attorney_Fees"))%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description_Of_Violations">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDescription_Of_Violations" runat="server" Text='<%#Eval("Description_Of_Violations")%>' Width="100px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Additional Costs">
                                <ItemStyle CssClass="cols" HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCost" runat="server" Text='<%#string.Format("{0:C2}", Eval("Additional_Costs"))%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                           
                            <asp:TemplateField HeaderText="Additional_Costs_Description">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDescription_Of_Violations" runat="server" Text='<%#Eval("Additional_Costs_Description")%>' Width="180px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Updated_By">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdated_By" runat="server" Text='<%#Eval("Updated_By1")%>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Update_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdate_Date" runat="server" Text='<%#Eval("Update_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Update_Date"))) : ""%>'
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
