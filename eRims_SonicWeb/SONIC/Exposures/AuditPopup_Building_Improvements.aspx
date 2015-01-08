﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_Building_Improvements.aspx.cs" Inherits="SONIC_Exposures_AuditPopup_Building_Improvements" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: Building_Improvements Audit Trail</title>
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
                                    <th class="cols">
                                    <th class="cols">
                                    <th class="cols">
                                    <th class="cols">
                                    <th class="cols">
                                    <th class="cols">
                                    <th class="cols">
                                    <th class="cols">
                                    <th class="cols">
                                    <th class="cols">
                                    <th class="cols">
                                    <th class="cols">
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="overflow: scroll; width: 600px; height: 425px;" id="dvGrid" runat="server">
                        <asp:GridView ID="gvBuildingImprovements" runat="server" AutoGenerateColumns="False"
                            CellPadding="4" EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
                            <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <Columns>
                                <asp:TemplateField HeaderText="Audit_DateTime" >
                                <asp:TemplateField HeaderText="PK_Building_Improvements" >
                                <asp:TemplateField HeaderText="FK_Building" >
                                <asp:TemplateField HeaderText="Improvement_Description" >
                                <asp:TemplateField HeaderText="Service_Capacity_Increase" >
                                <asp:TemplateField HeaderText="Revised_Square_Footage_Sales" >
                                <asp:TemplateField HeaderText="Revised_Square_Footage_Service" >
                                <asp:TemplateField HeaderText="Revised_Square_Footage_Parts" >
                                <asp:TemplateField HeaderText="Revised_Square_Footage_Other" >
                                <asp:TemplateField HeaderText="Improvement_Value" >
                                <asp:TemplateField HeaderText="Completion_Date" >
                                <asp:TemplateField HeaderText="Updated_By" >
                                <asp:TemplateField HeaderText="Updated_Date" >
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>