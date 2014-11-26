<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_ExecutiveRisk.aspx.cs"
    Inherits="ExecutiveRisk_AuditPopup_ExecutiveRisk" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: Executive_Risk Audit Trail</title>
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
                    <div style="overflow: hidden; width: 600px;" id="divExecutive_Risk_Header" runat="server">
                        <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                    align="left" id="trHeader">
                                    <td class="cols">
                                        <span style="display: inline-block; width: 110px">Audit_DateTime</span>
                                    </td>
                                    <th style="width: 130px" class="cols">
                                        <span style="display: inline-block; width: 125px">PK_Executive_Risk</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Claim_Type_Other</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Type_Of_ER_Allegation</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Legal_File_Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px">Claim_Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">FK_Entity</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">FK_Type_Of_ER_Claim</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Complainant_Plaintiff</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Defendant</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 600px">Claim_Description</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px">Claim_Open_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px">Claim_Close_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px">Claim_Reopen_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px">Bordereau_Report</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 600px">Claim_Status_Comments</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 80px">EEOC</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 210px">State_Employment_Commission</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 225px">Representation_Letter_Received</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 250px">Date_Representation_Letter_Received</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px">Security_Litigation</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px">Other_Litigation</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Jurisdiction</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px">Date_Complaint_Suit_Filed</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 170px">Date_Suite_Served</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Case_Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 215px">Primary_Insurance_Claim_Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 225px">Primary_Insurance_Policy_Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px">Primary_Policy_Effective_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 210px">Primary_Policy_Expiration_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Total_Program_Limit</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Primary_Deductable</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 120px">Allocation</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 185px">Date_Alleged_Wrongful_Act</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 165px">Date_Complaint_Received</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 210px">Date_Legal_Received_Complaint</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 300px">Date_Risk_Management_Received_Complaint</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 215px">Date_Broker_Received_Complaint</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Date_Carrier_Notified</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 265px">Date_Acknowledgement_Primary_Carrier</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Internal_Counsel</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 125px">Legal_Telephone</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 165px">Panel_Counsel_Required</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 190px">Primary_Defense_File_Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 210px">Secondary_Defense_File_Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Court</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px">Judge_Arbitrator</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 600px">Legal_Status</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 190px">Estimated_Demand_Exposure</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Demand_Exposure_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 190px">Estimated_Defense_Expense</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 225px">Estimated_Defense_Expense_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 125px">Actual_Settlement</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 170px">Actual_Settlement_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 170px">Actual_Defense_Expense</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px">Actual_Defense_Expense_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 600px">Comments</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 170px">Legal_Complaint_Recipient</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 190px">Date_HR_Received_Compliant</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 170px">HR_Complaint_Recipient</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px">Updated_By</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 117px">Update_Date</span>
                                    </th>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="overflow: scroll; width: 600px; height: 425px;" id="divExecutive_Risk_Grid"
                        runat="server">
                        <asp:GridView ID="gvExecutive_Risk" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
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
                                <asp:TemplateField HeaderText="PK_Executive_Risk" SortExpression="PK_Executive_Risk">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="PK_Executive_Risk" runat="server" Text='<%# Bind("PK_Executive_Risk") %>'
                                            Width="125px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Claim_Type_Other" SortExpression="Claim_Type_Other">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Claim_Type_Other" runat="server" Text='<%# Bind("Claim_Type_Other") %>' Width="150"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Type_Of_ER_Allegation" SortExpression="Type_Of_ER_Allegation">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblType_Of_ER_Allegation" runat="server" Text='<%# Bind("Type_Of_ER_Allegation") %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Legal_File_Number" SortExpression="Legal_File_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblLegal_File_Number" runat="server" Text='<%# Bind("Legal_File_Number") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Claim_Number" SortExpression="Claim_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Claim_Number" runat="server" Text='<%# Bind("Claim_Number") %>' Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_Entity" SortExpression="FK_Entity">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="FK_Entity" runat="server" Text='<%# Bind("Entity") %>' Width="150"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_Type_Of_ER_Claim" SortExpression="FK_Type_Of_ER_Claim">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Type_Of_ER_Claim") %>' Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Complainant_Plaintiff" SortExpression="Complainant_Plaintiff">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Complainant_Plaintiff" runat="server" Text='<%# Bind("Complainant_Plaintiff") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Defendant" SortExpression="Defendant">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Defendant" runat="server" Text='<%# Bind("Defendant") %>' Width="150px"> </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Claim_Description" SortExpression="Claim_Description">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Claim_Description" runat="server" Text='<%# Bind("Claim_Description") %>'
                                            Width="600px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Claim_Open_Date" SortExpression="Claim_Open_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Claim_Open_Date" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Eval("Claim_Open_Date") != DBNull.Value  ? Convert.ToDateTime(Eval("Claim_Open_Date")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Claim_Close_Date" SortExpression="Claim_Close_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Claim_Close_Date" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Eval("Claim_Close_Date") != DBNull.Value  ? Convert.ToDateTime(Eval("Claim_Close_Date")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Claim_Reopen_Date" SortExpression="Claim_Reopen_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Claim_Reopen_Date" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Eval("Claim_Reopen_Date") != DBNull.Value  ? Convert.ToDateTime(Eval("Claim_Reopen_Date")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bordereau_Report" SortExpression="Bordereau_Report">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Bordereau_Report" runat="server" Text='<%# (Eval("Bordereau_Report").ToString() == "Y") ? "Yes" : "No" %>'
                                            Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Claim_Status_Comments" SortExpression="Claim_Status_Comments">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Claim_Status_Comments" runat="server" Text='<%# Bind("Claim_Status_Comments") %>'
                                            CssClass="TextClip" Width="600px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="EEOC" SortExpression="EEOC">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="EEOC" runat="server" Text='<%# (Eval("EEOC").ToString() == "Y") ? "Yes" : "No" %>'
                                            Width="80px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="State_Employment_Commission" SortExpression="State_Employment_Commission">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="State_Employment_Commission" runat="server" Text='<%# Bind("State_Employment_Commission") %>'
                                            Width="210px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Representation_Letter_Received" SortExpression="Representation_Letter_Received">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Representation_Letter_Received" runat="server" Text='<%# (Eval("Representation_Letter_Received").ToString() == "Y") ? "Yes" : "No" %>'
                                            Width="225px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Representation_Letter_Received" SortExpression="Date_Representation_Letter_Received">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Date_Representation_Letter_Received" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Eval("Date_Representation_Letter_Received") != DBNull.Value  ? Convert.ToDateTime(Eval("Date_Representation_Letter_Received")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="250px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Security_Litigation" SortExpression="Security_Litigation">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Security_Litigation" runat="server" Text='<%# (Eval("Security_Litigation").ToString() == "Y") ? "Yes" : "No" %>'
                                            Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Other_Litigation" SortExpression="Other_Litigation">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Other_Litigation" runat="server" Text='<%# (Eval("Other_Litigation").ToString() == "Y") ? "Yes" : "No" %>'
                                            Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Jurisdiction" SortExpression="Jurisdiction">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Jurisdiction" runat="server" Text='<%# Bind("Jurisdiction") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Complaint_Suit_Filed" SortExpression="Date_Complaint_Suit_Filed">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Date_Complaint_Suit_Filed" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Eval("Date_Complaint_Suit_Filed") != DBNull.Value  ? Convert.ToDateTime(Eval("Date_Complaint_Suit_Filed")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Suite_Served" SortExpression="Date_Suite_Served">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Date_Suite_Served" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Eval("Date_Suite_Served") != DBNull.Value  ? Convert.ToDateTime(Eval("Date_Suite_Served")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="170px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Case_Number" SortExpression="Case_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Case_Number" runat="server" Text='<%# Bind("Case_Number") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Primary_Insurance_Claim_Number" SortExpression="Primary_Insurance_Claim_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Primary_Insurance_Claim_Number" runat="server" Text='<%# Bind("Primary_Insurance_Claim_Number") %>'
                                            Width="215px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Primary_Insurance_Policy_Number" SortExpression="Primary_Insurance_Policy_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Primary_Insurance_Policy_Number" runat="server" Text='<%# Bind("Primary_Insurance_Policy_Number") %>'
                                            Width="225px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Primary_Policy_Effective_Date" SortExpression="Primary_Policy_Effective_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Primary_Policy_Effective_Date" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Eval("Primary_Policy_Effective_Date") != DBNull.Value  ? Convert.ToDateTime(Eval("Primary_Policy_Effective_Date")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Primary_Policy_Expiration_Date" SortExpression="Primary_Policy_Expiration_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Primary_Policy_Expiration_Date" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Eval("Primary_Policy_Expiration_Date") != DBNull.Value  ? Convert.ToDateTime(Eval("Primary_Policy_Expiration_Date")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="210px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total_Program_Limit" SortExpression="Total_Program_Limit">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Total_Program_Limit" runat="server" Text='<%# clsGeneral.GetStringValue(Convert.ToDecimal(Eval("Total_Program_Limit")))  %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Primary_Deductable" SortExpression="Primary_Deductable">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Primary_Deductable" runat="server" Text='<%# clsGeneral.GetStringValue(Convert.ToDecimal(Eval("Primary_Deductable")))  %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Allocation" SortExpression="Allocation">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Allocation" runat="server" Text='<%# clsGeneral.GetStringValue(Convert.ToDecimal(Eval("Allocation")))  %>'
                                            Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Alleged_Wrongful_Act" SortExpression="Date_Alleged_Wrongful_Act">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Date_Alleged_Wrongful_Act" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Eval("Date_Alleged_Wrongful_Act") != DBNull.Value  ? Convert.ToDateTime(Eval("Date_Alleged_Wrongful_Act")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="185px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Complaint_Received" SortExpression="Date_Complaint_Received">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Date_Complaint_Received" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Eval("Date_Complaint_Received") != DBNull.Value  ? Convert.ToDateTime(Eval("Date_Complaint_Received")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="165px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Legal_Received_Complaint" SortExpression="Date_Legal_Received_Complaint">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Date_Legal_Received_Complaint" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Eval("Date_Legal_Received_Complaint") != DBNull.Value  ? Convert.ToDateTime(Eval("Date_Legal_Received_Complaint")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="210px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Risk_Management_Received_Complaint" SortExpression="Date_Risk_Management_Received_Complaint">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Date_Risk_Management_Received_Complaint" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Eval("Date_Risk_Management_Received_Complaint") != DBNull.Value  ? Convert.ToDateTime(Eval("Date_Risk_Management_Received_Complaint")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="300px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Broker_Received_Complaint" SortExpression="Date_Broker_Received_Complaint">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Date_Broker_Received_Complaint" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Eval("Date_Broker_Received_Complaint") != DBNull.Value  ? Convert.ToDateTime(Eval("Date_Broker_Received_Complaint")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="215px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Carrier_Notified" SortExpression="Date_Carrier_Notified">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Date_Carrier_Notified" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Eval("Date_Carrier_Notified") != DBNull.Value  ? Convert.ToDateTime(Eval("Date_Carrier_Notified")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Acknowledgement_Primary_Carrier" SortExpression="Date_Acknowledgement_Primary_Carrier">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Date_Acknowledgement_Primary_Carrier" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Eval("Date_Acknowledgement_Primary_Carrier") != DBNull.Value  ? Convert.ToDateTime(Eval("Date_Acknowledgement_Primary_Carrier")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="265px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Internal_Counsel" SortExpression="Internal_Counsel">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Internal_Counsel" runat="server" Text='<%# Bind("Internal_Counsel") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Legal_Telephone" SortExpression="Legal_Telephone">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Legal_Telephone" runat="server" Text='<%# Bind("Legal_Telephone") %>'
                                            Width="125px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Panel_Counsel_Required" SortExpression="Panel_Counsel_Required">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Panel_Counsel_Required" runat="server" Text='<%# (Eval("Panel_Counsel_Required").ToString() == "Y") ? "Yes" : "No" %>'
                                            Width="165px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Primary_Defense_File_Number" SortExpression="Primary_Defense_File_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Primary_Defense_File_Number" runat="server" Text='<%# Bind("Primary_Defense_File_Number") %>'
                                            Width="190px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Secondary_Defense_File_Number" SortExpression="Secondary_Defense_File_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Secondary_Defense_File_Number" runat="server" Text='<%# Bind("Secondary_Defense_File_Number") %>'
                                            Width="210px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Court" SortExpression="Court">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Court" runat="server" Text='<%# Bind("Court") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Judge_Arbitrator" SortExpression="Judge_Arbitrator">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Judge_Arbitrator" runat="server" Text='<%# Bind("Judge_Arbitrator") %>'
                                            Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Legal_Status" SortExpression="Legal_Status">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Legal_Status" runat="server" Text='<%# Bind("Legal_Status") %>' Width="600px"
                                            CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estimated_Demand_Exposure" SortExpression="Estimated_Demand_Exposure">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Estimated_Demand_Exposure" runat="server" Text='<%# clsGeneral.GetStringValue(Convert.ToDecimal(Eval("Estimated_Demand_Exposure")))  %>'
                                            Width="190px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Demand_Exposure_Date" SortExpression="Demand_Exposure_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Demand_Exposure_Date" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Eval("Demand_Exposure_Date") != DBNull.Value  ? Convert.ToDateTime(Eval("Demand_Exposure_Date")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estimated_Defense_Expense" SortExpression="Estimated_Defense_Expense">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Estimated_Defense_Expense" runat="server" Text='<%# clsGeneral.GetStringValue(Convert.ToDecimal(Eval("Estimated_Defense_Expense")))  %>'
                                            Width="190px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estimated_Defense_Expense_Date" SortExpression="Estimated_Defense_Expense_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Estimated_Defense_Expense_Date" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Eval("Estimated_Defense_Expense_Date") != DBNull.Value  ? Convert.ToDateTime(Eval("Estimated_Defense_Expense_Date")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="225px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Actual_Settlement" SortExpression="Actual_Settlement">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Actual_Settlement" runat="server" Text='<%# clsGeneral.GetStringValue(Convert.ToDecimal(Eval("Actual_Settlement")))  %>'
                                            Width="125px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Actual_Settlement_Date" SortExpression="Actual_Settlement_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Actual_Settlement_Date" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Eval("Actual_Settlement_Date") != DBNull.Value  ? Convert.ToDateTime(Eval("Actual_Settlement_Date")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="170px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Actual_Defense_Expense" SortExpression="Actual_Defense_Expense">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Actual_Defense_Expense" runat="server" Text='<%# clsGeneral.GetStringValue(Convert.ToDecimal(Eval("Actual_Defense_Expense")))  %>'
                                            Width="170"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Actual_Defense_Expense_Date" SortExpression="Actual_Defense_Expense_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Actual_Defense_Expense_Date" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Eval("Actual_Defense_Expense_Date") != DBNull.Value  ? Convert.ToDateTime(Eval("Actual_Defense_Expense_Date")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Comments" SortExpression="Comments">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Comments" runat="server" Text='<%# Bind("Comments") %>' Width="600px"
                                            CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Legal_Complaint_Recipient" SortExpression="Legal_Complaint_Recipient">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Legal_Complaint_Recipient" runat="server" Text='<%# Bind("Legal_Complaint_Recipient") %>' Width="170px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_HR_Received_Compliant" SortExpression="Date_HR_Received_Compliant">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Date_HR_Received_Compliant" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Eval("Date_HR_Received_Compliant") != DBNull.Value  ? Convert.ToDateTime(Eval("Date_HR_Received_Compliant")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
                                         Width="190px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="HR_Complaint_Recipient" SortExpression="HR_Complaint_Recipient">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="HR_Complaint_Recipient" runat="server" Text='<%# Bind("HR_Complaint_Recipient") %>' Width="170px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Updated_By" SortExpression="Updated_By">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="User_Name" runat="server" Text='<%# Bind("User_Name") %>' Width="110px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Update_Date" SortExpression="Update_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="Update_Date" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Eval("Update_Date") != DBNull.Value  ? Convert.ToDateTime(Eval("Update_Date")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) %>'
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
