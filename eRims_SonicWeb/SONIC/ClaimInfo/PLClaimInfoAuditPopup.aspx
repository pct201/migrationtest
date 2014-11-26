<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PLClaimInfoAuditPopup.aspx.cs" Inherits="SONIC_ClaimInfo_PLClaimInfoAuditPopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: Premises_Loss_RMW_Audit Audit Trail</title>
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
                <div style="overflow: hidden; width: 1500px;" id="divPremises_Loss_RMW_Audit_Header" runat="server">
                        <table cellpadding="4" cellspacing="0" style="width: 1500px; border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                    align="left">
                                    <td class="cols">
                                        <span style="display: inline-block; width: 160px">Audit_DateTime</span>
                                    </td>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">PK_Premises_Loss_RMW</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 165px">FK_Premises_Loss_Claims</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 155px">Claimant_Customer</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 140px">Claimant_Third_Party</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 205px">Liability_Analysis</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 60px">Demand</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 155px">Claimant_Counsel_Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 155px">Plantiff_Counsel_Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px">Property_Damaged</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 205px">Property_Damages_Description</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px">Damage_Amount</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px">Bodily_Injury</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 125px">Injury_Description</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 195px">Medical_Treatment_Description</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px">Medical_Cost</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 125px">Requested_Amount</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Potential_Total_Exposure</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 60px">Settled</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px">Settled_Amount</span>
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
                                        <span style="display: inline-block; width: 250px">AGC_Email_To</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 90px">AGC_Decision</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 140px">AGC_Last_Email_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 140px">AGC_Response_Date</span>
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
                                        <span style="display: inline-block; width: 250px">President_Email_To</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px">President_Decision</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 175px">President_Last_Email_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 175px">President_Response_Date</span>
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
                <div  style="overflow-y:scroll; width: 1500px; height: 425px;" id="divPremises_Loss_RMW_Audit_Grid"
                        runat="server" >
                        <asp:GridView ID="gvPremises_Loss_RMW_Audit" runat="server" AutoGenerateColumns="False" CellPadding="4"
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
                                    <asp:Label ID="PK_Premises_Loss_RMW" runat="server" Text='<%#Eval("PK_Premises_Loss_RMW")%>'
                                    Width="160px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="FK_Premises_Loss_Claims" runat="server" Text='<%#Eval("FK_Premises_Loss_Claims")%>'
                                    Width="165px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Claimant_Customer" runat="server" Text='<%#Eval("Claimant_Customer")%>' CssClass="TextClip"
                                    Width="155px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="Claimant_Third_Party" runat="server" Text='<%#Eval("Claimant_Third_Party")%>'
                                    Width="140px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Liability_Analysis" runat="server" Text='<%#Eval("Liability_Analysis")%>' CssClass="TextClip"
                                    Width="205px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Demand" runat="server" Text='<%#Eval("Demand")%>'
                                    Width="60px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Claimant_Counsel_Name" runat="server" Text='<%#Eval("Claimant_Counsel_Name")%>'
                                    Width="155px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Plantiff_Counsel_Name" runat="server" Text='<%#Eval("Plantiff_Counsel_Name")%>'
                                    Width="155px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Property_Damaged" runat="server" Text='<%#Eval("Property_Damaged")%>'
                                    Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Property_Damages_Description" runat="server" Text='<%#Eval("Property_Damages_Description")%>' CssClass="TextClip"
                                    Width="205px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Damage_Amount" runat="server" Text='<%#Eval("Damage_Amount")%>'
                                    Width="110px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Bodily_Injury" runat="server" Text='<%#Eval("Bodily_Injury")%>'
                                    Width="110px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Injury_Description" runat="server" Text='<%#Eval("Injury_Description")%>'
                                    Width="125px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Medical_Treatment_Description" runat="server" Text='<%#Eval("Medical_Treatment_Description")%>' CssClass="TextClip"
                                    Width="195px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Medical_Cost" runat="server" Text='<%# "$ " + Eval("Medical_Cost")%>'
                                    Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Requested_Amount" runat="server" Text='<%# "$ " + Eval("Requested_Amount")%>'
                                    Width="125px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="Potential_Total_Exposure" runat="server" Text='<%# "$ " + Eval("Potential_Total_Exposure")%>'
                                    Width="160px"></asp:Label>
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
                                <asp:Label ID="Settled_Amount" runat="server" Text='<%# "$ " + Eval("Settled_Amount")%>'
                                    Width="110px"></asp:Label>
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
                                <asp:Label ID="AGC_Email_To" runat="server" Text='<%#Eval("AGC_Email_To")%>' CssClass="TextClip"
                                    Width="250px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="AGC_Decision" runat="server" Text='<%#Eval("AGC_Decision")%>'
                                    Width="90px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="AGC_Last_Email_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("AGC_Last_Email_Date"))%>'
                                    Width="140px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="AGC_Response_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("AGC_Response_Date"))%>'
                                    Width="140px"></asp:Label>
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
                                <asp:Label ID="President_Email_To" runat="server" Text='<%#Eval("President_Email_To")%>' CssClass="TextClip"
                                    Width="250px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="President_Decision" runat="server" Text='<%#Eval("President_Decision")%>'
                                    Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="President_Last_Email_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("President_Last_Email_Date"))%>'
                                    Width="175px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                <asp:Label ID="President_Response_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("President_Response_Date"))%>'
                                    Width="175px"></asp:Label>
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
