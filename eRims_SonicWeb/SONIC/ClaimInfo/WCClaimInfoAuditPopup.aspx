<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WCClaimInfoAuditPopup.aspx.cs"
 Inherits="SONIC_ClaimInfo_WCClaimInfoAuditPopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>eRIMS Sonic :: Audit Trail</title>
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
                <div style="overflow: hidden; width: 1500px;" id="divWorkers_Comp_RMW_Audit_Header" runat="server">
                        <table cellpadding="4" cellspacing="0" style="width: 1500px; border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                    align="left">
                                    <td class="cols">
                                        <span style="display: inline-block; width: 160px">Audit_DateTime</span>
                                    </td>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">PK_Workers_Comp_RMW</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 165px">FK_Workers_Comp_Claims</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 155px">Settlement_Method</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 125px">Policy_Deductible</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 205px">Compensation_Originally_Denied</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 155px">Waive_Subrogation</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 155px">Confidentiality_Clause</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 205px">Settlement_of_Permanent_Total</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 155px">Other_Classification</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">LS_Reimbursement_Of_Cost</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px">Close_Medicals</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px">Other_Medicals</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px">Resignation</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px">Resignation_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 155px">Defense_Council_Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 125px">Claimant_Attorney</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px">Trial_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 175px">Defense_Council_Telephone</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 190px">Claimant_Attorney_Telephone</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 125px">Mediation_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 125px">Demand_Amount</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">RM_Requested_Amount</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 175px">Potential_Total_Exposure</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 60px">Settled</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">ADJ_Requested_Amount</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 135px">Authorized_Amount</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 125px">Settled_Amount</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 250px">GM_Email_To</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 90px">GM_Decision</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 135px">GM_Last_Email_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 135px">GM_Response_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 250px">CRM_Email_To</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 90px">CRM_Decision</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 140px">CRM_Last_Email_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 140px">CRM_Response_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 250px">RVP_Email_To</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 90px">RVP_Decision</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 140px">RVP_Last_Email_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 140px">RVP_Response_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 250px">CC_Email_To</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 90px">CC_Decision</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 135px">CC_Last_Email_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 135px">CC_Response_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 250px">DRM_Email_To</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 90px">DRM_Decision</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 140px">DRM_Last_Email_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 140px">DRM_Response_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 250px">CFO_Email_To</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 90px">CFO_Decision</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 140px">CFO_Last_Email_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 140px">CFO_Response_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 250px">COO_Email_To</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 90px">COO_Decision</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 140px">COO_Last_Email_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 140px">COO_Response_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 155px">Comments</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 115px">Updated_By</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 152px">Update_Date</span>
                                    </th>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                <div  style="overflow-y:scroll; width: 1500px; height: 425px;" id="divWorkers_Comp_RMW_Audit_Grid"
                        runat="server" >
                        <asp:GridView ID="gvWorkers_Comp_RMW_Audit" runat="server" AutoGenerateColumns="False" CellPadding="4"
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
                                    <asp:Label ID="PK_Workers_Comp_RMW" runat="server" Text='<%#Eval("PK_Workers_Comp_RMW")%>'
                                    Width="160px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="FK_Workers_Comp_Claims" runat="server" Text='<%#Eval("FK_Workers_Comp_Claims")%>'
                                    Width="165px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Settlement_Method" runat="server" Text='<%#Eval("Settlement_Method")%>' CssClass="TextClip"
                                    Width="155px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Policy_Deductible" runat="server" Text='<%# "$ " + Eval("Policy_Deductible")%>'
                                    Width="125px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Compensation_Originally_Denied" runat="server" Text='<%#Eval("Compensation_Originally_Denied")%>'
                                    Width="205px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Waive_Subrogation" runat="server" Text='<%#Eval("Waive_Subrogation")%>'
                                    Width="155px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Confidentiality_Clause" runat="server" Text='<%#Eval("Confidentiality_Clause")%>'
                                    Width="155px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Settlement_of_Permanent_Total" runat="server" Text='<%#Eval("Settlement_of_Permanent_Total")%>'
                                    Width="205px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Other_Classification" runat="server" Text='<%#Eval("Other_Classification")%>'
                                    Width="155px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="LS_Reimbursement_Of_Cost" runat="server" Text='<%#Eval("LS_Reimbursement_Of_Cost")%>'
                                    Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Close_Medicals" runat="server" Text='<%#Eval("Close_Medicals")%>'
                                    Width="110px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Other_Medicals" runat="server" Text='<%#Eval("Other_Medicals")%>'
                                    Width="110px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Resignation" runat="server" Text='<%#Eval("Resignation")%>'
                                    Width="110px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Resignation_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Resignation_Date"))%>'
                                    Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Defense_Council_Name" runat="server" Text='<%#Eval("Defense_Council_Name")%>'
                                    Width="155px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Claimant_Attorney" runat="server" Text='<%#Eval("Claimant_Attorney")%>'
                                    Width="125px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Trial_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Trial_Date"))%>'
                                    Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Defense_Council_Telephone" runat="server" Text='<%#Eval("Defense_Council_Telephone")%>'
                                    Width="175px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Claimant_Attorney_Telephone" runat="server" Text='<%#Eval("Claimant_Attorney_Telephone")%>'
                                    Width="190px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Mediation_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Mediation_Date"))%>'
                                    Width="125px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Demand_Amount" runat="server" Text='<%# "$ " + Eval("Demand_Amount")%>'
                                    Width="125px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="RM_Requested_Amount" runat="server" Text='<%# "$ " + Eval("RM_Requested_Amount")%>'
                                    Width="160px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Potential_Total_Exposure" runat="server" Text='<%# "$ " + Eval("Potential_Total_Exposure")%>'
                                    Width="175px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Settled" runat="server" Text='<%#Eval("Settled")%>'
                                    Width="60px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="ADJ_Requested_Amount" runat="server" Text='<%# "$ " + Eval("ADJ_Requested_Amount")%>'
                                    Width="160px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Authorized_Amount" runat="server" Text='<%# "$ " + Eval("Authorized_Amount")%>'
                                    Width="135px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Settled_Amount" runat="server" Text='<%# "$ " + Eval("Settled_Amount")%>'
                                    Width="125px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="GM_Email_To" runat="server" Text='<%#Eval("GM_Email_To")%>' CssClass="TextClip"
                                    Width="250px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="GM_Decision" runat="server" Text='<%#Eval("GM_Decision")%>'
                                    Width="90px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="GM_Last_Email_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("GM_Last_Email_Date"))%>'
                                    Width="135px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="GM_Response_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("GM_Response_Date"))%>'
                                    Width="135px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="CRM_Email_To" runat="server" Text='<%#Eval("CRM_Email_To")%>' CssClass="TextClip"
                                    Width="250px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="CRM_Decision" runat="server" Text='<%#Eval("CRM_Decision")%>'
                                    Width="90px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="CRM_Last_Email_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("CRM_Last_Email_Date"))%>'
                                    Width="140px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="CRM_Response_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("CRM_Response_Date"))%>'
                                    Width="140px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="RVP_Email_To" runat="server" Text='<%#Eval("RVP_Email_To")%>' CssClass="TextClip"
                                    Width="250px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="RVP_Decision" runat="server" Text='<%#Eval("RVP_Decision")%>'
                                    Width="90px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="RVP_Last_Email_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("RVP_Last_Email_Date"))%>'
                                    Width="140px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="RVP_Response_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("RVP_Response_Date"))%>'
                                    Width="140px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="CC_Email_To" runat="server" Text='<%#Eval("CC_Email_To")%>' CssClass="TextClip"
                                    Width="250px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="CC_Decision" runat="server" Text='<%#Eval("CC_Decision")%>'
                                    Width="90px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="CC_Last_Email_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("CC_Last_Email_Date"))%>'
                                    Width="135px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="CC_Response_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("CC_Response_Date"))%>'
                                    Width="135px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="DRM_Email_To" runat="server" Text='<%#Eval("DRM_Email_To")%>' CssClass="TextClip"
                                    Width="250px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="DRM_Decision" runat="server" Text='<%#Eval("DRM_Decision")%>'
                                    Width="90px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="DRM_Last_Email_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("DRM_Last_Email_Date"))%>'
                                    Width="140px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="DRM_Response_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("DRM_Response_Date"))%>'
                                    Width="140px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="CFO_Email_To" runat="server" Text='<%#Eval("CFO_Email_To")%>' CssClass="TextClip"
                                    Width="250px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="CFO_Decision" runat="server" Text='<%#Eval("CFO_Decision")%>'
                                    Width="90px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="CFO_Last_Email_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("CFO_Last_Email_Date"))%>'
                                    Width="140px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="CFO_Response_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("CFO_Response_Date"))%>'
                                    Width="140px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="COO_Email_To" runat="server" Text='<%#Eval("COO_Email_To")%>' CssClass="TextClip"
                                    Width="250px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="COO_Decision" runat="server" Text='<%#Eval("COO_Decision")%>'
                                    Width="90px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="COO_Last_Email_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("COO_Last_Email_Date"))%>'
                                    Width="140px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="COO_Response_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("COO_Response_Date"))%>'
                                    Width="140px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Comments" runat="server" Text='<%#Eval("Comments")%>' CssClass="TextClip"
                                    Width="155px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Updated_By" runat="server" Text='<%#Eval("User_Name")%>'
                                    Width="115px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Update_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Update_Date"))%>'
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
