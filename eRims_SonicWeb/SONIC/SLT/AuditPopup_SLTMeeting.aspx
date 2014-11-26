<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_SLTMeeting.aspx.cs"
    Inherits="SONIC_SLT_AuditPopup_SLTMeeting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: SLT Meeting Audit Trail</title>
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
                <div style="overflow: hidden; width: 675px;" id="divSLTMeetingHeader" runat="server">
                    <table cellpadding="4" cellspacing="0" style="width: 625px; border-collapse: collapse;">
                        <tbody>
                            <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                align="left">
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Audit DateTime</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">PK_SLT_Meeting</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Location_ID</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Meeting Start Time</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Meeting End Time</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Prev Meeting Review</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Meeting Approved date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Meeting Quality</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Meeting Comments</span>
                                </th>
                                <%--
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Update_Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">UniqueVal</span>
                                </th>--%>
                                <%--<th class="cols">
                                    <span style="display: inline-block; width: 100px;">Audit_DateTime</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">PK_SLT_Safety_Walk</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">FK_SLT_Meeting</span>
                                </th>--%>
                                <%--
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Updated_By</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Update_Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">UniqueVal</span>
                                </th>--%>
                                <%--<th class="cols">
                                    <span style="display: inline-block; width: 100px;">Audit_DateTime</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">PK_SLT_Claims_Mangement</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">FK_SLT_Meeting</span>
                                </th>--%>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Lag Explaination</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Work_Status</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Light Duty Explaination</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Comments</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Updated_By</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 117px;">Update_Date</span>
                                </th>
                                <%--
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">UniqueVal</span>
                                </th>--%>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div style="overflow: scroll; width: 625px; height: 425px;" id="divSLTMeeting_Grid"
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
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PK_SLT_Meeting">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPK_SLT_Meeting" runat="server" Text='<%#Eval("PK_SLT_Meeting")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_LU_Location_ID">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_Location_ID" runat="server" Text='<%#Eval("FK_LU_Location_ID")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Meeting_Start_Time">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblMeeting_Start_Time" runat="server" Text='<%#Eval("Meeting_Start_Time")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Meeting_End_Time">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblMeeting_End_Time" runat="server" Text='<%#Eval("Meeting_End_Time")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Prev_Meeting_Review">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPrev_Meeting_Review" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplayForView(Eval("Prev_Meeting_Review"))%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Meeting_Approved_date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblMeeting_Approved_date" runat="server" Text='<%#Eval("Meeting_Approved_date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Meeting_Approved_date"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_LU_Meeting_Quality">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_Meeting_Quality" runat="server" Text='<%#Eval("FK_LU_Meeting_Quality")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Meeting Comments">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblMeeting_Comments" runat="server" Text='<%#Eval("Meeting_Comments")%>'
                                        Width="300px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Lag_Explaination">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLag_Explaination" runat="server" Text='<%#Eval("Lag_Explaination")%>'
                                        Width="100px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_LU_Work_Status">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_Work_Status" runat="server" Text='<%#Eval("FK_LU_Work_Status")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Light_Duty_Explaination">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLight_Duty_Explaination" runat="server" Text='<%#Eval("Light_Duty_Explaination")%>'
                                        Width="100px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Comments">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblComments" runat="server" Text='<%#Eval("Comments")%>' Width="300px"
                                        CssClass="TextClip"></asp:Label>
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
</html>
