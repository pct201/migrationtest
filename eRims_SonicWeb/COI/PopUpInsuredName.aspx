<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopUpInsuredName.aspx.cs"
    Inherits="COI_PopUpInsuredName" ValidateRequest="false" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Risk Insurance Management System</title>
</head>
<script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
<body>
    <form id="form1" runat="server">
        <div>
            <table cellpadding="2" cellspacing="1" width="100%">
                <tr>
                    <td colspan="2" class="Spacer" style="height: 5px;"></td>
                </tr>
                <tr>
                    <td width="20%" align="left" valign="top">&nbsp;&nbsp;<span class="NormalFontBold">Building Information</span>
                    </td>
                    <td width="80%" align="left" valign="top">
                        <table cellpadding="4" cellspacing="0" width="100%" border="0">
                            <tr>
                                <td width="12%" align="right">Region
                                </td>
                                <td width="3%" align="center">:
                                </td>
                                <td width="30%" align="left">
                                    <asp:DropDownList ID="drpRegion" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged" Width="250px" />
                                </td>
                                <td width="18%" align="right">D/B/A Location Name
                                </td>
                                <td width="5%" align="center">:
                                </td>
                                <td width="32%" align="left">
                                    <asp:DropDownList ID="drpLocation" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDBA_SelectedIndexChanged" Width="200px" />
                                </td>
                            </tr>
                            <tr>
                                <td width="12%" align="right">Market
                                </td>
                                <td width="3%" align="center">:
                                </td>
                                <td width="30%" align="left">
                                    <asp:DropDownList ID="drpMarket" runat="server" Width="250px" />
                                </td>
                                <td align="right">State
                                </td>
                                <td align="center">:
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="drpState" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" Width="250px" />
                                </td>
                                <td colspan="3" class="Spacer" style="height: 10px;"></td>
                            </tr>
                            <tr>
                                <td colspan="6" class="Spacer" style="height: 10px;"></td>
                            </tr>
                            <tr>
                                <td colspan="6" align="center">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                                        ValidationGroup="vsErrorGroup" />
                                    &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnResetFilterCriteria" runat="server" Text="Reset" OnClick="btnResetFilterCriteria_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="Spacer" style="height: 10px;"></td>
                </tr>
                <tr runat="server" id="trPager" visible="false">
                    <td colspan="2">
                        <table width="100%" cellpadding="3" cellspacing="1">
                            <tr>
                                <td align="left" style="width: 35%;">&nbsp;<asp:Label ID="lblNumber" runat="server" Text="0"></asp:Label>&nbsp;Building
                                Information(s) Found
                                </td>
                                <td style="width: 65%;" align="right">
                                    <uc:ctrlPaging ID="ctrlPageProperty" runat="server" OnGetPage="GetPage" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="Spacer" style="height: 5px;"></td>
                </tr>
                <tr id="trGrid" runat="server">
                    <td align="left" colspan="2">
                        <asp:GridView ID="gvInsuredName" runat="server" AutoGenerateColumns="false" Width="100%"
                            DataKeyNames="PK_Building_ID" EmptyDataText="No Record Found" AllowSorting="true"
                            AllowPaging="false" OnSorting="gvInsuredName_Sorting" OnRowCreated="gvInsuredName_RowCreated"
                            OnRowDataBound="gvInsuredName_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Sonic Location D/B/A" SortExpression="dba" HeaderStyle-HorizontalAlign="Left">
                                    <ItemStyle Width="18%" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkdba" runat="server" CssClass="acher" CommandArgument='<% #Eval("dba")%>'
                                            Text='<% #Eval("dba")%>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Building Number"
                                    HeaderStyle-HorizontalAlign="Left">
                                    <ItemStyle Width="15%" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkBuildingNumber" runat="server" CssClass="acher" CommandArgument='<% #Eval("Building_Numbers")%>'
                                            Text='<% #Eval("Building_Numbers")%>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address" SortExpression="Address_1" HeaderStyle-HorizontalAlign="Left">
                                    <ItemStyle Width="27%" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkAddress" runat="server" CssClass="acher" CommandArgument='<% #Eval("Address_1")%>'
                                            Text=' <%# clsGeneral.FormatAddress(Eval("Address_1"),Eval("Address_2"),Eval("City"),Eval("State"),Eval("Zip")) %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Landlord Name" SortExpression="Landlord_Name" HeaderStyle-HorizontalAlign="Left">
                                    <ItemStyle Width="15%" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkLandlord_Name" runat="server" CssClass="acher" CommandArgument='<% #Eval("Landlord_Name")%>'
                                            Text='<% #Eval("Landlord_Name")%>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sublease Name" SortExpression="Sublease_Name" HeaderStyle-HorizontalAlign="Left">
                                    <ItemStyle Width="15%" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkSublease_Name" runat="server" CssClass="acher" CommandArgument='<% #Eval("Sublease_Name")%>'
                                            Text='<% #Eval("Sublease_Name")%>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status" SortExpression="Location_Status" HeaderStyle-HorizontalAlign="Left">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkStatus" runat="server" CssClass="acher" CommandArgument='<% #Eval("Location_Status")%>'
                                            Text='<% #Eval("Location_Status")%>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
            </table>
        </div>

        <script type="text/javascript">

            function SelectValue(strsublease_name, strLandlordName, strBilidingNumber, strRegion, strsublease_address_1, strsublease_address_2, strsublease_city, strsublease_state, strsublease_zip, strBuilding_TIV, strSubLeaseFirstName, strSubLeaseLastName, strSubLeaseTitle, strSubLeasePhone, strSubLeaseFax, strSubLeaseEmail, strPK_Building_Ownership_ID, strFK_LU_Location_ID, strPK_LU_Location_ID) {
                {
                    window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdntxtName').value = strsublease_name;
                    window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdnLandlordName').value = strLandlordName;
                    window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdnBuilding_Number').value = strBilidingNumber;
                    window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdnstrRegion').value = strRegion;
                    window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdntxtAddress1').value = strsublease_address_1;
                    window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdntxtAddress2').value = strsublease_address_2;
                    window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdntxtCity').value = strsublease_city;
                    window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdndrpState').value = strsublease_state;
                    window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdntxtZipCode').value = strsublease_zip;
                    window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdntxtBuilding_TIV').value = strBuilding_TIV;

                    window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdntxtContactFirstName').value = strSubLeaseFirstName;
                    window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdntxtContactLastName').value = strSubLeaseLastName;
                    window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdntxtContactTitle').value = strSubLeaseTitle;
                    window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdntxtContactPhone').value = strSubLeasePhone;
                    window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdntxtContactFax').value = strSubLeaseFax;
                    window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdntxtContactEmail').value = strSubLeaseEmail;
                    window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdnPK_Building_Ownership_ID').value = strPK_Building_Ownership_ID;
                    window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdnDBA').value = strFK_LU_Location_ID;
                    window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdnPK_LU_Location_ID').value = strPK_LU_Location_ID;

                    window.opener.document.getElementById('ctl00_ContentPlaceHolder1_btnOwnershipDetails').click();

                }

                self.close();
            }

            function disableDeleteBackSpace() {
                debugger;
                var keyCode = (event.which) ? event.which : event.keyCode;

                if ((keyCode == 8) || (keyCode == 46))
                    event.returnValue = false;
                else if (keyCode == 9)
                    event.returnValue = true;
                else
                    event.returnValue = false;
            }
        </script>

    </form>
</body>
</html>
