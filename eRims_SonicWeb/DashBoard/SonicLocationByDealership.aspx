<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SonicLocationByDealership.aspx.cs"
    Inherits="DashBoard_SonicLocationByDealership" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sonic Location By Dealership</title>
</head>
<script type="text/javascript" language="javascript">
    function OpenBuilding_Number(Pk_Location, PK_BuildingNum) {
        window.opener.parent.parent.location = "<%= AppConfig.SiteURL%>SONIC/Exposures/Property.aspx?loc=" + Pk_Location + "&build=" + PK_BuildingNum;
        window.close();
    }

    function OpenFROIsLastMonth(strFROILasturl) {
        window.opener.parent.parent.location = "<%= AppConfig.SiteURL%>SONIC/FirstReport/" + strFROILasturl;
        window.close();
    }

    function OpenFROIsCurrMonth(strFROIsThisurl) {
        window.opener.parent.parent.location = "<%= AppConfig.SiteURL%>SONIC/FirstReport/" + strFROIsThisurl;
        window.close();
    }

    function OpenClaim(strOpenClaimurl) {
        window.opener.parent.parent.location = "<%= AppConfig.SiteURL%>SONIC/ClaimInfo/" + strOpenClaimurl;
        window.close();
    }

    function OpenInspection(PK_Inspection) {
        window.opener.parent.parent.location = "<%= AppConfig.SiteURL%>SONIC/Exposures/Inspections.aspx?loc=" + PK_Inspection;
        window.close();
    }

    function OpenLastSLTMeeting(PK_SLTMeeting, FK_Location, strOperation) {
        window.opener.parent.parent.location = "<%= AppConfig.SiteURL%>SONIC/SLT/SLT_Meeting.aspx?id=" + PK_SLTMeeting + "&LID=" + FK_Location + "&op=" + strOperation;
        window.close();
    }  
</script>
<script type="text/javascript" language="javascript">
    function OpenBuildingRelatedinforPopup(Pk_Location, Pk_Building, PK_PM_Site_Information) {
        var w = 480, h = 340;

        if (document.all || document.layers) {
            w = screen.availWidth;
            h = screen.availHeight;
        }

        var leftPos, topPos;
        var popW = 350, popH = 100;
        if (document.all)
        { leftPos = (w - popW) / 2; topPos = (h - popH) / 2; }
        else
        { leftPos = w / 2; topPos = h / 2; }

        window.open("<%=AppConfig.SiteURL%>DashBoard/PopupBuildingRelatedInformation.aspx?loc=" + Pk_Location + "&id=" + Pk_Building + "&SiteInfo=" + PK_PM_Site_Information, "", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=" + popW + ",height=" + popH + ",top=" + topPos + ",left=" + leftPos);
        //window.open("<%=AppConfig.SiteURL%>DashBoard/PopupBuildingRelatedInformation.aspx?loc=" + Pk_Location + "&id=" + Pk_Building + "&SiteInfo=" + PK_PM_Site_Information, '', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');        
    }
</script>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center" width="100%" cellpadding="0" cellspacing="0" class="BorderWhite">
            <tr>
                <td align="left" valign="top">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left" valign="top" width="100px">
                                <asp:Label Text="Sonic Locations :" runat="server" Font-Bold="true" />
                            </td>
                            <td align="left" valign="top" width="50px">
                                <asp:Label Text="State Of" runat="server" Font-Bold="true" />
                            </td>
                            <td align="left" valign="top">
                                <asp:Label ID="lblState" runat="server" Font-Bold="true" />
                            </td>
                            <td align="left" valign="top" width="50px">
                                &nbsp;<asp:Label Text="County" runat="server" Font-Bold="true" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="left" height="10px">
                </td>
            </tr>
            <tr>
                <td align="left" valign="top">
                    <asp:GridView ID="gvSonicLocation" runat="server" Width="100%" OnRowDataBound="gvSonicLocation_OnRowDataBound"
                        EmptyDataText="No Record Exists">
                        <Columns>
                            <asp:TemplateField HeaderText="Location/DBA" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="20%">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLocation" Text='<%# Eval("Location") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Buildings" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemTemplate>
                                    <div id="dvBuilding" runat="server">
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FROIs Last Month" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemTemplate>
                                    <div id="dvFROILastMonth" runat="server">
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FROIs This Month" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemTemplate>
                                    <div id="dvFROIThisMonth" runat="server">
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Open Claims" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemTemplate>
                                    <div id="dvOpenClaims" runat="server">
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Last Inspection Date" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemTemplate>
                                    <div id="dvLastInspectionDate" runat="server">
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Last SLT Meeting Date" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemTemplate>
                                    <div id="dvLastSLTMeetingDate" runat="server">
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Next SLT Meeting Date" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:Label ID="lblNextSLTMeetingDate" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("NextSLTMeeting"))%>'
                                        runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
