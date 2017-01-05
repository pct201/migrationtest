<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopupConstruction.aspx.cs" Inherits="SONIC_Exposures_AuditPopupConstruction" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: Site Information Audit Trail</title>
    <style type="text/css">
        body {
            overflow: hidden;
        }
    </style>
</head>

<script language="javascript" type="text/javascript">
    function showAudit(divHeader, divGrid) {
        var divheight, i;

        divHeader.style.width = window.screen.availWidth - 720 + "px";
        divGrid.style.width = window.screen.availWidth - 720 + "px";

        divheight = divGrid.style.height;
        i = divheight.indexOf('px');

        if (i > -1)
            divheight = divheight.substring(0, i);
        if (divheight > (window.screen.availHeight - 450) && divGrid.style.height != "") {
            divGrid.style.height = window.screen.availHeight - 450;
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
                <td colspan="2" align="left">
                    <div style="overflow: hidden; width: 650px;" id="divPollution" runat="server">
                        <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                    align="left">
                                    <th class="cols" align="left">
                                        <span style="display: inline-block; width: 110px;">Audit DateTime</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Project Number</span>
                                    </th>
                                    <%--<th class="cols">
                                        <span style="display: inline-block; width: 200px;">Building</span>
                                    </th>--%>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Project Type</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Estimated Start Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Estimated Complete Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Location</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Project Description</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Updated by</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Updated date</span>
                                    </th>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="overflow: scroll; width: 600px; height: 380px;" id="divPollution_Grid"
                        runat="server">
                        <asp:GridView ID="gvSIUtilityProvider" runat="server" AutoGenerateColumns="False"
                            CellPadding="4" EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
                            <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <Columns>
                                <asp:TemplateField HeaderText="Audit DateTime">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAuditDateTime" runat="server" Text='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            ToolTip='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            Width="110px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lbProjectNumber" runat="server" Text='<%#Eval("Project_Number")%>' style="word-wrap:break-word;"
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lbBuliding" runat="server" Text='<%#Eval("Building_Number")%>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lbProjectType" runat="server" Text='<%#Eval("Type_Description")%>' CssClass="TextClip"
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lbEstimatedStartDate" runat="server" Text='<%# DBNull.Value.Equals(Eval("Estimated_Start_Date")) ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Estimated_Start_Date"))) %>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lbEstimatedCompleteDate" runat="server" Text='<%# DBNull.Value.Equals(Eval("Estimated_Completion_Date")) ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Estimated_Completion_Date"))) %>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lbSonicLocationCode" runat="server" Text='<%#Eval("Sonic_Location_Code")%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lbProjectDescription" runat="server" Text='<%#Eval("Project_Description")%>' CssClass="TextClip"
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Updated By">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblUpdatedBy" runat="server" Text='<%#Eval("Updated_By")%>' Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Update Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblUpdateDate" runat="server" Text='<%#Eval("UpdatedDate")!= DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("UpdatedDate"))) : ""%>'
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
