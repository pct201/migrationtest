<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_Sedgwick_Claim_Review_Audit.aspx.cs" Inherits="SONIC_Sedgwick_AuditPopup_Sedgwick_Claim_Review_Audit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: Sedgwick Claim Review Audit Trail</title>
</head>
<script language="javascript" type="text/javascript">
    function showAudit(divHeader, divGrid) {
        var divheight, i;

        divHeader.style.width = window.screen.availWidth - 419 + "px";
        divGrid.style.width = window.screen.availWidth - 419 + "px";

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
                <div style="overflow: hidden; width: 675px;" id="divSedgwick_Claim_ReviewHeader" runat="server">
                    <table cellpadding="4" cellspacing="0" style="width: 625px; border-collapse: collapse;">
                        <tbody>
                            <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                align="left">
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Audit_DateTime</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px;">PK_Sedgwick_Claim_Review</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Date Of Last Review</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Adjuster</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 175px;">Sedgwick Team Leader</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Claim Review Complete</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Medical Score</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Diability Score</span>
                                </th>
                                                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Litigation Score</span>
                                </th>
                                                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Settlemente Closure Score</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Subrogation Score</span>
                                </th>
                                 <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Reserves Score</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Leadership Score</span>
                                </th>
                                 <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Numeric Score</span>
                                </th>
                                 <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Overall Comments</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Broker Claim Comments</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">FK_Employee_Id</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Updated_By</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 117px;">Update_Date</span>
                                </th>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div style="overflow: scroll; width: 625px; height: 425px;" id="divSedgwick_Claim_Review_Grid"
                    runat="server">
                    <asp:GridView ID="gvSIUtilityProvider" runat="server" AutoGenerateColumns="False"
                        CellPadding="4" EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
                        <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <Columns>
                            <asp:TemplateField HeaderText="Audit_DateTime">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAudit_DateTime" runat="server"
                                        Text='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                        ToolTip='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PK_Sedgwick_Claim_Review">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPK_Sedgwick_Claim_Review" runat="server" Text='<%#Eval("PK_Sedgwick_Claim_Review")%>'
                                        Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date Of Last Review">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDate_Of_Last_Review" runat="server" Text='<%#Eval("Date_Of_Last_Review") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Of_Last_Review"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Adjuster">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAdjuster" runat="server" Text='<%#Eval("Adjuster")%>' Width="150px"
                                        CssClass="TextClip" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sedgwick Team Leader">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSedgwick_Team_Leader" runat="server" Text='<%#Eval("Sedgwick_Team_Leader")%>' Width="175px"
                                        CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Claim_Review_Complete">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblClaim_Review_Complete" runat="server" Text='<%#Eval("Claim_Review_Complete")%>' Width="100px"
                                       ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Medical_Score">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblMedical_Score" runat="server" Text='<%#Eval("Medical_Score")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Diability_Score">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDiability_Score" runat="server" Text='<%#Eval("Diability_Score")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Litigation_Score">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLitigation_Score" runat="server" Text='<%#Eval("Litigation_Score")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Settlemente_Closure_Score">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSettlemente_Closure_Score" runat="server" Text='<%#Eval("Settlemente_Closure_Score")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subrogation_Score">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSubrogation_Score" runat="server" Text='<%#Eval("Subrogation_Score")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Reserves_Score">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblReserves_Score" runat="server" Text='<%#Eval("Reserves_Score")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Leadership_Score">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLeadership_Score" runat="server" Text='<%#Eval("Leadership_Score")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Numeric_Score">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblNumeric_Score" runat="server" Text='<%#Eval("Numeric_Score")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Overall_Comments">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblOverall_Comments" runat="server" Text='<%#Eval("Overall_Comments")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Broker_Claim_Comments">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblBroker_Claim_Comments" runat="server" Text='<%#Eval("Broker_Claim_Comments")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="FK_Employee_Id">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_Employee_Id" runat="server" Text='<%#Eval("FK_Employee_Id")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Updated_By">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdated_By" runat="server" Text='<%#Eval("Updated_By")%>' Width="100px"></asp:Label>
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