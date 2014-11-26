<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DealershipDBA_Pupup.aspx.cs"
    Inherits="SONIC_RealEstate_DealershipDBA_Pupup" Title="Dealeship DBA Search" %>

<%@ Register Src="~/Controls/RealEstateTab/RealEstate.ascx" TagName="RealEstateTab"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/RealEstateInfo/RealEstateInfo.ascx" TagName="RealEstateInfo"
    TagPrefix="uc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            width: 66%;
        }
    </style>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <div id="dvSearch" runat="server">
        <table width="100%" align="center" cellspacing="2" cellpadding="3">
            <tr>
                <td>
                    <table width="100%" cellspacing="2" cellpadding="3">
                        <tr align="left">
                            <td rowspan="5" colspan="3" width="60%" valign="top" align="left" class="heading">
                                Find Dealership/DBA
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                                DBA
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtSearchDBA" MaxLength="50" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                                City
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtSearchCity" MaxLength="50" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                                State
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtSearchState" MaxLength="50" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td valign="top" align="left">
                                <asp:Button ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" />
                                &nbsp;&nbsp;
                                <asp:Button ID="btnAdd" Text="  Add  " runat="server" OnClick="btnAdd_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvDealerShip" runat="server" AutoGenerateColumns="false" Width="100%"
                        AllowPaging="true" PageSize="14" AllowSorting="true" OnPageIndexChanging="gvDealerShip_PageIndexChanging"
                        OnRowCreated="gvDealerShip_RowCreated" OnSorting="gvDealerShip_Sorting" OnRowCommand="gvDealerShip_RowCommand">
                        <RowStyle HorizontalAlign="Left" />
                        <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center"></EmptyDataRowStyle>
                        <EmptyDataTemplate>
                            No Records Found.
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:TemplateField HeaderText="DBA" HeaderStyle-HorizontalAlign="Left" SortExpression="Dba"
                                ItemStyle-Width="28%">
                                <ItemTemplate>
                                    <a href="javascript:void(0);" onclick="javascript:SetValues(<%#Eval("PK_LU_Location_ID")%>);"
                                        style='display: <%#Eval("Active").ToString()=="Y"?"block":"none" %>'>
                                        <%#Eval("DBA") %></a>
                                    <asp:Label ID="lblDba" runat="server" Text=' <%#Eval("DBA")%>' Visible='<%#Eval("Active").ToString()=="Y"?false:true %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Address" SortExpression="Address_1"
                                ItemStyle-Width="28%">
                                <ItemTemplate>
                                    <a href="javascript:void(0);" onclick="javascript:SetValues(<%#Eval("PK_LU_Location_ID")%>);"
                                        style='display: <%#Eval("Active").ToString()=="Y"?"block":"none" %>'>
                                        <%#Eval("Address_1") %></a>
                                    <asp:Label ID="lblAddress" runat="server" Text=' <%#Eval("Address_1")%>' Visible='<%#Eval("Active").ToString()=="Y"?false:true %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="City" SortExpression="City"
                                ItemStyle-Width="18%">
                                <ItemTemplate>
                                    <a href="javascript:void(0);" onclick="javascript:SetValues(<%#Eval("PK_LU_Location_ID")%>);"
                                        style='display: <%#Eval("Active").ToString()=="Y"?"block":"none" %>'>
                                        <%#Eval("City") %></a>
                                    <asp:Label ID="lblCity" runat="server" Text=' <%#Eval("City")%>' Visible='<%#Eval("Active").ToString()=="Y"?false:true %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="State" SortExpression="FLD_State"
                                ItemStyle-Width="18%">
                                <ItemTemplate>
                                    <a href="javascript:void(0);" onclick="javascript:SetValues(<%#Eval("PK_LU_Location_ID")%>);"
                                        style='display: <%#Eval("Active").ToString()=="Y"?"block":"none" %>'>
                                        <%#Eval("FLD_State")%></a>
                                    <asp:Label ID="lblState" runat="server" Text=' <%#Eval("FLD_State")%>' Visible='<%#Eval("Active").ToString()=="Y"?false:true %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandArgument='<%#Eval("PK_LU_Location_ID")%>'
                                        CommandName="EditItem" Visible='<%# App_Access == AccessType.Administrative_Access%>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    <div id="dvAddEdit" style="display: none;" runat="server">
        <table width="100%" cellpadding="2" cellspacing="1" border="0">
            <tr>
                <td align="left" class="ghc" colspan="6">
                    Sonic Locations
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" width="20%" style="padding-left: 5px;">
                    DBA <span style="color: Red">*</span>
                </td>
                <td align="center" width="2%">
                    :
                </td>
                <td align="left" width="28%">
                    <asp:TextBox ID="txtDba" runat="server" Width="150px" MaxLength="50" />
                    <asp:RequiredFieldValidator ID="rfvDba" runat="server" ErrorMessage="Please Enter DBA"
                        ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToValidate="txtDba"
                        Display="None"></asp:RequiredFieldValidator>
                </td>
                <td align="left" width="20%">
                    Legal Entity <span style="color: Red">*</span>
                </td>
                <td align="center" width="2%">
                    :
                </td>
                <td align="left" width="28%">
                    <asp:TextBox ID="txtLegalEntity" runat="server" Width="150px" MaxLength="50" />
                    <asp:RequiredFieldValidator ID="rfvLegalEntity" runat="server" ErrorMessage="Please Enter Legal Entity"
                        ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToValidate="txtLegalEntity"
                        Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-left: 5px;">
                    Address 1 <span style="color: Red">*</span>
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtAddress1" runat="server" Width="150px" MaxLength="50" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Address1"
                        ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToValidate="txtAddress1"
                        Display="None"></asp:RequiredFieldValidator>
                </td>
                <td align="left">
                    Address 2
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtAddress2" runat="server" Width="150px" MaxLength="50" />
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-left: 5px;">
                    City <span style="color: Red">*</span>
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtCity" runat="server" Width="150px" MaxLength="50" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter City"
                        ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToValidate="txtCity"
                        Display="None"></asp:RequiredFieldValidator>
                </td>
                <td align="left">
                    State<span style="color: Red">*</span>
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:DropDownList ID="drpState" Width="150px" runat="server" OnSelectedIndexChanged="drpState_SelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Select State"
                        ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToValidate="drpState"
                        InitialValue="0" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-left: 5px;">
                    Zip Code(XXXXX-XXXX) <span style="color: Red">*</span>
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtZipCode" runat="server" Width="150px" MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" SetFocusOnError="true" runat="server"
                        ErrorMessage="Please Enter Zip Code" ValidationGroup="vsErrorGroup" ControlToValidate="txtZipCode"
                        Display="None"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revZipCode" runat="server" ErrorMessage="Zip Code is not valid"
                        ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToValidate="txtZipCode"
                        ValidationExpression="\b[0-9]{5}-[0-9]{4}\b|\b[0-9]{5}\b" Display="none" />
                </td>
                <td align="left">
                    County
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:DropDownList ID="drpCounty" Width="150px" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-left: 5px;">
                    Dealership Telephone (XXX-XXX-XXXX)
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtTelePhone" runat="server" Width="150px" MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);" />
                    <asp:RegularExpressionValidator ID="revWorkTel" runat="server" ControlToValidate="txtTelePhone"
                        ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b" ErrorMessage="Please Enter Dealership Telephone in xxx-xxx-xxxx format."
                        SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none"></asp:RegularExpressionValidator>
                </td>
                <td align="left">
                    Year of Acquisition
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtYearofAquisition" runat="server" Width="150px" MaxLength="50" />
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-left: 5px;">
                    Web Site Address
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtWebSite" runat="server" Width="150px" MaxLength="255" />
                    <asp:RegularExpressionValidator ID="regWebSite" runat="server" Display="none" Enabled="true"
                        ValidationExpression="(http(s)?://)?([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?|(http(s)?://)([\w-]+\.)*[\w-]+(/[\w- ./?%&=]*)?"
                        ControlToValidate="txtWebSite" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                        ErrorMessage="Web site URL is not valid" />
                </td>
                <td align="left">
                    RMI Location Number<span style="color: Red">*</span>
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtRIMNumber" runat="server" Width="150px" MaxLength="50" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Enter RMI Location Number"
                        ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToValidate="txtRIMNumber" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-left: 5px;">
                    Region<span style="color: Red">*</span>
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtRegion" runat="server" Width="150px" MaxLength="50" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please Enter Region"
                        ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToValidate="txtRegion" Display="None"></asp:RequiredFieldValidator>
                </td>
                <td align="left">
                    ADP DMS <span style="color: Red">*</span>
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtAdpDms" runat="server" Width="150px" MaxLength="10" onpaste="return false" onkeypress="return FormatNumber(event,this.id,10,false);" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please Enter ADP DMS"
                        ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToValidate="txtAdpDms" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-left: 5px;">
                    Location Description
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtLocationDesc" runat="server" Width="150px" MaxLength="50" />
                </td>
                <td align="left">
                    Sonic Location Code<span style="color: Red">*</span>
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtSonicLocationCode" runat="server" Width="150px" MaxLength="4"
                        onKeyPress="return FormatInteger(event);" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Please Enter Sonic Location Code"
                        ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToValidate="txtSonicLocationCode" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-left: 5px;">
                    Active
                </td>
                <td align="center">
                    :
                </td>
                <td align="left" colspan="4">
                    <asp:RadioButtonList ID="rdbActive" runat="server" SkinID="YesNoType">
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td valign="top" align="center" colspan="6">
                    <asp:Button ID="btnSave" Text=" Save " CausesValidation="true" ValidationGroup="vsErrorGroup"
                        runat="server" OnClick="btnSave_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCancel" Text="Cancel" runat="server" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>

    <script type="text/javascript">
        function SetValues(PK)
        {
            var hdnID = '<%=Request.QueryString["hdnID"]%>';
            var btnID = '<%=Request.QueryString["btnID"]%>';
            
            var wOpen = window.opener;
            wOpen.document.getElementById(hdnID).value = PK;
            wOpen.document.getElementById(btnID).click();
            window.close();
        }
    </script>

</body>
</html>
