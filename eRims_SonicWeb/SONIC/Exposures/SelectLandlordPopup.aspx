<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectLandlordPopup.aspx.cs" Inherits="SONIC_Exposures_SelectLandlordPopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Select Landlord</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr><td width="100%">&nbsp;</td></tr>
            <tr><td class="ghc" align="left">Select Landlord</td></tr>
            <tr><td>&nbsp;</td></tr>
        </table>
        <table cellpadding="4" cellspacing="0" width="100%">
            <tr>
                <td width="100%" align="left">
                    <asp:GridView ID="gvOwnership" runat="server" Width="100%" EmptyDataText="No Ownership record found" OnRowDataBound="gvOwnership_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Building Number">
                                <ItemStyle Width="25%" />
                                <ItemTemplate>
                                    <a href="#" id="lnkBuildingNumber" runat="server"><%#Eval("Building_Number")%></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord">
                                <ItemStyle Width="25%" />
                                <ItemTemplate>
                                    <a href="#" id="lnkLandlord" runat="server"><%#Eval("Landlord_Name")%></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Commencement Date">
                                <ItemStyle Width="25%" />
                                <ItemTemplate>
                                    <a href="#" id="lnkCommencementDate" runat="server"><%# clsGeneral.FormatDBNullDateToDisplay(Eval("Commencement_Date"))%></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Expiration Date">
                                <ItemStyle Width="25%" />
                                <ItemTemplate>
                                    <a href="#" id="lnkExpirationDate" runat="server"><%# clsGeneral.FormatDBNullDateToDisplay(Eval("Expiration_Date"))%></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr><td>&nbsp;</td></tr>
        </table>                        
    </div>
    <script type="text/javascript">
        function SelectValue(strLandlord,strAddress1,strAddress2 ,strCity ,strState ,strZipcode ,strLeaseID ,strCommenceDate ,strExpDate ,strSubLease ,strSubLandlord, strYear, strLandlordLegalEntity)
        {
            var op = window.opener;
            var subLease = '<%=Request.QueryString["sublease"]%>';
            var str = strLandlord + "?" + strAddress1 + "?" + strAddress2 + "?" + strCity + "?" + strState + "?" + strZipcode + "?" + strLeaseID + "?" + strCommenceDate + "?" + strExpDate + "?" + strSubLease + "?" + strSubLandlord + "?" + strYear + "?" + strLandlordLegalEntity;
            op.document.getElementById('ctl00$ContentPlaceHolder1$hdnOwnershipInfo').value = str;
            op.document.getElementById('ctl00$ContentPlaceHolder1$btnSelectBuildingOwnership').click();
            window.close();
        }
    </script>
    </form>
</body>
</html>
