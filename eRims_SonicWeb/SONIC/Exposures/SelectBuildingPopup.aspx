<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectBuildingPopup.aspx.cs"
    Inherits="SONIC_Exposures_SelectBuildingPopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Select Building</title>
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
                    Select Building
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
                    <asp:GridView ID="gvBuilding" runat="server" Width="100%" EmptyDataText="No Ownership record found"
                        OnRowDataBound="gvBuilding_RowDataBound" OnRowCommand="gvBuilding_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Building Number" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle Width="15%" />
                                <ItemTemplate>                                    
                                    <asp:LinkButton ID="lnkBuildingNumber" runat="server" Text='<%#Eval("Building_Number")%>' CommandArgument='<%#Eval("PK_Building_ID") %>' CommandName="SelectBuilding" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle Width="25%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkAddress" runat="server" Text='<%# clsGeneral.FormatAddress(Eval("Address_1"),Eval("Address_2"),Eval("City"),Eval("State"),Eval("Zip")) %>' 
                                    CommandArgument='<%#Eval("PK_Building_ID") %>' CommandName="SelectBuilding" />                                    
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Landlord" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle Width="20%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkLandlord" runat="server" Text='<%#Eval("Landlord_Name")%>' CommandArgument='<%#Eval("PK_Building_ID") %>' CommandName="SelectBuilding" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Commencement Date" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle Width="20%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkCommencementDate" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Commencement_Date"))%>' 
                                    CommandArgument='<%#Eval("PK_Building_ID") %>' CommandName="SelectBuilding" />                                    
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Expiration Date" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle Width="20%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkExpirationDate" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Expiration_Date"))%>' 
                                    CommandArgument='<%#Eval("PK_Building_ID") %>' CommandName="SelectBuilding" />                                                                        
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
            op.document.getElementById('ctl00_ContentPlaceHolder1_btnSelectBuildingOwnership').click();
            window.close();
        }

        function SelectValue(strPK_Building_ID, strbuildingNumber, strAddress1, strAddress2, strCity, strState, strZipcode, strLandlord, strLandAddress1, strLandAddress2, strLandCity, strLandState, strLandZipcode, strLeaseID, strCommenceDate, strExpDate, strSubLease, strSubLandlord, strYear, strLandlordLegalEntity, strLocationStatus) {
            var op = window.opener;
            op.document.getElementById('ctl00_ContentPlaceHolder1_hdnBuildingNumber').value = strPK_Building_ID;
            op.document.getElementById('ctl00_ContentPlaceHolder1_txtBuildingNumber').value = strbuildingNumber;
            op.document.getElementById('ctl00_ContentPlaceHolder1_txtBuildingAddress1').value = strAddress1;
            op.document.getElementById('ctl00_ContentPlaceHolder1_txtBuildingAddress2').value = strAddress2;
            op.document.getElementById('ctl00_ContentPlaceHolder1_txtBuildingCity').value = strCity;
            op.document.getElementById('ctl00_ContentPlaceHolder1_txtBuildingState').value = strState;
            op.document.getElementById('ctl00_ContentPlaceHolder1_txtBuildingZipCode').value = strZipcode;            

            var subLease = '<%=Request.QueryString["sublease"]%>';
            var str = strLandlord + "?" + strLandAddress1 + "?" + strLandAddress2 + "?" + strLandCity + "?" + strLandState + "?" + strLandZipcode + "?" + strLeaseID + "?" + strCommenceDate + "?" + strExpDate + "?" + strSubLease + "?" + strSubLandlord + "?" + strYear + "?" + strLandlordLegalEntity + "?" + strLocationStatus;
            op.document.getElementById('ctl00_ContentPlaceHolder1_hdnOwnershipInfo').value = str;
            op.document.getElementById('ctl00_ContentPlaceHolder1_btnSelectBuildingOwnership').click();
            window.close();
        }


    </script>

    </form>
</body>
</html>
