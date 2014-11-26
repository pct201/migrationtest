<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectSubLeasePopup.aspx.cs"
    Inherits="SONIC_Exposures_SelectSubLeasePopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Select Sub-Lease</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td width="100%">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="ghc" align="left">
                    Select Sub-Lease
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        <table cellpadding="4" cellspacing="0" width="100%">
            <tr>
                <td width="100%" align="left">
                    <asp:GridView ID="gvSubLease" runat="server" Width="100%" EmptyDataText="No Sub-Lease record found"
                        OnRowCommand="gvSubLease_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Building Number" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle Width="15%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkBuildingNumber" runat="server" Text='<%#Eval("Building_Number")%>'
                                        CommandArgument='<%#Eval("Sublease_Name") %>' CommandName="SelectSubLease" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sub-Lease Name" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle Width="15%"/>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkSubLeaseNumber" runat="server" Text='<%#Eval("Sublease_Name")%>'
                                        CommandArgument='<%#Eval("Sublease_Name") %>' CommandName="SelectSubLease" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sub-Lease Address" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle Width="25%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkAddress" runat="server" Text='<%# clsGeneral.FormatAddress(Eval("Sublease_Address_1"),Eval("Sublease_Address_2"),Eval("Sublease_City"),Eval("Sublease_State"),Eval("Sublease_Zip")) %>'
                                        CommandArgument='<%#Eval("Sublease_Name") %>' CommandName="SelectSubLease" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sub-Lease Landlord" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle Width="20%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkLandlord" runat="server" Text='<%#Eval("SubLease_Landlord")%>'
                                        CommandArgument='<%#Eval("Sublease_Name") %>' CommandName="SelectSubLease" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <script type="text/javascript">
        function CloseWindow() {
            var op = window.opener;
            op.document.getElementById('ctl00_ContentPlaceHolder1_btnSelectSubLease').click();
            window.close();
        }      
    </script>
    </form>
</body>
</html>
