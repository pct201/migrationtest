<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="rptSubleaseReport.aspx.cs" Inherits="SONIC_RealEstate_rptSubleaseReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        CssClass="errormessage"></asp:ValidationSummary>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>
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
            <td width="100%" class="Spacer" style="height: 3px;" colspan="2">
            </td>
        </tr>
        <tr>
            <td align="left" class="ghc" colspan="2">
                Sublease Report
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 3px;" colspan="2">
            </td>
        </tr>
        <tr runat="server" id="trCriteria">
            <td width="2%">
                &nbsp;
            </td>
            <td align="center">
                <table width="83%" align="center" style="text-align: left;" cellpadding="2" cellspacing="3"
                    border="0">
                    <tr valign="top" align="left">
                        <td>
                            Region
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td align="left" colspan="4">
                            <asp:ListBox ID="lstLocation" runat="server" SelectionMode="Multiple" Width="250px">
                            </asp:ListBox>
                        </td>
                    </tr>
                    <tr valign="top" align="left">
                        <td>
                            Market
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td align="left" colspan="4">
                            <asp:ListBox ID="lstMarket" runat="server" SelectionMode="Multiple" Width="250px">
                            </asp:ListBox>
                        </td>
                    </tr>
                    <tr valign="top" align="left">
                        <td style="width: 20%;">
                            LCD From
                        </td>
                        <td align="right" style="width: 3%;">
                            :
                        </td>
                        <td style="width: 37%;">
                            <asp:TextBox ID="txtLCDateFrom" runat="server" MaxLength="10" SkinID="txtDate"></asp:TextBox>
                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtLCDateFrom.ClientID%>', 'mm/dd/y');"
                                alt="Lease Commence Date From" src="../../Images/iconPicDate.gif" align="middle" />
                            <asp:RegularExpressionValidator ID="rvtxtLCDateFrom" runat="server" ControlToValidate="txtLCDateFrom"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                ErrorMessage="LCD From is Not Valid Date." Display="none" SetFocusOnError="true">
                            </asp:RegularExpressionValidator>
                        </td>
                        <td style="width: 7%;">
                            &nbsp;&nbsp;&nbsp;To
                        </td>
                        <td align="right" style="width: 3%;">
                            :
                        </td>
                        <td style="width: 30%;">
                            <asp:TextBox ID="txtLCDateTo" runat="server" MaxLength="10" SkinID="txtDate"></asp:TextBox>
                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtLCDateTo.ClientID%>', 'mm/dd/y');"
                                alt="Lease Commence Date To" src="../../Images/iconPicDate.gif" align="middle" />
                            <asp:RegularExpressionValidator ID="revtxtLCDateTo" runat="server" ControlToValidate="txtLCDateTo"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                ErrorMessage="LCD To is Not Valid Date." Display="none" SetFocusOnError="true"> 
                            </asp:RegularExpressionValidator>
                            <asp:CompareValidator ID="cfvLCD" runat="server" ControlToCompare="txtLCDateFrom"
                                Display="None" Type="Date" Operator="GreaterThanEqual" ControlToValidate="txtLCDateTo"
                                ErrorMessage="LCD From Date must be Less Than Or Equal To LCD To Date." SetFocusOnError="true"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr valign="top" align="left">
                        <td>
                            LED From
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtLEDateFrom" runat="server" MaxLength="10" SkinID="txtDate"></asp:TextBox>
                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtLEDateFrom.ClientID%>', 'mm/dd/y');"
                                alt="Lease Expiration Date From" src="../../Images/iconPicDate.gif" align="middle" />
                            <asp:RegularExpressionValidator ID="revtxtLEDateFrom" runat="server" ControlToValidate="txtLEDateFrom"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                ErrorMessage="LED From is Not Valid Date." Display="none" SetFocusOnError="true">
                            </asp:RegularExpressionValidator>
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;To
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtLEDateTo" runat="server" MaxLength="10" SkinID="txtDate"></asp:TextBox>
                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtLEDateTo.ClientID%>', 'mm/dd/y');"
                                alt="Lease Expiration Date To" src="../../Images/iconPicDate.gif" align="middle" />
                            <asp:RegularExpressionValidator ID="revtxtLEDateTo" runat="server" ControlToValidate="txtLEDateTo"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                ErrorMessage="LED To is Not Valid Date." Display="none" SetFocusOnError="true">
                            </asp:RegularExpressionValidator>
                            <asp:CompareValidator ID="cfvLED" runat="server" ControlToCompare="txtLEDateFrom"
                                Display="None" Type="Date" Operator="GreaterThanEqual" ControlToValidate="txtLEDateTo"
                                ErrorMessage="LED From Date must be Less Than Or Equal LED To Date." SetFocusOnError="true"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">Building Status</td>
                        <td align="right" valign="top">:</td>
                        <td align="left" valign="top">
                            <asp:ListBox ID="lstBuildingStatus" runat="server" Width="170px" Rows="4" SelectionMode="Multiple">                                
                                <asp:ListItem Text="Active" Value="Active"></asp:ListItem>
                                <asp:ListItem Text="InActive" Value="Inactive"></asp:ListItem>
                                <asp:ListItem Text="Disposed" Value="Disposed"></asp:ListItem>
                            </asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>                        
                        <td colspan="6" align="center" >
                            <asp:Button runat="server" ID="btnShowReport" Text="Show Report" OnClick="btnShowReport_Click"
                                CausesValidation="true"  />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear All"
                                OnClick="btnClearCriteria_Click" CausesValidation="false" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0" runat="server"
        id="tblReport" visible="false">
        <tr valign="middle">
            <td align="right" width="100%">
                <asp:LinkButton Visible="false" ID="lbtExportToExcel" runat="server" Text="Export To Excel"
                    OnClick="lbtExportToExcel_Click"></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 5px;">
            </td>
        </tr>
        <tr id="trGrid" runat="server">
            <td align="left">
                <div style="overflow: hidden; width: 997px;" id="dvHeader" runat="server">
                    <table width="2650px" cellpadding="4" cellspacing="0" border="0" style="font-weight: bold;"
                        id="tblHeader" runat="server">
                        <tr class="HeaderStyle" style="font-weight: bold;">
                            <td align="left" colspan="2">
                                Sonic Automotive
                            </td>
                            <td align="center" colspan="9">
                                Sublease Report
                            </td>
                            <td align="right" colspan="3">
                                <%=DateTime.Now.ToString()  %>
                            </td>
                        </tr>
                        <tr align="left" valign="bottom" class="HeaderStyle">
                            <td width="150px" align="left">
                                Location
                            </td>
                            <td width="150px" align="left">
                                Building Number
                            </td>
                            <td width="160px" align="left">
                                Address 1
                            </td>
                            <td width="160px" align="left">
                                Address 2
                            </td>
                            <td width="150px" align="left">
                                 City
                            </td>
                            <td width="150px" align="left">
                                 State
                            </td>
                            <td width="150px" align="left">
                                 Zip Code
                            </td>
                            <td width="150px" align="left">
                                Landlord Name
                            </td>
                            <td width="150px" align="left">
                                Subtenant
                            </td>
                            <td width="210" align="left">
                                SubLease Commencement Date
                            </td>
                            <td width="210px" align="left">
                                Sublease Expiration Date
                            </td>
                            <td width="210px" align="left">
                                Sublease Notification Due Date
                            </td>
                            <td width="150px" align="right">
                                Monthly Sub-Rent
                            </td>
                            <td width="400px" align="left">
                                Renewals
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="overflow: scroll; width: 997px; height: 398px;" id="dvGrid" runat="server">
                    <asp:GridView ID="gvDescription" EnableTheming="false" DataKeyNames="dba" runat="server"
                        AutoGenerateColumns="false" Width="100%" HorizontalAlign="Left" GridLines="None"
                        ShowHeader="true" ShowFooter="true" EmptyDataText="No Record Found !" CellPadding="0"
                        CellSpacing="0" Style="word-wrap: normal; word-break: break-all;">
                        <HeaderStyle CssClass="HeaderStyle" />
                        <RowStyle CssClass="RowStyle"/>
                        <AlternatingRowStyle CssClass="AlterRowStyle" BackColor="White"/>
                        <FooterStyle ForeColor="Black" Font-Bold="true" />
                        <EmptyDataRowStyle BackColor="#EAEAEA" Height="22px" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <table width="2630px" cellpadding="4" cellspacing="0" border="0" style="font-weight: bold;
                                        display: none;" id="tblHeader" runat="server">
                                        <tr class="HeaderStyle">
                                            <td align="left" colspan="2">
                                                Sonic Automotive
                                            </td>
                                            <td align="center" colspan="9">
                                                Sublease Report
                                            </td>
                                            <td align="right" colspan="3">
                                                <%=DateTime.Now.ToString()  %>
                                            </td>
                                        </tr>
                                        <tr align="left" valign="bottom">
                                            <td width="150px" align="left">
                                                Location
                                            </td>
                                            <td width="150px" align="left">
                                                Building Number
                                            </td>
                                            <td width="160px" align="left">
                                                 Address 1
                                            </td>
                                            <td width="160px" align="left">
                                                 Address 2
                                            </td>
                                            <td width="150px" align="left">
                                                 City
                                            </td>
                                            <td width="150px" align="left">
                                                 State
                                            </td>
                                            <td width="150px" align="left">
                                                 Zip Code
                                            </td>
                                            <td width="150px" align="left">
                                                Landlord Name
                                            </td>
                                            <td width="150px" align="left">
                                                Subtenant
                                            </td>
                                            <td width="210px" align="left">
                                                SubLease Commencement Date
                                            </td>
                                            <td width="210px" align="left">
                                                Sublease Expiration Date
                                            </td>
                                            <td width="210px" align="left">
                                                Sublease Notification Due Date
                                            </td>
                                            <td width="150px" align="right">
                                                Monthly Sub-Rent
                                            </td>
                                            <td width="380px" align="left">
                                                Renewals
                                            </td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table width="2630px" cellpadding="4" cellspacing="0" border="0" id="tblHeader" runat="server">
                                        <tr valign="top">
                                            <td width="150px" align="left"> 
                                                <%# Eval("dba")%>
                                            </td>
                                            <td width="150px" align="left">
                                                <%# Eval("BUILDING_NUMBER")%>
                                            </td>
                                            <td width="160px" align="left">
                                                <%# Eval("Building_Address_1")%>
                                            </td>
                                            <td width="160px" align="left">
                                                <%# Eval("Building_Address_2")%>
                                            </td>
                                            <td width="150px" align="left">
                                                <%# Eval("Building_City")%>
                                            </td>
                                            <td width="150px" align="left">
                                                <%# Eval("Building_State")%>
                                            </td>
                                            <td width="150px" align="left">
                                                <%# Eval("Building_Zip")%>
                                            </td>
                                            <td width="150px" align="left">
                                                <%# Eval("LANDLORD_NAME") %>
                                            </td>
                                            <td width="150px" align="left">
                                                <%# Eval("SUBLEASE_NAME")%>
                                            </td>
                                            <td width="210px" align="left">
                                                <%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("COMMENCEMENT_DATE"))%>
                                            </td>
                                            <td width="210px" align="left">
                                                <%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("EXPIRATION_DATE"))%>
                                            </td>
                                            <td width="210px" align="left">
                                                <%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Landlord_Notification_Date"))%>
                                            </td>
                                            <td width="150px" align="right">
                                              <%# String.Format("{0:C2}", Eval("Subtenant_Monthly_Rent"))%>                                              
                                            </td>
                                            <td width="380px" align="left">
                                                <%# Eval("Renew_Options")%>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr id="trMessage" runat="server" visible="false">
            <td align="center">
                <table border="0" cellpadding="5" cellspacing="1" width="100%">
                    <tr>
                        <td class="headerrow">
                            No Record Found !
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 15px;">
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button runat="server" ID="btnBack" OnClick="btnBack_Click" Text="Back" />
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 10px;">
            </td>
        </tr>
    </table>
   
</asp:Content>
