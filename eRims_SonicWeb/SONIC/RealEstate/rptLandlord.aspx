<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="rptLandlord.aspx.cs"
    Inherits="SONIC_RealEstate_rptLandlord" Title="eRIMS Sonic :: Landlord Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        CssClass="errormessage"></asp:ValidationSummary>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>

    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" class="ghc">
                Landlord Report
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="63%" align="center" style="text-align: left;" cellpadding="2" cellspacing="3"
                    border="0">
                    <tr valign="top" align="left">
                        <td>
                            Region
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td>
                            <asp:ListBox ID="ddlRegion" runat="server" SelectionMode="Multiple" Width="100%">
                            </asp:ListBox>
                        </td>
                    </tr>
                    <tr valign="top" align="left">
                        <td>
                            Lease Type
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td>
                            <asp:ListBox ID="ddlLeaseType" runat="server" Rows="4" SelectionMode="Multiple" Width="100%">
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
                </table>
                <table width="77%" cellpadding="2" cellspacing="2">
                    <tr>
                        <td>
                            <asp:Button ID="btnShowReport" runat="server" Text="Show Report" CausesValidation="true"
                                OnClick="btnShowReport_Click" />
                            <asp:Button ID="btnClear" runat="server" Text="Clear Criteria" CausesValidation="false"
                                OnClick="btnClear_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="90%" align="center">
                    <tr>
                        <td width="100%" align="left">
                            <div id="dvGrid" runat="server" visible="false">
                                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                    <tr>
                                        <td align="right">
                                            <asp:LinkButton ID="lnkExportToExcel" runat="server" Text="Export To Excel" OnClick="lnkExportToExcel_Click"></asp:LinkButton>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Spacer" style="height: 15px;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div runat="server" id="dvReport" style="overflow-x: hidden; overflow-y: hidden;
                                                text-align: left; width: 950px;">
                                                <asp:GridView ID="gvDBA" runat="server" AutoGenerateColumns="false" ShowFooter="true"
                                                    Width="1285px" EnableTheming="false" HorizontalAlign="Left" CellPadding="0" GridLines="None"
                                                    CssClass="GridClass" EmptyDataText="No Record Found" OnRowDataBound="gvDBA_RowDataBound"
                                                    OnRowCreated="gvDBA_RowCreated">
                                                    <HeaderStyle CssClass="HeaderStyle" />
                                                    <FooterStyle CssClass="FooterStyle" />
                                                    <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="18px" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td>
                                                                            <table width="100%" cellpadding="4" cellspacing="0" style="font-weight: bold;" id="tblHeader"
                                                                                runat="server">
                                                                                <tr>
                                                                                    <td width="250px" align="left">
                                                                                        Location
                                                                                    </td>
                                                                                    <td width="200px" align="left">
                                                                                        First In House Contact
                                                                                    </td>
                                                                                    <td width="190px" align="left">
                                                                                        Primary Use
                                                                                    </td>
                                                                                    <td width="125px" align="left">
                                                                                        Landlord
                                                                                    </td>
                                                                                    <td width="200px" align="left">
                                                                                        Type
                                                                                    </td>
                                                                                    <td width="100px" align="left">
                                                                                        Lease Codes
                                                                                    </td>
                                                                                    <td width="120px" align="right">
                                                                                        Rentable Area
                                                                                    </td>                                                                                    
                                                                                    <td width="100px" align="right">
                                                                                        Lease Term
                                                                                    </td>                                                                                    
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td width="100%" align="left">
                                                                            <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="false" ShowFooter="true" ShowHeader="false"
                                                                            Width="1285px" CellPadding="4" CellSpacing="0" EnableTheming="false" GridLines="None">
                                                                            <RowStyle CssClass="RowStyle" />
                                                                            <AlternatingRowStyle CssClass="AlterRowStyle" />
                                                                            <FooterStyle Font-Bold="true" ForeColor="Black" />
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Location" ItemStyle-VerticalAlign="Top" ItemStyle-Width="250px"
                                                                                        FooterStyle-HorizontalAlign="Left">
                                                                                        <ItemTemplate>
                                                                                            <%# Eval("DBA") %><br />
                                                                                            <%# Eval("Address")%>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            Sub Total
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="First In House Contact" ItemStyle-VerticalAlign="Top"
                                                                                        ItemStyle-Width="200px" FooterStyle-HorizontalAlign="left">
                                                                                        <ItemTemplate>
                                                                                            <%#Eval("Tenant_Contact")%>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Primary Use" ItemStyle-VerticalAlign="Top" ItemStyle-Width="190px">
                                                                                        <ItemTemplate>
                                                                                            <%#Eval("Primary_Use")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Landlord" ItemStyle-VerticalAlign="Top" ItemStyle-Width="125px">
                                                                                        <ItemTemplate>
                                                                                            <%# Eval("Landlord")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Type" ItemStyle-VerticalAlign="Top" ItemStyle-Width="200px">
                                                                                        <ItemTemplate>
                                                                                            <%# Eval("Type")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Lease Codes" ItemStyle-VerticalAlign="Top" ItemStyle-Width="100px">
                                                                                        <ItemTemplate>
                                                                                            <%#Eval("Lease_Codes")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Rentable Area" ItemStyle-VerticalAlign="Top" ItemStyle-Width="120px"
                                                                                        ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                                        <ItemTemplate>
                                                                                            <%# string.Format("{0:N0}", Eval("Rentable_Area"))%>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <asp:Label ID="lblLeaseable_Area" runat="server"></asp:Label>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Lease Term" ItemStyle-VerticalAlign="Top" ItemStyle-Width="100px"
                                                                                        ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                                                        <ItemTemplate>
                                                                                            <%# string.Format("{0:N0}", Eval("Lease_Term"))%>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <asp:Label ID="lblTotalLeaseTerm" runat="server"></asp:Label>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>                                                                                
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td>
                                                                            <table width="100%" cellpadding="4" cellspacing="0" style="font-weight: bold; background-color: #507CD1;
                                                                                color: White;" id="tblFooter" runat="server">
                                                                                <tr>
                                                                                    <td width="250px" align="left">
                                                                                        Report Grand Totals
                                                                                    </td>
                                                                                    <td width="200px" align="left">
                                                                                         <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td width="190px" align="right">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                    <td width="125px" align="left">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                    <td width="200px" align="left">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                    <td width="100px" align="left">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                    <td width="120px" align="right">
                                                                                        <asp:Label ID="lblLeaseable_Area" runat="server"></asp:Label>
                                                                                    </td>                                                                                    
                                                                                    <td width="100px" align="right">
                                                                                        <asp:Label ID="lblTotalLeaseTerm" runat="server"></asp:Label>
                                                                                    </td>                                
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
