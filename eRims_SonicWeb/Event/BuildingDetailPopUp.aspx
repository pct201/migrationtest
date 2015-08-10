<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BuildingDetailPopUp.aspx.cs"
    Inherits="Event_BuildingDetailPopUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Risk Insurance Management System :: Event</title>
     <script language="javascript" type="text/javascript">
         function ClosePopup() {
             parent.parent.document.getElementById('ctl00_ContentPlaceHolder1_btnhdnReload').click();
             parent.parent.GB_hide();
         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" align="left">
            <tr>
                <td align="left"  valign="top">
                    Location : &nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlLocation_Sonic" runat="server" Width="175px" SkinID="dropGen" OnSelectedIndexChanged="ddlLocation_Sonic_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
        <tr>
            <td align="left">
                <asp:GridView ID="gvBuildingEdit" runat="server" EmptyDataText="No Building Records Found"
                    AutoGenerateColumns="false"  Width="100%" OnRowDataBound="gvBuildingEdit_RowDataBound"
                    OnRowCommand="gvBuildingEdit_RowCommand">
                    <Columns>
                        <asp:TemplateField>
                            <ItemStyle Width="5%" HorizontalAlign="center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkViewDetail" runat="server" Text="Select"
                                    CommandName="SelectBuildingDetail" CommandArgument='<%# Eval("PK_Building_ID")%>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Building Number">
                            <ItemStyle Width="25%" HorizontalAlign="Left" />
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <%# Eval("Building_Number")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Address">
                            <ItemStyle Width="35%" />
                            <ItemTemplate>
                                <%# clsGeneral.FormatAddress(Eval("Address_1"),Eval("Address_2"),Eval("City"),Eval("State"),Eval("Zip")) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Occupancy">
                            <ItemStyle Width="40%" />
                            <ItemTemplate>
                                <asp:Label ID="lblOccupancy" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
