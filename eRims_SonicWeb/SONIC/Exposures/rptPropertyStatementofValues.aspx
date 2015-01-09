<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rptPropertyStatementofValues.aspx.cs"
    MasterPageFile="~/Default.master" Inherits="SONIC_Exposures_rptPropertyStatementofValues" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        #ctl00_ContentPlaceHolder1_gvDescription_New td {
            vertical-align: middle;
            padding-left: 3px;
        }

        #ctl00_ContentPlaceHolder1_gvDescription_New th {
            height: 22px;
        }

        .HeaderStyle th {
            vertical-align: bottom;
            text-align: left;
            padding-bottom: 3px;
            padding-left: 3px;
            height: 22px;
        }
        /*.HeaderStyle th {
            text-align: left;
            vertical-align: bottom;
        }*/
        /*td.centerAlign {
            vertical-align: middle!important;
            text-align: center!important;
        }*/
    </style>
    <asp:ValidationSummary ID="valSummary" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="vsErrorGroup" />

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script language="javascript" type="text/javascript">
        function showAudit(divHeader, divGrid) {
            var divheight, i;

            divHeader.style.width = window.screen.availWidth - 225 + "px";
            divGrid.style.width = window.screen.availWidth - 225 + "px";

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

    <table width="100%" cellpadding="0" cellspacing="2">
        <tr>
            <td width="100%" class="Spacer" style="height: 3px;" colspan="2"></td>
        </tr>
        <tr>
            <td align="left" class="ghc" colspan="2">Statement of Values Report
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 3px;" colspan="2"></td>
        </tr>
        <tr runat="server" id="trCriteria">
            <td width="20%">&nbsp;
            </td>
            <td align="center">
                <table border="0" cellpadding="5" cellspacing="1" width="100%">
                    <tr>
                        <td align="left" valign="top" width="28%">Region
                        </td>
                        <td width="2%" align="center" valign="top">:
                        </td>
                        <td align="left" width="70%">
                            <asp:ListBox ID="lstRegions" runat="server" SelectionMode="Multiple" ToolTip="Select Region"
                                AutoPostBack="false" Width="280px" Rows="5"></asp:ListBox>
                        </td>
                    </tr>
                     <tr>
                        <td align="left" valign="top" width="28%">Market
                        </td>
                        <td width="2%" align="center" valign="top">:
                        </td>
                        <td align="left" width="70%">
                            <asp:ListBox ID="lstMarket" runat="server" SelectionMode="Multiple" ToolTip="Select Market"
                                AutoPostBack="false" Width="280px" Rows="5"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">Location Status
                        </td>
                        <td width="2%" align="center" valign="top">:
                        </td>
                        <td align="left">
                            <asp:ListBox runat="server" ID="ddlStatus" SkinID="dropGen" Width="280px" Rows="3"
                                SelectionMode="Multiple">
                                <asp:ListItem Text="Active" Value="Active"></asp:ListItem>
                                <asp:ListItem Text="InActive" Value="Inactive"></asp:ListItem>
                                <asp:ListItem Text="Disposed" Value="Disposed"></asp:ListItem>
                            </asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">Ownership
                        </td>
                        <td width="2%" align="center" valign="top">:
                        </td>
                        <td align="left">
                            <asp:ListBox runat="server" ID="drpOwnership" SkinID="dropGen" Width="280px" Rows="5"
                                SelectionMode="Multiple">
                                <%--                                <asp:ListItem Text="Owned" Value="Owned"></asp:ListItem>
                                <asp:ListItem Text="Leased" Value="Leased"></asp:ListItem>
                                <asp:ListItem Text="Sub-leased" Value="Sub-leased"></asp:ListItem>
                                <asp:ListItem Text="Internal Lease" Value="Internal Lease"></asp:ListItem>
                                <asp:ListItem Text="Assigned With Liability" Value="Assigned With Liability"></asp:ListItem>
                                <asp:ListItem Text="Assigned No Liability" Value="Assigned No Liability"></asp:ListItem>
                                <asp:ListItem Text="Management Agreement" Value="Management Agreement"></asp:ListItem>--%>
                                <asp:ListItem Text="Sonic Owned with Internal Lease" Value="Internal"></asp:ListItem>
                                <asp:ListItem Text="Sonic Owned with Third Party Lease" Value="ThirdParty"></asp:ListItem>
                                <asp:ListItem Text="Sonic Owned" Value="Owned"></asp:ListItem>
                                <asp:ListItem Text="Third Party Owned and Sonic Leased" Value="ThirdPartyLease"></asp:ListItem>
                                <asp:ListItem Text="Third Party Owned and Sonic Leased and Subleased to Third Party"
                                    Value="ThirdPartySublease"></asp:ListItem>
                            </asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">Property Valuation Date From
                        </td>
                        <td width="2%" align="center" valign="top">:
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPropertyValuationDateFrom" runat="server" Width="145px" SkinID="txtDate" />
                            <img alt="PV Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPropertyValuationDateFrom', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtPropertyValuationDateFrom"
                                ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                ErrorMessage="Property Valuation Date From is invalid." Display="none" ValidationGroup="vsErrorGroup"
                                SetFocusOnError="true" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">Property Valuation Date To
                        </td>
                        <td width="2%" align="center" valign="top">:
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPropertyValuationDateTo" runat="server" Width="145px" SkinID="txtDate" />
                            <img alt="PV Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPropertyValuationDateTo', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPropertyValuationDateTo"
                                ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                ErrorMessage="Property Valuation Date To is invalid." Display="none" ValidationGroup="vsErrorGroup"
                                SetFocusOnError="true" />
                            <asp:CompareValidator ID="cmpvProperyValuationDate" runat="server" ControlToValidate="txtPropertyValuationDateTo"
                                ControlToCompare="txtPropertyValuationDateFrom" Type="Date" ValidationGroup="vsErrorGroup"
                                Operator="GreaterThanEqual" Display="None" ErrorMessage="Property Valuation Date To Must Be Greater Than Property Valuation Date From."></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                        <td colspan="2" align="left">
                            <asp:Button runat="server" ID="btnShowReport" Text="Show Report" OnClick="btnShowReport_Click"
                                CausesValidation="true" ValidationGroup="vsErrorGroup" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear All"
                                OnClick="btnClearCriteria_Click" CausesValidation="false" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0" runat="server" id="tblReport" visible="false">
        <tr valign="middle">
            <td align="right" width="100%">
                <asp:LinkButton Visible="false" ID="lbtExportToExcel" runat="server" Text="Export To Excel"
                    OnClick="lbtExportToExcel_Click"></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 5px;"></td>
        </tr>
        <tr class="HeaderStyle">
            <td>
                <table width="100%">
                    <tr>
                        <td align="left" width="20%">Sonic Automotive
                        </td>
                        <td align="center" runat="server" style="margin-left: 0; text-align: center;">Property Statement of Values Report
                                
                        </td>
                        <td align="left" style="margin-left: 0; text-align: right;" width="20%">
                            <span><%=DateTime.Now.ToString()  %></span>
                        </td>
                    </tr>
                </table>
            </td>

        </tr>
        <%--<tr>
            <td align="left">
                <div style="overflow: hidden; width: 997px;" id="dvHeader" runat="server">
                    <table width="20330px" cellpadding="4" cellspacing="0" border="0" style="font-weight: bold;" id="tblHeader" runat="server">
                        <tr class="HeaderStyle">
                            <td align="left" colspan="2">Sonic Automotive
                            </td>
                            <td align="center" colspan="115" runat="server" id="tdPropertyHeader">Property Statement of Values Report
                                <span style="margin-left: 0; text-align: left; position: absolute; right: 230px;"><%=DateTime.Now.ToString()  %></span>
                            </td>
                            <td align="left" colspan="2"></td>
                        </tr>
                        <tr style="font-weight: bold;" align="center">
                            <td colspan="15" style="background: #993300;">LOCATION/ADDRESS INFORMATION
                            </td>
                            <td colspan="8" style="background: #000000; color: #ffffff;">OCCUPANCY
                            </td>
                            <td colspan="7" style="background: #008000;">FINANCIAL INFORMATION
                            </td>
                            <td colspan="12" style="background-color: #9999FF; color: #FFFFFF;">FIRE INSPECTION COMPANY
                            </td>
                            <td colspan="13" style="background: #000084; color: #ffffff;">SECURITY GUARD SERVICES
                            </td>
                            <td colspan="13" style="background: #FF6500;">INTRUSION ALARM SERVICES
                            </td>
                            <td colspan="2" style="background: #840084;">FENCE
                            </td>
                            <td colspan="3" style="background: #31CFCF;">GENERATOR
                            </td>
                            <td colspan="2" style="background: #ff0000;">FIRE DEPARTMENT
                            </td>
                            <td colspan="4" style="background: #ffff00;">&nbsp;
                            </td>
                            <td colspan="6" style="background: #31309C; color: #ffffff;">CONSTRUCTION OF FLOORS (Yes to all apply)
                            </td>
                            <td colspan="6" style="background: #ff0000;">CONSTRUCTION OF EXTERIOR WALLS (Yes to all apply)
                            </td>
                            <td colspan="25" style="background-color: lightgoldenrodyellow" runat="server" id="tdOutHeaderInsuranceCope">INSURANCE COPE
                            </td>
                            <td colspan="3" style="background: #008284;">MISC INFORMAION
                            </td>
                        </tr>
                        <tr align="left" valign="bottom" class="HeaderStyle">
                            <td style="width: 150px">
                                <!-- LOCATION/ADDRESS INFORMATION  -->
                                Region
                            </td>
                            <td style="width: 150px">Sonic Location Code
                            </td>
                            <td style="width: 180px">Location Name
                            </td>
                            <td style="width: 180px">Legal Entity
                            </td>
                            <td style="width: 150px">Federal Id
                            </td>
                            <td style="width: 150px">Location Status
                            </td>
                            <td style="width: 120px">Building #
                            </td>
                            <td style="width: 150px">Building Status
                            </td>
                            <td style="width: 200px">Address 1
                            </td>
                            <td style="width: 200px">Address 2
                            </td>
                            <td style="width: 150px">City
                            </td>
                            <td style="width: 150px">State
                            </td>
                            <td style="width: 150px">Zip Code
                            </td>
                            <td style="width: 150px">County
                            </td>
                            <td style="width: 150px">Owned/Leased/Sub Leased/Assigned/ Management Agreement
                            </td>
                            <td style="width: 120px">
                                <!-- OCCUPANCY  -->
                                Sales - New
                            </td>
                            <td style="width: 120px">Sales - Used
                            </td>
                            <td style="width: 120px">Services
                            </td>
                            <td style="width: 120px">Body Shop
                            </td>
                            <td style="width: 120px">Parts
                            </td>
                            <td style="width: 120px">Office
                            </td>
                            <td style="width: 120px">Parking Lot
                            </td>
                            <td style="width: 120px">Row Land
                            </td>
                            <td style="width: 150px">
                                <!-- FINANCIAL INFORMATION  -->
                                Property Valuation Date
                            </td>
                            <td style="width: 150px">RS Means Building Limit
                            </td>
                            <td style="width: 150px">Associate Tools Limit
                            </td>
                            <td style="width: 150px">Contents Limit
                            </td>
                            <td style="width: 150px">Parts Limit
                            </td>
                            <td style="width: 150px">Business Interruption
                            </td>
                            <td style="width: 150px">Total
                            </td>
                            <td style="width: 180px">
                                <!-- FIRE INSPECTION COMPANY -->
                                Contact Name
                            </td>
                            <td style="width: 180px">Vendor Name
                            </td>
                            <td style="width: 180px">Contract Expiration Date
                            </td>
                            <td style="width: 180px">Address 1
                            </td>
                            <td style="width: 180px">Address 2
                            </td>
                            <td style="width: 180px">City
                            </td>
                            <td style="width: 180px">State
                            </td>
                            <td style="width: 180px">Zip
                            </td>
                            <td style="width: 180px">Email
                            </td>
                            <td style="width: 180px">Telephone Number
                            </td>
                            <td style="width: 180px">Alternate Number
                            </td>
                            <td style="width: 180px">Comments
                            </td>
                            <td style="width: 150px">
                                <!-- Security Guard Services  -->
                                System
                            </td>
                            <td style="width: 150px">Vendor Name
                            </td>
                            <td style="width: 200px">Address 1
                            </td>
                            <td style="width: 200px">Address 2
                            </td>
                            <td style="width: 150px">City
                            </td>
                            <td style="width: 150px">State
                            </td>
                            <td style="width: 150px">Zip
                            </td>
                            <td style="width: 150px">Contact Name
                            </td>
                            <td style="width: 150px">Contract Expiration Date
                            </td>
                            <td style="width: 150px">Telephone Number
                            </td>
                            <td style="width: 150px">Alternet Number
                            </td>
                            <td style="width: 150px">email
                            </td>
                            <td style="width: 200px">Comments
                            </td>
                            <td style="width: 150px">
                                <!-- INTRUSION ALARM SERVICES  -->
                                System
                            </td>
                            <td style="width: 150px">Vendor Name
                            </td>
                            <td style="width: 200px">Address 1
                            </td>
                            <td style="width: 200px">Address 2
                            </td>
                            <td style="width: 150px">City
                            </td>
                            <td style="width: 150px">State
                            </td>
                            <td style="width: 150px">Zip
                            </td>
                            <td style="width: 150px">Contact Name
                            </td>
                            <td style="width: 150px">Contract Expiration Date
                            </td>
                            <td style="width: 150px">Telephone Number
                            </td>
                            <td style="width: 150px">Alternet Number
                            </td>
                            <td style="width: 150px">email
                            </td>
                            <td style="width: 200px">Comments
                            </td>
                            <td style="width: 120px">
                                <!-- FENCE -->
                                Razor Wire
                                <br />
                                YES/No
                            </td>
                            <td style="width: 120px">Electrified
                                <br />
                                YES/No
                            </td>
                            <td style="width: 150px">
                                <!-- GENERATOR -->
                                Make
                            </td>
                            <td style="width: 150px">Model
                            </td>
                            <td style="width: 150px">Size
                            </td>
                            <td style="width: 150px">
                                <!-- Fire Department -->
                                Type (Paid/Part Paid/Volunteer)
                            </td>
                            <td style="width: 150px">Distance - Miles
                            </td>
                            <td style="width: 150px">
                                <!--         -->
                                Year Built
                            </td>
                            <td style="width: 150px">Squre Footage
                            </td>
                            <td style="width: 150px">Number of Floors
                            </td>
                            <td style="width: 150px">% Sprink
                            </td>
                            <td style="width: 120px">
                                <!--  CONSTRUCTION OF FLOORS       -->
                                Reinforced Concrete
                            </td>
                            <td style="width: 120px">Poured Concrete
                            </td>
                            <td style="width: 120px">Concrete Panels
                            </td>
                            <td style="width: 120px">Steel Deck
                            </td>
                            <td style="width: 120px">Steel Deck Fastener
                            </td>
                            <td style="width: 120px">Wood Joists
                            </td>
                            <td style="width: 120px">
                                <!--   CONSTRUCTION OF EXTERIOR WALLS     -->
                                Reinforced Concrete
                            </td>
                            <td style="width: 120px">Tilt Up Concrete
                            </td>
                            <td style="width: 120px">Masonry
                            </td>
                            <td style="width: 120px">Glass and Steel Curtain
                            </td>
                            <td style="width: 120px">Corrugated Metal Panels
                            </td>
                            <td style="width: 120px">Wood Frame
                            </td>
                            <td width="120px" id="tdHdItem_1" runat="server" style="display: none">
                                <!-- Insurance Cope --->
                                Item 1 
                            </td>
                            <td width="120px" runat="server" id="tdHdItem_2" style="display: none">Item 2
                            </td>
                            <td width="120px" runat="server" id="tdHdItem_3" style="display: none">Item 3
                            </td>
                            <td width="120px" runat="server" id="tdHdItem_4" style="display: none">Item 4
                            </td>
                            <td width="120px" runat="server" id="tdHdItem_5" style="display: none">Item 5
                            </td>
                            <td width="120px" runat="server" id="tdHdItem_6" style="display: none">Item 6
                            </td>
                            <td width="120px" runat="server" id="tdHdItem_7" style="display: none">Item 7
                            </td>
                            <td width="120px" runat="server" id="tdHdItem_8" style="display: none">Item 8
                            </td>
                            <td width="120px" runat="server" id="tdHdItem_9" style="display: none">Item 9
                            </td>
                            <td width="120px" runat="server" id="tdHdItem_10" style="display: none">Item 10
                            </td>
                            <td width="120px" id="tdHdItem_11" runat="server" style="display: none">Item 11 
                            </td>
                            <td width="120px" runat="server" id="tdHdItem_12" style="display: none">Item 12
                            </td>
                            <td width="120px" runat="server" id="tdHdItem_13" style="display: none">Item 13
                            </td>
                            <td width="120px" runat="server" id="tdHdItem_14" style="display: none">Item 14
                            </td>
                            <td width="120px" runat="server" id="tdHdItem_15" style="display: none">Item 15
                            </td>
                            <td width="120px" runat="server" id="tdHdItem_16" style="display: none">Item 16
                            </td>
                            <td width="120px" runat="server" id="tdHdItem_17" style="display: none">Item 17
                            </td>
                            <td width="120px" runat="server" id="tdHdItem_18" style="display: none">Item 18
                            </td>
                            <td width="120px" runat="server" id="tdHdItem_19" style="display: none">Item 19
                            </td>
                            <td width="120px" runat="server" id="tdHdItem_20" style="display: none">Item 20
                            </td>
                            <td width="120px" runat="server" id="tdHdItem_21" style="display: none">Item 21
                            </td>
                            <td width="120px" runat="server" id="tdHdItem_22" style="display: none">Item 22
                            </td>
                            <td width="120px" runat="server" id="tdHdItem_23" style="display: none">Item 23
                            </td>
                            <td width="120px" runat="server" id="tdHdItem_24" style="display: none">Item 24
                            </td>
                            <td width="120px" runat="server" id="tdHdItem_25" style="display: none">Item 25
                            </td>

                            <td style="width: 120px">
                                <!--    MISC INFORMAION     -->
                                Number of Lifts
                            </td>
                            <td style="width: 120px">Number of Paint Booths
                            </td>
                            <td width="267px">Other Building Comments
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="overflow: scroll; width: 997px; height: 398px;" id="dvGrid" runat="server">
                    <asp:GridView ID="gvDescription" EnableTheming="false" DataKeyNames="Region" runat="server"
                        AutoGenerateColumns="false" Width="100%" HorizontalAlign="Left" GridLines="None"
                        ShowHeader="true" ShowFooter="true" EmptyDataText="No Record Found !" CellPadding="0"
                        CellSpacing="0" OnRowDataBound="gvDescription_RowDataBound">
                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle" />
                        <RowStyle CssClass="RowStyle" HorizontalAlign="Left" />
                        <AlternatingRowStyle CssClass="AlterRowStyle" BackColor="White" HorizontalAlign="Left" />
                        <FooterStyle ForeColor="Black" Font-Bold="true" />
                        <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <table width="16000px" cellpadding="4" cellspacing="0" border="0" style="font-weight: bold; display: none;"
                                        id="tblHeader" runat="server">
                                        <tr>
                                            <td align="left" colspan="2">Sonic Automotive
                                            </td>
                                            <td align="center" colspan="115" runat="server" id="tdGridPropertyHeader">Property Statement of Values Report
                                            </td>
                                            <td align="right" colspan="2">
                                                <%=DateTime.Now.ToString()  %>
                                            </td>
                                        </tr>
                                        <tr style="font-weight: bold;" align="center">
                                            <td colspan="15" style="background: #993300;">LOCATION/ADDRESS INFORMATION
                                            </td>
                                            <td colspan="8" style="background: #000000; color: #ffffff;">OCCUPANCY
                                            </td>
                                            <td colspan="7" style="background: #008000;">FINANCIAL INFORMATION
                                            </td>
                                            <td colspan="12" style="background-color: #9999FF; color: #FFFFFF;">FIRE INSPECTION COMPANY
                                            </td>
                                            <td colspan="13" style="background: #000084; color: #ffffff;">SECURITY GUARD SERVICES
                                            </td>
                                            <td colspan="13" style="background: #FF6500;">INTRUSION ALARM SERVICES
                                            </td>
                                            <td colspan="2" style="background: #840084;">FENCE
                                            </td>
                                            <td colspan="3" style="background: #31CFCF;">GENERATOR
                                            </td>
                                            <td colspan="2" style="background: #ff0000;">FIRE DEPARTMENT
                                            </td>
                                            <td colspan="4" style="background: #ffff00;">&nbsp;
                                            </td>
                                            <td colspan="6" style="background: #31309C; color: #ffffff;">CONSTRUCTION OF FLOORS (Yes to all apply)
                                            </td>
                                            <td colspan="6" style="background: #ff0000;">CONSTRUCTION OF EXTERIOR WALLS (Yes to all apply)
                                            </td>
                                            <td colspan="25" style="background-color: lightgoldenrodyellow;" runat="server" id="tdHeaderInsuranceCope">INSURANCE COPE
                                            </td>
                                            <td colspan="3" style="background: #008284;">MISC INFORMAION
                                            </td>
                                        </tr>
                                        <tr align="left" valign="bottom">
                                            <td style="width: 150px">
                                                <!-- LOCATION/ADDRESS INFORMATION  -->
                                                Region
                                            </td>
                                            <td style="width: 150px">Sonic Location Code
                                            </td>
                                            <td style="width: 180px">Location Name
                                            </td>
                                            <td style="width: 180px">Legal Entity
                                            </td>
                                            <td style="width: 150px">Federal Id
                                            </td>
                                            <td style="width: 150px">Location Status
                                            </td>
                                            <td style="width: 120px">Building #
                                            </td>
                                            <td style="width: 150px">Building Status
                                            </td>
                                            <td style="width: 200px">Address 1
                                            </td>
                                            <td style="width: 200px">Address 2
                                            </td>
                                            <td style="width: 150px">City
                                            </td>
                                            <td style="width: 150px">State
                                            </td>
                                            <td style="width: 150px">Zip Code
                                            </td>
                                            <td style="width: 150px">Country
                                            </td>
                                            <td style="width: 150px">Owned/Leased/Sub Leased/Assigned/ Management Agreement
                                            </td>
                                            <td style="width: 120px">
                                                <!-- OCCUPANCY  -->
                                                Sales - New
                                            </td>
                                            <td style="width: 120px">Sales - Used
                                            </td>
                                            <td style="width: 120px">Services
                                            </td>
                                            <td style="width: 120px">Body Shop
                                            </td>
                                            <td style="width: 120px">Parts
                                            </td>
                                            <td style="width: 120px">Office
                                            </td>
                                            <td style="width: 120px">Parking Lot
                                            </td>
                                            <td style="width: 120px">Row Land
                                            </td>
                                            <td style="width: 150px">
                                                <!-- FINANCIAL INFORMATION  -->
                                                Property Valuation Date
                                            </td>
                                            <td style="width: 150px">Building Limit
                                            </td>
                                            <td style="width: 150px">Associate Tools Limit
                                            </td>
                                            <td style="width: 150px">Contents Limit
                                            </td>
                                            <td style="width: 150px">Parts Limit
                                            </td>
                                            <td style="width: 150px">Business Interruption
                                            </td>
                                            <td style="width: 150px">Total
                                            </td>
                                            <td style="width: 180px">
                                                <!-- FIRE INSPECTION COMPANY -->
                                                Contact Name
                                            </td>
                                            <td style="width: 180px">Vendor Name
                                            </td>
                                            <td style="width: 180px">Contract Expiration Date
                                            </td>
                                            <td style="width: 180px">Address 1
                                            </td>
                                            <td style="width: 180px">Address 2
                                            </td>
                                            <td style="width: 180px">City
                                            </td>
                                            <td style="width: 180px">State
                                            </td>
                                            <td style="width: 180px">Zip
                                            </td>
                                            <td style="width: 180px">Email
                                            </td>
                                            <td style="width: 180px">Telephone Number
                                            </td>
                                            <td style="width: 180px">Alternate Number
                                            </td>
                                            <td style="width: 180px">Comments
                                            </td>
                                            <td style="width: 150px">
                                                <!-- Security Guard Services  -->
                                                System
                                            </td>
                                            <td style="width: 150px">Vendor Name
                                            </td>
                                            <td style="width: 200px">Address 1
                                            </td>
                                            <td style="width: 200px">Address 2
                                            </td>
                                            <td style="width: 150px">City
                                            </td>
                                            <td style="width: 150px">State
                                            </td>
                                            <td style="width: 150px">Zip
                                            </td>
                                            <td style="width: 150px">Contact Name
                                            </td>
                                            <td style="width: 150px">Contract Expiration Date
                                            </td>
                                            <td style="width: 150px">Telephone Number
                                            </td>
                                            <td style="width: 150px">Alternet Number
                                            </td>
                                            <td style="width: 150px">email
                                            </td>
                                            <td style="width: 200px">Comments
                                            </td>
                                            <td style="width: 150px">
                                                <!-- INTRUSION ALARM SERVICES  -->
                                                System
                                            </td>
                                            <td style="width: 150px">Vendor Name
                                            </td>
                                            <td style="width: 200px">Address 1
                                            </td>
                                            <td style="width: 200px">Address 2
                                            </td>
                                            <td style="width: 150px">City
                                            </td>
                                            <td style="width: 150px">State
                                            </td>
                                            <td style="width: 150px">Zip
                                            </td>
                                            <td style="width: 150px">Contact Name
                                            </td>
                                            <td style="width: 150px">Contract Expiration Date
                                            </td>
                                            <td style="width: 150px">Telephone Number
                                            </td>
                                            <td style="width: 150px">Alternet Number
                                            </td>
                                            <td style="width: 150px">email
                                            </td>
                                            <td style="width: 200px">Comments
                                            </td>
                                            <td style="width: 120px">
                                                <!-- FENCE -->
                                                Razor Wire
                                                <br />
                                                YES/No
                                            </td>
                                            <td style="width: 120px">Electrified
                                                <br />
                                                YES/No
                                            </td>
                                            <td style="width: 150px">
                                                <!-- GENERATOR -->
                                                Make
                                            </td>
                                            <td style="width: 150px">Model
                                            </td>
                                            <td style="width: 150px">Size
                                            </td>
                                            <td style="width: 150px">
                                                <!-- Fire Department -->
                                                Type (Paid/Part Paid/Volunteer)
                                            </td>
                                            <td style="width: 150px">Distance - Miles
                                            </td>
                                            <td style="width: 150px">
                                                <!--         -->
                                                Year Built
                                            </td>
                                            <td style="width: 150px">Squre Footage
                                            </td>
                                            <td style="width: 150px">Number of Floors
                                            </td>
                                            <td style="width: 150px">% Sprink
                                            </td>
                                            <td style="width: 120px">
                                                <!--  CONSTRUCTION OF FLOORS       -->
                                                Reinforced Concrete
                                            </td>
                                            <td style="width: 120px">Poured Concrete
                                            </td>
                                            <td style="width: 120px">Concrete Panels
                                            </td>
                                            <td style="width: 120px">Steel Deck
                                            </td>
                                            <td style="width: 120px">Steel Deck Fastener
                                            </td>
                                            <td style="width: 120px">Wood Joists
                                            </td>
                                            <td style="width: 120px">
                                                <!--   CONSTRUCTION OF EXTERIOR WALLS     -->
                                                Reinforced Concrete
                                            </td>
                                            <td style="width: 120px">Tilt Up Concrete
                                            </td>
                                            <td style="width: 120px">Masonry
                                            </td>
                                            <td style="width: 120px">Glass and Steel Curtain
                                            </td>
                                            <td style="width: 120px">Corrugated Metal Panels
                                            </td>
                                            <td style="width: 120px">Wood Frame
                                            </td>
                                            <td width="120px" runat="server" id="tdHdItem1" style="display: none">Item 1
                                            </td>
                                            <td width="120px" runat="server" id="tdHdItem2" style="display: none">Item 2
                                            </td>
                                            <td width="120px" runat="server" id="tdHdItem3" style="display: none">Item 3
                                            </td>
                                            <td width="120px" runat="server" id="tdHdItem4" style="display: none">Item 4
                                            </td>
                                            <td width="120px" runat="server" id="tdHdItem5" style="display: none">Item 5
                                            </td>
                                            <td width="120px" runat="server" id="tdHdItem6" style="display: none">Item 6
                                            </td>
                                            <td width="120px" runat="server" id="tdHdItem7" style="display: none">Item 7
                                            </td>
                                            <td width="120px" runat="server" id="tdHdItem8" style="display: none">Item 8
                                            </td>
                                            <td width="120px" runat="server" id="tdHdItem9" style="display: none">Item 9
                                            </td>
                                            <td width="120px" runat="server" id="tdHdItem10" style="display: none">Item 10
                                            </td>
                                            <td width="120px" runat="server" id="tdHdItem11" style="display: none">Item 11
                                            </td>
                                            <td width="120px" runat="server" id="tdHdItem12" style="display: none">Item 12
                                            </td>
                                            <td width="120px" runat="server" id="tdHdItem13" style="display: none">Item 13
                                            </td>
                                            <td width="120px" runat="server" id="tdHdItem14" style="display: none">Item 14
                                            </td>
                                            <td width="120px" runat="server" id="tdHdItem15" style="display: none">Item 15
                                            </td>
                                            <td width="120px" runat="server" id="tdHdItem16" style="display: none">Item 16
                                            </td>
                                            <td width="120px" runat="server" id="tdHdItem17" style="display: none">Item 17
                                            </td>
                                            <td width="120px" runat="server" id="tdHdItem18" style="display: none">Item 18
                                            </td>
                                            <td width="120px" runat="server" id="tdHdItem19" style="display: none">Item 19
                                            </td>
                                            <td width="120px" runat="server" id="tdHdItem20" style="display: none">Item 20
                                            </td>
                                            <td width="120px" runat="server" id="tdHdItem21" style="display: none">Item 21
                                            </td>
                                            <td width="120px" runat="server" id="tdHdItem22" style="display: none">Item 22
                                            </td>
                                            <td width="120px" runat="server" id="tdHdItem23" style="display: none">Item 23
                                            </td>
                                            <td width="120px" runat="server" id="tdHdItem24" style="display: none">Item 24
                                            </td>
                                            <td width="120px" runat="server" id="tdHdItem25" style="display: none">Item 25
                                            </td>
                                            <td style="width: 120px">
                                                <!--    MISC INFORMAION     -->
                                                Number of Lifts
                                            </td>
                                            <td style="width: 120px">Number of Paint Booths
                                            </td>
                                            <td width="267px">Other Building Comments
                                            </td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table width="16000px" cellpadding="4" cellspacing="0" border="1" id="tblHeader"
                                        runat="server">
                                        <tr align="left" valign="top">
                                            <td style="width: 150px">
                                                <asp:Label ID="lblRegion" runat="server" Text='<%# Eval("Region") %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("Sonic_Location_Code") %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 180px">
                                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("Location_Name") %>' Width="180px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 180px">
                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("Legal_Entity") %>' Width="180px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label7" runat="server" Text='<%# Eval("Federal_id") %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label8" runat="server" Text='<%# Eval("Location_Status") %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 120px">
                                                <asp:Label ID="Label9" runat="server" Text='<%# Eval("Building") %>' Width="120px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label10" runat="server" Text='<%# Eval("Building_Status") %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 200px">
                                                <asp:Label runat="server" ID="lblAddress1" Width="200px"> <%# Eval("Address1")%></asp:Label>
                                            </td>
                                            <td style="width: 200px">
                                                <asp:Label runat="server" ID="lblAddress2" Width="200px"><%# Eval("Address2")%></asp:Label>
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label11" runat="server" Text='<%# Eval("City") %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label12" runat="server" Text='<%# Eval("State") %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label13" runat="server" Text='<%# Eval("Zip_Code") %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label14" runat="server" Text='<%# Eval("County") %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label15" runat="server" Text='<%# Eval("Ownership") %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 120px">
                                                <!-- OCCUPANCY  -->
                                                <asp:Label ID="Label16" runat="server" Text='<%# Eval("Sales_New") %>' Width="120px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 120px">
                                                <asp:Label ID="Label17" runat="server" Text='<%# Eval("Sales_Used") %>' Width="120px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 120px">
                                                <asp:Label ID="Label18" runat="server" Text='<%# Eval("Service") %>' Width="120px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 120px">
                                                <asp:Label ID="Label19" runat="server" Text='<%# Eval("Body_Shop") %>' Width="120px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 120px">
                                                <asp:Label ID="Label20" runat="server" Text='<%# Eval("Parts") %>' Width="120px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 120px">
                                                <asp:Label ID="Label21" runat="server" Text='<%# Eval("Office") %>' Width="120px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 120px">
                                                <asp:Label ID="Label22" runat="server" Text='<%# Eval("Parking_Lot") %>' Width="120px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 120px">
                                                <asp:Label ID="Label23" runat="server" Text='<%# Eval("Raw_Land") %>' Width="120px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 150px">
                                                <!-- FINANCIAL INFORMATION  -->
                                                <asp:Label ID="Label24" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Property_Valuation_Date")) %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td width="150px">
                                                <asp:Label ID="Label25" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Building_Limit")) %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td width="150px">
                                                <asp:Label ID="Label26" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Associate_Tools_Limit")) %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td width="150px">
                                                <asp:Label ID="Label27" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Contents_Limit")) %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td width="150px">
                                                <asp:Label ID="Label28" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Parts_Limit")) %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td width="150px">
                                                <asp:Label ID="Label29" runat="server" Text='<%#String.Format("{0:C2}",Eval("Business_Interruption"))%>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td width="150px">
                                                <asp:Label ID="Label30" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Total")) %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 180px">
                                                <asp:Label ID="Label31" runat="server" Text='<%# Eval("Fire_Contact_Name") %>' Width="180px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 180px">
                                                <asp:Label ID="Label32" runat="server" Text='<%# Eval("Fire_Vendor_Name") %>' Width="180px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 180px">
                                                <asp:Label ID="Label33" runat="server" Text=' <%# string.IsNullOrEmpty(Convert.ToString(Eval("Fire_Contact_Expiration_Date "))) ? string.Empty : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Fire_Contact_Expiration_Date ")))%>' Width="180px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 180px">
                                                <asp:Label ID="Label34" runat="server" Text='<%# Eval("Fire_Address_1") %>' Width="180px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 180px">
                                                <asp:Label ID="Label35" runat="server" Text='<%# Eval("Fire_Address_2") %>' Width="180px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 180px">
                                                <asp:Label ID="Label36" runat="server" Text='<%# Eval("Fire_City") %>' Width="180px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 180px">
                                                <asp:Label ID="Label37" runat="server" Text='<%# Eval("Fire_State") %>' Width="180px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 180px">
                                                <asp:Label ID="Label38" runat="server" Text='<%# Eval("Fire_Zip") %>' Width="180px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 180px">
                                                <asp:Label ID="Label39" runat="server" Text='<%# Eval("Fire_Email") %>' Width="180px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 180px">
                                                <asp:Label ID="Label40" runat="server" Text='<%# Eval("Fire_Telephone_Number") %>' Width="180px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 180px">
                                                <asp:Label ID="Label41" runat="server" Text='<%# Eval("Fire_Alternate_Number") %>' Width="180px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 180px">
                                                <asp:Label ID="Label42" runat="server" Text='<%# Eval("Fire_Comments") %>' Width="180px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 150px">
                                                <!-- Security Guard Services  -->
                                                <asp:Label ID="Label43" runat="server" Text='<%# Eval("System") %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label44" runat="server" Text='<%# Eval("Vendor_Name") %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 200px">
                                                <asp:Label runat="server" ID="lblGuard_Address_1" Width="200px"><%# Eval("Guard_Address_1")%></asp:Label>
                                            </td>
                                            <td style="width: 200px">
                                                <asp:Label runat="server" ID="lblGuard_Address_2" Width="200px"><%# Eval("Guard_Address_2")%></asp:Label>
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label45" runat="server" Text='<%# Eval("Guard_City") %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label46" runat="server" Text='<%# Eval("Guard_State") %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label47" runat="server" Text='<%# Eval("Guard_Zip") %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label48" runat="server" Text='<%# Eval("Contact_Name") %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label49" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Guard_Expiration_Date"))%>' Width="150px"></asp:Label>
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label50" runat="server" Text='<%# Eval("Guard_Telephone_Number") %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label51" runat="server" Text='<%# Eval("Guard_Alternate_Number") %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label52" runat="server" Text='<%# Eval("Guard_Email") %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 200px">
                                                <asp:Label runat="server" ID="lblGuard_Comments" CssClass="TextClip" Width="200px"><%# Eval("Guard_Comments")%></asp:Label>
                                            </td>
                                            <td style="width: 150px">
                                                <!-- Security Guard Services  -->
                                                <asp:Label ID="Label53" runat="server" Text='<%# Eval("Intru_System_Name") %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label54" runat="server" Text='<%# Eval("Intru_Vendor_Name") %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 200px">
                                                <asp:Label runat="server" ID="Label1" Width="200"><%# Eval("Intru_Address_1")%></asp:Label>
                                            </td>
                                            <td style="width: 200px">
                                                <asp:Label runat="server" ID="Label2" Width="200"><%# Eval("Intru_Address_2")%></asp:Label>
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label55" runat="server" Text='<%# Eval("Intru_City") %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label56" runat="server" Text='<%# Eval("Intru_State") %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label57" runat="server" Text='<%# Eval("Intru_Zip") %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label58" runat="server" Text='<%# Eval("Intru_Contact_Name") %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label59" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Intru_Contract_Expiration_Date"))%>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label60" runat="server" Text='<%# Eval("Intru_Telephone_Number") %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label61" runat="server" Text='<%# Eval("Intru_Alternate_Number") %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label62" runat="server" Text='<%# Eval("Intru_Email") %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 200px">
                                                <asp:Label runat="server" ID="Label3" CssClass="TextClip" Width="200"><%# Eval("Intru_Comments")%></asp:Label>
                                            </td>
                                            <td style="width: 120px">
                                                <!-- FENCE -->
                                                <asp:Label ID="Label63" runat="server" Text='<%# Eval("Fence_Razor_Wire") %>' Width="120px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 120px">
                                                <asp:Label ID="Label64" runat="server" Text='<%# Eval("Fence_Electrified") %>' Width="120px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 150px">
                                                <!-- GENERATOR -->
                                                <asp:Label ID="Label65" runat="server" Text='<%# Eval("Generator_Make") %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label66" runat="server" Text='<%# Eval("Generator_Model") %>' Width="150px"></asp:Label>
                                                
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label67" runat="server" Text='<%# Eval("Generator_Size") %>' Width="150px"></asp:Label>
                                            </td>
                                            <td style="width: 150px">
                                                <!-- Fire Department-->
                                                <asp:Label ID="Label68" runat="server" Text='<%# Eval("Fire_Department_Type") %>' Width="150px"></asp:Label>
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label69" runat="server" Text='<%# Eval("Fire_Department_Distance") %>' Width="150px"></asp:Label>
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label70" runat="server" Text='<%# Eval("Year_Built") %>' Width="150px"></asp:Label>
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label71" runat="server" Text='<%# Eval("Square_Footage") %>' Width="150px"></asp:Label>
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label72" runat="server" Text='<%# Eval("Number_Of_Stories") %>' Width="150px"></asp:Label>
                                            </td>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label73" runat="server" Text='<%# Eval("Percent_Sprinklered") %>' Width="150px"></asp:Label>
                                            </td>
                                            <td style="width: 120px">
                                                <!--  CONSTRUCTION OF FLOORS       -->
                                                <asp:Label ID="Label74" runat="server" Text='<%# Eval("Roof_Reinforced_Concrete") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td style="width: 120px">
                                                <asp:Label ID="Label75" runat="server" Text='<%# Eval("Roof_Poured_Concrete") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td style="width: 120px">
                                                <asp:Label ID="Label76" runat="server" Text='<%# Eval("Roof_Concrete_Panels") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td style="width: 120px">
                                                <asp:Label ID="Label77" runat="server" Text='<%# Eval("Roof_Steel_Deck") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td style="width: 120px">
                                                <asp:Label ID="Label78" runat="server" Text='<%# Eval("Roof_Steel_Deck_With_Fasteners") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td style="width: 120px">
                                                <asp:Label ID="Label79" runat="server" Text='<%# Eval("Roof_Wood_Joists") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td style="width: 120px">
                                                <!--   CONSTRUCTION OF EXTERIOR WALLS     -->
                                                <asp:Label ID="Label80" runat="server" Text='<%# Eval("Ext_Walls_Reinforced_Concrete") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td style="width: 120px">
                                                <asp:Label ID="Label81" runat="server" Text='<%# Eval("Ext_Walls_Tilt_Up_Concrete") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td style="width: 120px">
                                                <asp:Label ID="Label82" runat="server" Text='<%# Eval("Ext_Walls_Masonary") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td style="width: 120px">
                                                <asp:Label ID="Label83" runat="server" Text='<%# Eval("Ext_Walls_Glass_And_Steel_Curtain") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td style="width: 120px">
                                                <asp:Label ID="Label84" runat="server" Text='<%# Eval("Ext_Walls_Corrugated_Metal_Panels") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td style="width: 120px">
                                                <asp:Label ID="Label85" runat="server" Text='<%# Eval("Ext_Walls_Wood_Frame") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td width="120px" runat="server" id="tdItem_1" style="display: none">
                                                <!-- Insurance Cope -->
                                                <asp:Label ID="Label86" runat="server" Text='<%# Eval("Item_1") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td width="120px" runat="server" id="tdItem_2" style="display: none">
                                                <asp:Label ID="Label87" runat="server" Text='<%# Eval("Item_2") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td width="120px" runat="server" id="tdItem_3" style="display: none">
                                                <asp:Label ID="Label88" runat="server" Text='<%# Eval("Item_3") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td width="120px" runat="server" id="tdItem_4" style="display: none">
                                                <asp:Label ID="Label89" runat="server" Text='<%# Eval("Item_4") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td width="120px" runat="server" id="tdItem_5" style="display: none">
                                                <asp:Label ID="Label90" runat="server" Text='<%# Eval("Item_5") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td width="120px" runat="server" id="tdItem_6" style="display: none">
                                                <asp:Label ID="Label91" runat="server" Text='<%# Eval("Item_6") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td width="120px" runat="server" id="tdItem_7" style="display: none">
                                                <asp:Label ID="Label92" runat="server" Text='<%# Eval("Item_7") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td width="120px" runat="server" id="tdItem_8" style="display: none">
                                                <asp:Label ID="Label93" runat="server" Text='<%# Eval("Item_8") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td width="120px" runat="server" id="tdItem_9" style="display: none">
                                                <asp:Label ID="Label94" runat="server" Text='<%# Eval("Item_9") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td width="120px" runat="server" id="tdItem_10" style="display: none">
                                                <asp:Label ID="Label95" runat="server" Text='<%# Eval("Item_10") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td width="120px" runat="server" id="tdItem_11" style="display: none">
                                                <asp:Label ID="Label96" runat="server" Text='<%# Eval("Item_11") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td width="120px" runat="server" id="tdItem_12" style="display: none">
                                                <asp:Label ID="Label97" runat="server" Text='<%# Eval("Item_12") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td width="120px" runat="server" id="tdItem_13" style="display: none">
                                                <asp:Label ID="Label98" runat="server" Text='<%# Eval("Item_13") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td width="120px" runat="server" id="tdItem_14" style="display: none">
                                                <asp:Label ID="Label99" runat="server" Text='<%# Eval("Item_14") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td width="120px" runat="server" id="tdItem_15" style="display: none">
                                                <asp:Label ID="Label100" runat="server" Text='<%# Eval("Item_15") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td width="120px" runat="server" id="tdItem_16" style="display: none">
                                                <asp:Label ID="Label101" runat="server" Text='<%# Eval("Item_16") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td width="120px" runat="server" id="tdItem_17" style="display: none">
                                                <asp:Label ID="Label102" runat="server" Text='<%# Eval("Item_17") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td width="120px" runat="server" id="tdItem_18" style="display: none">
                                                <asp:Label ID="Label103" runat="server" Text='<%# Eval("Item_18") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td width="120px" runat="server" id="tdItem_19" style="display: none">
                                                <asp:Label ID="Label104" runat="server" Text='<%# Eval("Item_19") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td width="120px" runat="server" id="tdItem_20" style="display: none">
                                                <asp:Label ID="Label105" runat="server" Text='<%# Eval("Item_20") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td width="120px" runat="server" id="tdItem_21" style="display: none">
                                                <asp:Label ID="Label106" runat="server" Text='<%# Eval("Item_21") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td width="120px" runat="server" id="tdItem_22" style="display: none">
                                                <asp:Label ID="Label107" runat="server" Text='<%# Eval("Item_22") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td width="120px" runat="server" id="tdItem_23" style="display: none">
                                                <asp:Label ID="Label108" runat="server" Text='<%# Eval("Item_23") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td width="120px" runat="server" id="tdItem_24" style="display: none">
                                                <asp:Label ID="Label109" runat="server" Text='<%# Eval("Item_24") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td width="120px" runat="server" id="tdItem_25" style="display: none">
                                                <asp:Label ID="Label110" runat="server" Text='<%# Eval("Item_25") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td style="width: 120px">
                                                <!--    MISC INFORMAION     -->
                                                <asp:Label ID="Label111" runat="server" Text='<%# Eval("Number_Of_Lifts") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td style="width: 120px">
                                                <asp:Label ID="Label112" runat="server" Text='<%# Eval("Number_Of_Paint_Booths") %>' Width="120px"></asp:Label>
                                            </td>
                                            <td width="267px">
                                                <asp:Label Width="240px" runat="server" ID="lblOtherBuildingComments" Text='<%# Eval("Comments")%>' CssClass="TextClip"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>

            </td>
        </tr>--%>
        <tr>
            <td>
                <div style="overflow: scroll; width: 997px; height: 398px;">
                    <asp:GridView ID="gvDescription_New" EnableTheming="false" runat="server"
                        AutoGenerateColumns="false" Width="100%" HorizontalAlign="Left" GridLines="Both"
                        ShowHeader="true" ShowFooter="false" EmptyDataText="No Record Found !" CellPadding="0"
                        OnDataBound="gvDescription_New_DataBound" OnRowDataBound="gvDescription_New_RowDataBound">
                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle" />
                        <RowStyle CssClass="RowStyle" HorizontalAlign="Left" />
                        <AlternatingRowStyle CssClass="AlterRowStyle" BackColor="White" HorizontalAlign="Left" />
                        <FooterStyle ForeColor="Black" Font-Bold="true" />
                        <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" />
                        <Columns>
                            <asp:TemplateField HeaderText="Region" ItemStyle-Height="25px" HeaderStyle-Height="55px">
                                <ItemTemplate>
                                    <asp:Label ID="lblRegion" runat="server" Text='<%# Eval("Region") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Sonic Location Code">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Sonic_Location_Code") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Location Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("Location_Name") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Legal Entity">
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("Legal_Entity") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Federal Id">
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("Federal_id") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Location Status">
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("Location_Status") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Building #">
                                <ItemTemplate>
                                    <asp:Label ID="Label9" runat="server" Text='<%# Eval("Building") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Building Status">
                                <ItemTemplate>
                                    <asp:Label ID="Label10" runat="server" Text='<%# Eval("Building_Status") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address 1">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblAddress1" Width="200px"><%# Eval("Address1")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address 2">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblAddress2" Width="200px"><%# Eval("Address2")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="City">
                                <ItemTemplate>
                                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("City") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="State">
                                <ItemTemplate>
                                    <asp:Label ID="Label12" runat="server" Text='<%# Eval("State") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Zip Code">
                                <ItemTemplate>
                                    <asp:Label ID="Label13" runat="server" Text='<%# Eval("Zip_Code") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="County">
                                <ItemTemplate>
                                    <asp:Label ID="Label14" runat="server" Text='<%# Eval("County") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Owned/Leased/Sub Leased/Assigned/ Management Agreement">
                                <ItemTemplate>
                                    <asp:Label ID="Label15" runat="server" Text='<%# Eval("Ownership") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sales - New">
                                <ItemTemplate>
                                    <asp:Label ID="Label16" runat="server" Text='<%# Eval("Sales_New") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sales - Used">
                                <ItemTemplate>
                                    <asp:Label ID="Label17" runat="server" Text='<%# Eval("Sales_Used") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Services">
                                <ItemTemplate>
                                    <asp:Label ID="Label18" runat="server" Text='<%# Eval("Service") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Body Shop">
                                <ItemTemplate>
                                    <asp:Label ID="Label19" runat="server" Text='<%# Eval("Body_Shop") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Parts">
                                <ItemTemplate>
                                    <asp:Label ID="Label20" runat="server" Text='<%# Eval("Parts") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Office">
                                <ItemTemplate>
                                    <asp:Label ID="Label21" runat="server" Text='<%# Eval("Office") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Parking Lot">
                                <ItemTemplate>
                                    <asp:Label ID="Label22" runat="server" Text='<%# Eval("Parking_Lot") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Row Land">
                                <ItemTemplate>
                                    <asp:Label ID="Label23" runat="server" Text='<%# Eval("Raw_Land") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Property Valuation Date">
                                <ItemTemplate>
                                    <asp:Label ID="Label24" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Property_Valuation_Date")) %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="RS Means Building Limit">
                                <ItemTemplate>
                                    <asp:Label ID="Label25" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Building_Limit")) %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Associate Tools Limit">
                                <ItemTemplate>
                                    <asp:Label ID="Label26" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Associate_Tools_Limit")) %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Contents Limit">
                                <ItemTemplate>
                                    <asp:Label ID="Label27" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Contents_Limit")) %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Parts Limit">
                                <ItemTemplate>
                                    <asp:Label ID="Label28" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Parts_Limit")) %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Business Interruption">
                                <ItemTemplate>
                                    <asp:Label ID="Label29" runat="server" Text='<%#String.Format("{0:C2}",Eval("Business_Interruption"))%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Total">
                                <ItemTemplate>
                                    <asp:Label ID="Label30" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Total")) %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Contact Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label31" runat="server" Text='<%# Eval("Fire_Contact_Name") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Vendor Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label32" runat="server" Text='<%# Eval("Fire_Vendor_Name") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contract Expiration Date">
                                <ItemTemplate>
                                    <asp:Label ID="Label33" runat="server" Text=' <%# string.IsNullOrEmpty(Convert.ToString(Eval("Fire_Contact_Expiration_Date "))) ? string.Empty : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Fire_Contact_Expiration_Date ")))%>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address 1">
                                <ItemTemplate>
                                    <asp:Label ID="Label34" runat="server" Text='<%# Eval("Fire_Address_1") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address 2">
                                <ItemTemplate>
                                    <asp:Label ID="Label35" runat="server" Text='<%# Eval("Fire_Address_2") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="City">
                                <ItemTemplate>
                                    <asp:Label ID="Label36" runat="server" Text='<%# Eval("Fire_City") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="State">
                                <ItemTemplate>
                                    <asp:Label ID="Label37" runat="server" Text='<%# Eval("Fire_State") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Zip">
                                <ItemTemplate>
                                    <asp:Label ID="Label38" runat="server" Text='<%# Eval("Fire_Zip") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email">
                                <ItemTemplate>
                                    <asp:Label ID="Label39" runat="server" Text='<%# Eval("Fire_Email") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Telephone Number">
                                <ItemTemplate>
                                    <asp:Label ID="Label40" runat="server" Text='<%# Eval("Fire_Telephone_Number") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Alternate Number">
                                <ItemTemplate>
                                    <asp:Label ID="Label41" runat="server" Text='<%# Eval("Fire_Alternate_Number") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Comments">
                                <ItemTemplate>
                                    <asp:Label ID="Label42" runat="server" Text='<%# Eval("Fire_Comments") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="System">
                                <ItemTemplate>
                                    <asp:Label ID="Label43" runat="server" Text='<%# Eval("System") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Vendor Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label44" runat="server" Text='<%# Eval("Vendor_Name") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address 1">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblGuard_Address_1" Width="200px"><%# Eval("Guard_Address_1")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address 2">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblGuard_Address_2" Width="200px"><%# Eval("Guard_Address_2")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="City">
                                <ItemTemplate>
                                    <asp:Label ID="Label45" runat="server" Text='<%# Eval("Guard_City") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="State">
                                <ItemTemplate>
                                    <asp:Label ID="Label46" runat="server" Text='<%# Eval("Guard_State") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Zip">
                                <ItemTemplate>
                                    <asp:Label ID="Label47" runat="server" Text='<%# Eval("Guard_Zip") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label48" runat="server" Text='<%# Eval("Contact_Name") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contract Expiration Date">
                                <ItemTemplate>
                                    <asp:Label ID="Label49" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Guard_Expiration_Date"))%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Telephone Number">
                                <ItemTemplate>
                                    <asp:Label ID="Label50" runat="server" Text='<%# Eval("Guard_Telephone_Number") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Alternet Number ">
                                <ItemTemplate>
                                    <asp:Label ID="Label51" runat="server" Text='<%# Eval("Guard_Alternate_Number") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email">
                                <ItemTemplate>
                                    <asp:Label ID="Label52" runat="server" Text='<%# Eval("Guard_Email") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Comments">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblGuard_Comments" CssClass="TextClip" Width="200px"><%# Eval("Guard_Comments")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="System">
                                <ItemTemplate>
                                    <asp:Label ID="Label53" runat="server" Text='<%# Eval("Intru_System_Name") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Vendor Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label54" runat="server" Text='<%# Eval("Intru_Vendor_Name") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address 1">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="Label1" Width="200"><%# Eval("Intru_Address_1")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address 2">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="Label2" Width="200"><%# Eval("Intru_Address_2")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="City">
                                <ItemTemplate>
                                    <asp:Label ID="Label55" runat="server" Text='<%# Eval("Intru_City") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="State">
                                <ItemTemplate>
                                    <asp:Label ID="Label56" runat="server" Text='<%# Eval("Intru_State") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Zip">
                                <ItemTemplate>
                                    <asp:Label ID="Label57" runat="server" Text='<%# Eval("Intru_Zip") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label58" runat="server" Text='<%# Eval("Intru_Contact_Name") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contract Expiration Date">
                                <ItemTemplate>
                                    <asp:Label ID="Label59" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Intru_Contract_Expiration_Date"))%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Telephone Number">
                                <ItemTemplate>
                                    <asp:Label ID="Label60" runat="server" Text='<%# Eval("Intru_Telephone_Number") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Alternet Number">
                                <ItemTemplate>
                                    <asp:Label ID="Label61" runat="server" Text='<%# Eval("Intru_Alternate_Number") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email">
                                <ItemTemplate>
                                    <asp:Label ID="Label62" runat="server" Text='<%# Eval("Intru_Email") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Comments">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="Label3" CssClass="TextClip" Width="200"><%# Eval("Intru_Comments")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Razor Wire </br> YES/No">
                                <ItemTemplate>
                                    <asp:Label ID="Label63" runat="server" Text='<%# Eval("Fence_Razor_Wire") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Electrified </br> YES/No">
                                <ItemTemplate>
                                    <asp:Label ID="Label64" runat="server" Text='<%# Eval("Fence_Electrified") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Make">
                                <ItemTemplate>
                                    <asp:Label ID="Label65" runat="server" Text='<%# Eval("Generator_Make") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Model">
                                <ItemTemplate>
                                    <asp:Label ID="Label66" runat="server" Text='<%# Eval("Generator_Model") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Size">
                                <ItemTemplate>
                                    <asp:Label ID="Label67" runat="server" Text='<%# Eval("Generator_Size") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Type (Paid/Part Paid/Volunteer)">
                                <ItemTemplate>
                                    <asp:Label ID="Label68" runat="server" Text='<%# Eval("Fire_Department_Type") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Distance - Miles">
                                <ItemTemplate>
                                    <asp:Label ID="Label69" runat="server" Text='<%# Eval("Fire_Department_Distance") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Year Built">
                                <ItemTemplate>
                                    <asp:Label ID="Label70" runat="server" Text='<%# Eval("Year_Built") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Squre Footage">
                                <ItemTemplate>
                                    <asp:Label ID="Label71" runat="server" Text='<%# Eval("Square_Footage") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Number of Floors">
                                <ItemTemplate>
                                    <asp:Label ID="Label72" runat="server" Text='<%# Eval("Number_Of_Stories") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="% Sprink">
                                <ItemTemplate>
                                    <asp:Label ID="Label73" runat="server" Text='<%# Eval("Percent_Sprinklered") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Reinforced Concrete">
                                <ItemTemplate>
                                    <asp:Label ID="Label74" runat="server" Text='<%# Eval("Roof_Reinforced_Concrete") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Poured Concrete">
                                <ItemTemplate>
                                    <asp:Label ID="Label75" runat="server" Text='<%# Eval("Roof_Poured_Concrete") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Concrete Panels">
                                <ItemTemplate>
                                    <asp:Label ID="Label76" runat="server" Text='<%# Eval("Roof_Concrete_Panels") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Steel Deck">
                                <ItemTemplate>
                                    <asp:Label ID="Label77" runat="server" Text='<%# Eval("Roof_Steel_Deck") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Steel Deck Fastener">
                                <ItemTemplate>
                                    <asp:Label ID="Label78" runat="server" Text='<%# Eval("Roof_Steel_Deck_With_Fasteners") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Wood Joists">
                                <ItemTemplate>
                                    <asp:Label ID="Label79" runat="server" Text='<%# Eval("Roof_Wood_Joists") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Reinforced Concrete">
                                <ItemTemplate>
                                    <asp:Label ID="Label80" runat="server" Text='<%# Eval("Ext_Walls_Reinforced_Concrete") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tilt Up Concrete">
                                <ItemTemplate>
                                    <asp:Label ID="Label81" runat="server" Text='<%# Eval("Ext_Walls_Tilt_Up_Concrete") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Masonry">
                                <ItemTemplate>
                                    <asp:Label ID="Label82" runat="server" Text='<%# Eval("Ext_Walls_Masonary") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Glass and Steel Curtain">
                                <ItemTemplate>
                                    <asp:Label ID="Label83" runat="server" Text='<%# Eval("Ext_Walls_Glass_And_Steel_Curtain") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Corrugated Metal Panels">
                                <ItemTemplate>
                                    <asp:Label ID="Label84" runat="server" Text='<%# Eval("Ext_Walls_Corrugated_Metal_Panels") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Wood Frame">
                                <ItemTemplate>
                                    <asp:Label ID="Label85" runat="server" Text='<%# Eval("Ext_Walls_Wood_Frame") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="Label86" runat="server" Text='<%# Eval("Item_1") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="Label87" runat="server" Text='<%# Eval("Item_2") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="Label88" runat="server" Text='<%# Eval("Item_3") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="Label89" runat="server" Text='<%# Eval("Item_4") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="Label90" runat="server" Text='<%# Eval("Item_5") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="Label91" runat="server" Text='<%# Eval("Item_6") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="Label92" runat="server" Text='<%# Eval("Item_7") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="Label93" runat="server" Text='<%# Eval("Item_8") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="Label94" runat="server" Text='<%# Eval("Item_9") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="Label95" runat="server" Text='<%# Eval("Item_10") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="Label96" runat="server" Text='<%# Eval("Item_11") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="Label97" runat="server" Text='<%# Eval("Item_12") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="Label98" runat="server" Text='<%# Eval("Item_13") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="Label99" runat="server" Text='<%# Eval("Item_14") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="Label100" runat="server" Text='<%# Eval("Item_15") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="Label101" runat="server" Text='<%# Eval("Item_16") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="Label102" runat="server" Text='<%# Eval("Item_17") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="Label103" runat="server" Text='<%# Eval("Item_18") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="Label104" runat="server" Text='<%# Eval("Item_19") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="Label105" runat="server" Text='<%# Eval("Item_20") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="Label106" runat="server" Text='<%# Eval("Item_21") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="Label107" runat="server" Text='<%# Eval("Item_22") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="Label108" runat="server" Text='<%# Eval("Item_23") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="Label109" runat="server" Text='<%# Eval("Item_24") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="Label110" runat="server" Text='<%# Eval("Item_25") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Number of Lifts">
                                <ItemTemplate>
                                    <asp:Label ID="Label111" runat="server" Text='<%# Eval("Number_Of_Lifts") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Number of Paint Booths">
                                <ItemTemplate>
                                    <asp:Label ID="Label112" runat="server" Text='<%# Eval("Number_Of_Paint_Booths") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Other Building Comments  ">
                                <ItemTemplate>
                                    <asp:Label Width="240px" runat="server" ID="lblOtherBuildingComments" Text='<%# Eval("Comments")%>' CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 15px;"></td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button runat="server" ID="btnBack" OnClick="btnBack_Click" Text="Back" />
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 10px;"></td>
        </tr>
    </table>
</asp:Content>
