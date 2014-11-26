<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="PurchasingSearch.aspx.cs"
    Inherits="SONIC_Purchasing_PurchasingSearch" Title="eRIMS Sonic :: Purchasing Search" %>

<%@ Register Src="../../Controls/SONIC_Purchasing/Purchasing_Search.ascx" TagName="Purchasing_Search"
    TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="search" CssClass="errormessage"></asp:ValidationSummary>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>
    <script language="javascript" type="text/javascript">

        function ConfirmDelete() {
            return confirm("Are you sure you want to delete this record?");
        }

        //check Date Validation
        function CheckDate(sender, args) {
            args.IsValid = (ValidateDate(args.Value));
            return args.IsValid;
        }

        function onSearchTypeChange() {
            var trEdate = document.getElementById("trExpitrationDate");
            var trsc = document.getElementById("trServiceContract");
            var trLR = document.getElementById("trLRet");
            var trasset = document.getElementById("trasset");
            var trSupplier = document.getElementById("trSupplier");
            var trType = document.getElementById("trType");
            var drpType = document.getElementById("ctl00_ContentPlaceHolder1_ddlSearchType");

            trEdate.style.display = "none";
            trasset.style.display = "none";
            trsc.style.display = "none";
            trLRet.style.display = "none";
            trSupplier.style.display = "none";
            trType.style.display = "none";

            switch (drpType.selectedIndex) {
                case 1:
                    trasset.style.display = "";
                    break;
                case 2:
                    trLRet.style.display = "";
                    trEdate.style.display = "";
                    trSupplier.style.display = "";
                    break;
                case 3:
                    trsc.style.display = "";
                    trEdate.style.display = "";
                    trSupplier.style.display = "";
                    trType.style.display = "";
                    break;
                default:
            }
        }
     
    </script>
    <div style="width: 100%">
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <uc1:Purchasing_Search ID="Purchasing_SearchTAB" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <div style="width: 100%" id="dvSearch" runat="server">
        <table width="100%" cellspacing="0" cellpadding="0">
            <tr>
                <td class="groupHeaderBar" align="left">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="height: 20px" class="Spacer">
                </td>
            </tr>
            <tr>
                <td class="heading">
                    &nbsp;Purchasing Search
                </td>
            </tr>
            <tr>
                <td style="height: 15px;">
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table width="80%" align="center" style="text-align: left;" cellpadding="2" cellspacing="3">
                        <tr valign="top" align="left">
                            <td style="width: 20%;">
                                Search Type<span class="mf">*</span>
                            </td>
                            <td style="width: 4%;">
                                :
                            </td>
                            <td style="width: 26%">
                                <asp:DropDownList ID="ddlSearchType" runat="server" SkinID="default" Width="175px"
                                    onchange="javascript:onSearchTypeChange();">
                                    <asp:ListItem Text="---Select---" Selected="true" Value="0">
                                    </asp:ListItem>
                                    <asp:ListItem Text="Asset" Value="1">
                                    </asp:ListItem>
                                    <asp:ListItem Text="Lease/Rental Agreement" Value="2">
                                    </asp:ListItem>
                                    <asp:ListItem Text="Service Contract" Value="3">
                                    </asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvSearchType" Display="none" runat="server" ControlToValidate="ddlSearchType"
                                    ErrorMessage="Please Select Search Type." Text="*" ValidationGroup="search" InitialValue="0">
                                </asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 20%;">
                                &nbsp;
                            </td>
                            <td style="width: 4%;">
                                &nbsp;
                            </td>
                            <td style="width: 26%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Start/Acquisition Date - From
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtStartDateFrom" runat="server" SkinID="txtdate" MaxLength="10">
                                </asp:TextBox>
                                <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtStartDateFrom.ClientID%>', 'mm/dd/y');"
                                    alt="Incident Date" src="../../Images/iconPicDate.gif" align="middle" />
                                <asp:RegularExpressionValidator ID="rvStartDateFrom" runat="server" ControlToValidate="txtStartDateFrom"
                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                    ErrorMessage="Start/Acquisition Date - From Not Valid" Display="none" ValidationGroup="search">
                                </asp:RegularExpressionValidator>
                            </td>
                            <td style="width: 10%;">
                                To
                            </td>
                            <td style="width: 4%;">
                                :
                            </td>
                            <td style="width: 26%">
                                <asp:TextBox ID="txtStartDateTo" runat="server" SkinID="txtdate" MaxLength="10">
                                </asp:TextBox>
                                <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtStartDateTo.ClientID%>', 'mm/dd/y');"
                                    alt="Incident Date" src="../../Images/iconPicDate.gif" align="middle" />
                                <asp:CompareValidator ID="cbDate" runat="server" ErrorMessage="Start/Acquisition Date - From  Must Be Less Than Start/Acquisition Date To."
                                    ControlToCompare="txtStartDateFrom" Type="Date" ValidationGroup="search" Operator="GreaterThanEqual"
                                    ControlToValidate="txtStartDateTo" Display="none">
                                </asp:CompareValidator>
                                <asp:RegularExpressionValidator ID="rvStartDateTo" runat="server" ControlToValidate="txtStartDateTo"
                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                    ErrorMessage="Start/Acquisition Date - To Not Valid" Display="none" ValidationGroup="search">
                                </asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr id="trExpitrationDate" style="display: none;">
                            <td>
                                Expiration Date - From
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtExpirationDateFrom" runat="server" SkinID="txtdate" MaxLength="10">
                                </asp:TextBox>
                                <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtExpirationDateFrom.ClientID%>', 'mm/dd/y');"
                                    alt="Incident Date" src="../../Images/iconPicDate.gif" align="middle" />
                                <asp:RegularExpressionValidator ID="revEndDate" runat="server" ControlToValidate="txtExpirationDateFrom"
                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                    ErrorMessage="Expiration Date -From Not Valid" Display="none" ValidationGroup="search">
                                </asp:RegularExpressionValidator>
                            </td>
                            <td>
                                To
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtExpirationDateTo" runat="server" SkinID="txtdate" MaxLength="10">
                                </asp:TextBox>
                                <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtExpirationDateTo.ClientID%>', 'mm/dd/y');"
                                    alt="Incident Date" src="../../Images/iconPicDate.gif" align="middle" />
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Expiration Date - From  Must Be Less Than Expiration Date To."
                                    ControlToCompare="txtExpirationDateFrom" Type="Date" ValidationGroup="search"
                                    Operator="GreaterThanEqual" ControlToValidate="txtExpirationDateTo" Display="none">
                                </asp:CompareValidator>
                                <asp:RegularExpressionValidator ID="rvEndDateTo" runat="server" ControlToValidate="txtExpirationDateTo"
                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                    ErrorMessage="Expiration Date -To Not Valid" Display="none" ValidationGroup="search">
                                </asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr valign="top" align="left">
                            <td>
                                Region
                            </td>
                            <td>
                                :
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlRegion" runat="server" SkinID="default" Width="175px" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr valign="top" align="left">
                            <td>
                                Dealership
                            </td>
                            <td>
                                :
                            </td>
                            <td align="left" colspan="4">
                                <asp:DropDownList ID="ddlDealership" runat="server" SkinID="default" Width="98%">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr valign="top" align="left" id="trServiceContract" style="display: none;">
                            <td>
                                Service Contract Type
                            </td>
                            <td>
                                :
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlServiceContractType" runat="server" SkinID="default" Width="175px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr valign="top" align="left" id="trLRet" style="display: none;">
                            <td>
                                Lease/Rental Equipment Type
                            </td>
                            <td>
                                :
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlLeaseEquipmentType" runat="server" SkinID="default" Width="175px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr id="trasset" style="display: none;">
                            <td>
                                Asset Type
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtAssetType" runat="server" Width="170px" MaxLength="50">
                                </asp:TextBox>
                            </td>
                            <td>
                                Manufacturer
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtManufacturer" runat="server" Width="170px" MaxLength="50">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr valign="top" align="left">
                            <td>
                                Dealership Department
                            </td>
                            <td>
                                :
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlDealershipDepartment" runat="server" SkinID="default" Width="175px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr valign="top" align="left" id="trSupplier" style="display: none;">
                            <td>
                                Supplier
                            </td>
                            <td>
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSupplier" runat="server" Width="170px" MaxLength="75">
                                </asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td align="left">
                            </td>
                        </tr>
                        <tr valign="top" align="left" id="trType" style="display: none;">
                            <td>
                                Service Type
                            </td>
                            <td>
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtServiceType" runat="server" Width="170px" MaxLength="75">
                                </asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td align="left">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="height: 20px" class="Spacer">
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnSearch" runat="server" ValidationGroup="search" Text="Search"
                        ToolTip="Seach" OnClick="btnSearch_Click" />
                </td>
            </tr>
            <tr>
                <td style="height: 20px" class="Spacer">
                </td>
            </tr>
        </table>
    </div>
    <div id="dvSearchResult" runat="server" style="display: none; width: 100%;">
        <table width="100%" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <table style="width: 100%;" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left">
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="45%">
                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                <tr>
                                                    <td align="left">
                                                        &nbsp;<asp:Label ID="lblSearchHeader" runat="server" Text="" CssClass="heading"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        &nbsp;
                                                        <asp:Label ID="lblNumber" runat="server" Text="0"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td valign="top" align="right">
                                            <uc:ctrlPaging ID="ctrlPurchasingSearch" runat="server" OnGetPage="GetPage" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                    <tbody>
                                        <tr>
                                            <td class="Spacer" style="height: 5px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="ghc" align="left">
                                                <asp:Label ID="lblSearch" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Spacer" style="height: 5px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <div id="dvGrid" runat="server" style="width: 999px; overflow-x: scroll; overflow-y: hidden">
                                                    <asp:GridView ID="gvServiceContract" DataKeyNames="PK_Purchasing_Service_Contract"
                                                        runat="server" Width="1500px" OnRowCommand="gvServiceContract_RowCommand" AllowPaging="false"
                                                        AllowSorting="True" AutoGenerateColumns="False" OnSorting="gvServiceContract_Sorting"
                                                        OnRowDataBound="gvServiceContract_RowDataBound" OnRowCreated="gvServiceContract_RowCreated"
                                                        BorderWidth="1px" BorderColor="silver" Visible="false">
                                                        <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center"></EmptyDataRowStyle>
                                                        <HeaderStyle VerticalAlign="top" />
                                                        <Columns>
                                                            <asp:BoundField DataField="Supplier" SortExpression="Supplier" HeaderText="Supplier"
                                                                ItemStyle-Width="150px"></asp:BoundField>
                                                            <asp:BoundField DataField="Service_Type" SortExpression="Service_Type" HeaderText="Service Type"
                                                                ItemStyle-Width="130px"></asp:BoundField>
                                                            <asp:TemplateField HeaderText="Asset" SortExpression="Asset" ItemStyle-Width="130px">
                                                                <ItemTemplate>
                                                                    <asp:Repeater runat="server" ID="rptAsset">
                                                                        <ItemTemplate>
                                                                            <table width="100%" cellpadding="1" cellspacing="1" border="0">
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        <%#Eval("Type")%>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                    <asp:HiddenField ID="hdfLegalConfidential" runat="server" Value='<%#Eval("Legal_Confidential")%>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Start_Date" SortExpression="Start_Date" HeaderText="Start Date"
                                                                DataFormatString="{0:MMM-dd-yyyy}" ItemStyle-Width="100px" HtmlEncode="false">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataFormatString="{0:MMM-dd-yyyy}" SortExpression="End_Date" DataField="End_Date"
                                                                HeaderText="Expiration Date" ItemStyle-Width="100px" HtmlEncode="false"></asp:BoundField>
                                                            <asp:BoundField SortExpression="Status" DataField="Status" HeaderText="Status" ItemStyle-Width="5%">
                                                            </asp:BoundField>
                                                            <asp:TemplateField SortExpression="Monthly_Cost" HeaderText="$ per Month" HeaderStyle-HorizontalAlign="right"
                                                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="130px">
                                                                <ItemTemplate>
                                                                    <%#clsGeneral.GetStringValue(Eval("Monthly_Cost")) %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField SortExpression="Annual_Cost" HeaderText="$ per Year" HeaderStyle-HorizontalAlign="right"
                                                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="130px">
                                                                <ItemTemplate>
                                                                    <%#clsGeneral.GetStringValue(Eval("Annual_Cost")) %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField SortExpression="Service_Contract" DataField="Service_Contract" HeaderText="Contract Level"
                                                                ItemStyle-Width="120px"></asp:BoundField>
                                                            <asp:TemplateField HeaderText="Dealership Department" SortExpression="Dealership_Department"
                                                                ItemStyle-Width="150px">
                                                                <ItemTemplate>
                                                                    <asp:Repeater runat="server" ID="rptDepartment">
                                                                        <ItemTemplate>
                                                                            <table width="100%" cellpadding="1" cellspacing="1" border="0">
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        <%#Eval("Fld_Desc")%>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Location" SortExpression="Location" ItemStyle-Width="200px">
                                                                <ItemTemplate>
                                                                    <div runat="server" id="dvLocation">
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemStyle HorizontalAlign="Center" Width="3%"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <asp:Button ID="lnkEdit" CommandName="EditItem" CommandArgument='<%#Eval("PK_Purchasing_Service_Contract")%>'
                                                                        ToolTip="Edit Service Contract" Text="Edit" runat="server"></asp:Button>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemStyle HorizontalAlign="Center" Width="3%"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <asp:Button ID="lnkView" CommandName="ViewItem" CommandArgument='<%#Eval("PK_Purchasing_Service_Contract")%>'
                                                                        ToolTip="View Service Contract" Text="View" runat="server"></asp:Button>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemStyle HorizontalAlign="Center" Width="3%"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <asp:Button ID="lnkDelete" CommandName="DeleteItem" ToolTip="Delete Service Contract"
                                                                        Text="Delete" runat="server" OnClientClick="return ConfirmDelete();" CommandArgument='<%#Eval("PK_Purchasing_Service_Contract")%>'>
                                                                    </asp:Button>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            No data found.
                                                        </EmptyDataTemplate>
                                                        <PagerSettings Visible="False" />
                                                        <PagerStyle BackColor="#7F7F7F" BorderColor="#7F7F7F" HorizontalAlign="Left" VerticalAlign="Middle">
                                                        </PagerStyle>
                                                    </asp:GridView>
                                                    <asp:GridView ID="gvLRAgreement" DataKeyNames="PK_Purchasing_LR_Agreement" runat="server"
                                                        Width="1500px" OnRowCommand="gvLRAgreement_RowCommand" AllowPaging="false" AllowSorting="True"
                                                        AutoGenerateColumns="False" OnSorting="gvLRAgreement_Sorting" OnRowDataBound="gvLRAgreement_RowDataBound"
                                                        OnRowCreated="gvLRAgreement_RowCreated" BorderWidth="1px" BorderColor="silver"
                                                        Visible="false">
                                                        <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center"></EmptyDataRowStyle>
                                                        <HeaderStyle VerticalAlign="top" />
                                                        <Columns>
                                                            <asp:BoundField DataField="Supplier" SortExpression="Supplier" HeaderText="Supplier"
                                                                ItemStyle-Width="150px"></asp:BoundField>
                                                            <asp:BoundField DataField="Equipment_Type" SortExpression="Equipment_Type" HeaderText="Equipment Type"
                                                                ItemStyle-Width="130px"></asp:BoundField>
                                                            <asp:TemplateField HeaderText="Asset" SortExpression="Asset" ItemStyle-Width="130px">
                                                                <ItemTemplate>
                                                                    <asp:Repeater runat="server" ID="rptAsset">
                                                                        <ItemTemplate>
                                                                            <table width="100%" cellpadding="1" cellspacing="1" border="0">
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        <%#Eval("Type")%>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Start_Date" SortExpression="Start_Date" HeaderText="Start Date"
                                                                DataFormatString="{0:MMM-dd-yyyy}" ItemStyle-Width="100px" HtmlEncode="false">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataFormatString="{0:MMM-dd-yyyy}" SortExpression="End_Date" DataField="End_Date"
                                                                HeaderText="Expiration Date" ItemStyle-Width="120px" HtmlEncode="false"></asp:BoundField>
                                                            <asp:BoundField SortExpression="Status" DataField="Status" HeaderText="Status" ItemStyle-Width="120px">
                                                            </asp:BoundField>
                                                            <asp:TemplateField SortExpression="Monthly_Cost" HeaderText="$ per Month" HeaderStyle-HorizontalAlign="right"
                                                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="130px">
                                                                <ItemTemplate>
                                                                    <%#clsGeneral.GetStringValue(Eval("Monthly_Cost")) %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField SortExpression="Annual_Cost" HeaderText="$ per Year" HeaderStyle-HorizontalAlign="right"
                                                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="130px">
                                                                <ItemTemplate>
                                                                    <%#clsGeneral.GetStringValue(Eval("Annual_Cost")) %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Dealership_Department" SortExpression="Dealership_Department"
                                                                HeaderText="Dealership Department" ItemStyle-Width="150px"></asp:BoundField>
                                                            <asp:TemplateField HeaderText="Location" SortExpression="Location" ItemStyle-Width="200px">
                                                                <ItemTemplate>
                                                                    <div runat="server" id="dvLocation">
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemStyle HorizontalAlign="Center" Width="3%"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <asp:Button ID="lnkEdit" CommandName="EditItem" CommandArgument='<%#Eval("PK_Purchasing_LR_Agreement")%>'
                                                                        ToolTip="Edit Lease/Rental Agreement" Text="Edit" runat="server"></asp:Button>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemStyle HorizontalAlign="Center" Width="3%"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <asp:Button ID="lnkView" CommandName="ViewItem" CommandArgument='<%#Eval("PK_Purchasing_LR_Agreement")%>'
                                                                        ToolTip="View Lease/Rental Agreement" Text="View" runat="server"></asp:Button>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemStyle HorizontalAlign="Center" Width="3%"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <asp:Button ID="lnkDelete" CommandName="DeleteItem" ToolTip="Delete Lease/Rental Agreement"
                                                                        Text="Delete" runat="server" OnClientClick="return ConfirmDelete();" CommandArgument='<%#Eval("PK_Purchasing_LR_Agreement")%>'>
                                                                    </asp:Button>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            No data found.
                                                        </EmptyDataTemplate>
                                                        <PagerSettings Visible="False" />
                                                        <PagerStyle BackColor="#7F7F7F" BorderColor="#7F7F7F" HorizontalAlign="Left" VerticalAlign="Middle">
                                                        </PagerStyle>
                                                    </asp:GridView>
                                                    <asp:GridView ID="gvAsset" DataKeyNames="PK_Purchasing_Asset" runat="server" Width="1300px"
                                                        OnRowCommand="gvAsset_RowCommand" AllowPaging="false" AllowSorting="True" AutoGenerateColumns="False"
                                                        OnSorting="gvAsset_Sorting" OnRowDataBound="gvAsset_RowDataBound" OnRowCreated="gvAsset_RowCreated"
                                                        BorderWidth="1px" BorderColor="silver" Visible="false">
                                                        <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center"></EmptyDataRowStyle>
                                                        <HeaderStyle VerticalAlign="top" />
                                                        <Columns>
                                                            <asp:BoundField DataField="Type" SortExpression="Type" HeaderText="Type" ItemStyle-Width="150px">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Manufacturer" SortExpression="Manufacturer" HeaderText="Manufacturer"
                                                                ItemStyle-Width="130px"></asp:BoundField>
                                                            <asp:TemplateField SortExpression="Acquisition_Date" HeaderText="Acquisition Date"
                                                                ItemStyle-Width="130px">
                                                                <ItemTemplate>
                                                                    <%#Convert.ToDateTime(Eval("Acquisition_Date")) == System.Data.SqlTypes.SqlDateTime.MinValue ? "" : Eval("Acquisition_Date","{0:MMM-dd-yyyy}")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Service Contract" SortExpression="Service_Contract"
                                                                ItemStyle-Width="150px">
                                                                <ItemTemplate>
                                                                    <asp:Repeater runat="server" ID="rptServiceContract">
                                                                        <ItemTemplate>
                                                                            <table width="100%" cellpadding="1" cellspacing="1" border="0">
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        <%#Eval("Supplier")%>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Lease/Rental Agreements" SortExpression="LR_Agreement"
                                                                ItemStyle-Width="200px">
                                                                <ItemTemplate>
                                                                    <asp:Repeater runat="server" ID="rptLRAgreement">
                                                                        <ItemTemplate>
                                                                            <table width="100%" cellpadding="1" cellspacing="1" border="0">
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        <%#Eval("Supplier")%>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Dealership_Department" SortExpression="Dealership_Department"
                                                                HeaderText="Dealership Department" ItemStyle-Width="150px"></asp:BoundField>
                                                            <asp:BoundField DataField="Location" SortExpression="Location" HeaderText="Location"
                                                                ItemStyle-Width="200px"></asp:BoundField>
                                                            <asp:TemplateField>
                                                                <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <asp:Button ID="lnkEditAsset" CommandName="EditItem" CommandArgument='<%#Eval("PK_Purchasing_Asset")%>'
                                                                        ToolTip="Edit Purchasing Asset Information" Text="Edit" runat="server"></asp:Button>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <asp:Button ID="lnkviewAsset" CommandName="ViewItem" CommandArgument='<%#Eval("PK_Purchasing_Asset")%>'
                                                                        ToolTip="View Purchasing Asset Information" Text="View" runat="server"></asp:Button>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <asp:Button ID="lnkDelete" CommandName="DeleteItem" ToolTip="Delete Lease/Rental Agreement"
                                                                        runat="server" OnClientClick="return ConfirmDelete();" Text="Delete" CommandArgument='<%#Eval("PK_Purchasing_Asset")%>'>
                                                                    </asp:Button>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            No data found.
                                                        </EmptyDataTemplate>
                                                        <PagerSettings Visible="False" />
                                                        <PagerStyle BackColor="#7F7F7F" BorderColor="#7F7F7F" HorizontalAlign="Left" VerticalAlign="Middle">
                                                        </PagerStyle>
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="Spacer" style="height: 10px;">
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnMainBack" OnClick="btnBack_Click" CausesValidation="false" runat="server"
                                    Text="Back To Search"></asp:Button>&nbsp;&nbsp;
                                <asp:Button ID="btnAdd" runat="server" Text="Add New" CausesValidation="false" OnClick="btnAddNew_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
