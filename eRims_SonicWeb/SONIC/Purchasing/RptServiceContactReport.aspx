<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="RptServiceContactReport.aspx.cs"
    Inherits="SONIC_Purchasing_RptServiceContactReport" Title="eRIMS Sonic :: Service Contract Detail Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>

    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <table cellpadding="0" cellspacing="0" width="100%" align="center">
        <tr>
            <td width="100%" class="Spacer" style="height: 3px;">
            </td>
        </tr>
        <tr>
            <td class="ghc" align="left">
                Service Contract Detail Report
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td class="dvContent">
                <table cellpadding="3" cellspacing="1" border="0" width="40%" align="center">
                    <tr>
                        <td width="30%" align="left" valign="top">
                            Region
                        </td>
                        <td width="2%" align="center" valign="top">
                            :
                        </td>
                        <td align="left">
                            <asp:ListBox ID="lstRegions" runat="server" SelectionMode="Multiple" ToolTip="Select Region"
                                AutoPostBack="false" Width="166px"></asp:ListBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Select Region"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="lstRegions" ValidationGroup="vsErrorGroup"
                                SetFocusOnError="false" Enabled="false"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td width="30%" align="left" valign="top">
                            Location
                        </td>
                        <td width="2%" align="center" valign="top">
                            :
                        </td>
                        <td align="left">
                            <asp:ListBox ID="lstLocation" runat="server" SelectionMode="Multiple" ToolTip="Select Location"
                                AutoPostBack="false" Width="166px"></asp:ListBox>
                            <asp:RequiredFieldValidator ID="rfvlstLocation" runat="server" ErrorMessage="Please Select Location"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="lstLocation" ValidationGroup="vsErrorGroup"
                                SetFocusOnError="false" Enabled="false"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            Service Contract
                        </td>
                        <td width="2%" align="center" valign="top">
                            :
                        </td>
                        <td align="left">
                            <asp:ListBox ID="lstServiceContract" runat="server" SelectionMode="Multiple" ToolTip="Select Service Contract"
                                AutoPostBack="false" Width="166px"></asp:ListBox>
                            <asp:RequiredFieldValidator ID="rfvlstServiceContract" runat="server" ErrorMessage="Please Select Service Contract"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="lstServiceContract"
                                ValidationGroup="vsErrorGroup" SetFocusOnError="false" Enabled="false"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            Service Type
                        </td>
                        <td width="2%" align="center" valign="top">
                            :
                        </td>
                        <td align="left">
                            <asp:ListBox ID="lstServiceType" runat="server" SelectionMode="Multiple" ToolTip="Select Service Type"
                                AutoPostBack="false" Width="166px"></asp:ListBox>
                            <asp:RequiredFieldValidator ID="rfvlstServiceType" runat="server" ErrorMessage="Please Select Service Type"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="lstServiceType" ValidationGroup="vsErrorGroup"
                                SetFocusOnError="false" Enabled="false"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Start Date
                        </td>
                        <td width="2%" align="center">
                            :
                        </td>
                        <td align="left">
                            From&nbsp;&nbsp;<asp:TextBox runat="server" ID="txtStartDateFromDate" Width="75px"
                                SkinID="txtDate"></asp:TextBox>
                            <img alt="Date Opened" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtStartDateFromDate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" />
                            <%--<asp:RequiredFieldValidator ID="rfvtxtStartDateFromDate" runat="server" ControlToValidate="txtStartDateFromDate"
                                ErrorMessage="Please enter From Start Date." ValidationGroup="vsErrorGroup" Display="none" SetFocusOnError="true" />--%>
                            <asp:RangeValidator ID="RangeValidator1" ControlToValidate="txtStartDateFromDate"
                                MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="From Start Date is not valid."
                                runat="server" SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none" />
                            &nbsp;&nbsp;To&nbsp;&nbsp;
                            <asp:TextBox runat="server" ID="txtStartDateToDate" Width="75px" SkinID="txtDate"></asp:TextBox>
                            <img alt="Date Opened" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtStartDateToDate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" />
                            <%--<asp:RequiredFieldValidator ID="rfvtxtStartDateToDate" runat="server" ControlToValidate="txtStartDateToDate"
                                ErrorMessage="Please enter To Start Date." ValidationGroup="vsErrorGroup" Display="none" SetFocusOnError="true"/>--%>
                            <asp:RangeValidator ID="revDate" ControlToValidate="txtStartDateToDate" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="To Start Date is not valid."
                                runat="server" SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none" />
                            <asp:CompareValidator ID="cvStartDate" runat="server" ControlToValidate="txtStartDateToDate"
                                ControlToCompare="txtStartDateFromDate" Type="Date" ErrorMessage="To Start Date must be greater than or equal to From Start Date"
                                Operator="GreaterThanEqual" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                Display="none"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            End Date
                        </td>
                        <td width="2%" align="center">
                            :
                        </td>
                        <td align="left">
                            From&nbsp;&nbsp;<asp:TextBox runat="server" ID="txtEndDateFromDate" Width="75px"
                                SkinID="txtDate"></asp:TextBox>
                            <img alt="Date Opened" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtEndDateFromDate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" />
                            <%--<asp:RequiredFieldValidator ID="rfvtxtEndDateFromDate" runat="server" ControlToValidate="txtEndDateFromDate"
                                ErrorMessage="Please enter From End Date." ValidationGroup="vsErrorGroup" Display="none" SetFocusOnError="true"/>--%>
                            <asp:RangeValidator ID="RangeValidator3" ControlToValidate="txtEndDateFromDate" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="From End Date is not valid."
                                runat="server" SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none" />
                            &nbsp;&nbsp;To&nbsp;&nbsp;
                            <asp:TextBox runat="server" ID="txtEndDateToDate" Width="75px" SkinID="txtDate"></asp:TextBox>
                            <img alt="Date Opened" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtEndDateToDate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" />
                            <%-- <asp:RequiredFieldValidator ID="rfvtxtEndDateToDate" runat="server" ControlToValidate="txtEndDateToDate"
                                ErrorMessage="Please enter To End Date." ValidationGroup="vsErrorGroup" Display="none" SetFocusOnError="true"/>--%>
                            <asp:RangeValidator ID="RangeValidator2" ControlToValidate="txtEndDateToDate" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="To End Date is not valid."
                                runat="server" SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none" />
                            <asp:CompareValidator ID="cvEndDate" runat="server" ControlToValidate="txtEndDateToDate"
                                ControlToCompare="txtEndDateFromDate" Type="Date" ErrorMessage="To End Date must be greater than or equal to From End Date"
                                Operator="GreaterThanEqual" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                Display="none"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" colspan="3" style="height: 10px;">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:Button ID="btnGenerateReport" runat="server" Text="Show Report" OnClick="btnGenerateReport_Click"
                                ValidationGroup="vsErrorGroup" ToolTip="Show Report" />&nbsp;
                            <asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear Criteria"
                                CausesValidation="false" OnClick="btnClearCriteria_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="Spacer" style="height: 15px;">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 15px;" align="right">
                <asp:LinkButton runat="server" ID="lnkExportToExcel" OnClick="lnkExportToExcel_Click"
                    Text="Export To Excel" CausesValidation="false" Visible="false"></asp:LinkButton>&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <div style="overflow: auto; text-align: left;">
                    <asp:GridView ID="gvRegion" EnableTheming="false" DataKeyNames="Region" OnRowCreated="gvRegion_RowCreated"
                        runat="server" AutoGenerateColumns="false" OnRowDataBound="gvRegion_RowDataBound"
                        Width="100%" HorizontalAlign="Left" GridLines="None" ShowFooter="true" EmptyDataText="No Record Found !">
                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle" />
                        <RowStyle BackColor="White" HorizontalAlign="Left" />
                        <AlternatingRowStyle BackColor="White" HorizontalAlign="Left" />
                        <FooterStyle CssClass="FooterStyle" />
                        <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td>
                                                <table width="100%" cellpadding="4" cellspacing="0" border="0" style="font-weight: bold;"
                                                    id="tblHeader" runat="server">
                                                    <tr>
                                                        <td align="left" style="width: 16%">
                                                            Region
                                                        </td>
                                                        <td align="left" style="width: 14%">
                                                            Supplier
                                                        </td>
                                                        <td align="left" style="width: 16%">
                                                            Location
                                                        </td>
                                                        <td align="left" style="width: 12%">
                                                            Service Type
                                                        </td>
                                                        <td align="left" style="width: 8%">
                                                            Start Date
                                                        </td>
                                                        <td align="left" style="width: 8%">
                                                            End Date
                                                        </td>
                                                        <td align="right" style="width: 13%">
                                                            Monthly Cost
                                                        </td>
                                                        <td align="right" style="width: 13%">
                                                            Annual Cost
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="False" Width="100%"
                                                    EmptyDataText="No Record found !" GridLines="None" EnableTheming="false" CssClass="GridClass"
                                                    CellPadding="4" ShowHeader="false" ShowFooter="true">
                                                    <HeaderStyle VerticalAlign="Bottom" CssClass="HeaderStyle" />
                                                    <RowStyle CssClass="RowStyle" VerticalAlign="top" />
                                                    <AlternatingRowStyle CssClass="AlterStyle" VerticalAlign="top" />
                                                    <FooterStyle Font-Bold="true" VerticalAlign="top" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Region">
                                                            <FooterStyle Width="16%" HorizontalAlign="Left" BackColor="white" ForeColor="black"
                                                                Wrap="true" />
                                                            <ItemStyle Width="16%" HorizontalAlign="left" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRegion" runat="server" Text='<%#Eval("Region") %>'></asp:Label>
                                                            </ItemTemplate>
                                                             <FooterTemplate>
                                                                Totals
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Supplier">
                                                            <FooterStyle Width="14%" HorizontalAlign="Left" BackColor="white" ForeColor="black"
                                                                Wrap="true" />
                                                            <ItemStyle Width="14%" HorizontalAlign="left" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSupplier" runat="server" Text='<%#Eval("Supplier")%>'></asp:Label>
                                                            </ItemTemplate>                                                           
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Location">
                                                            <FooterStyle Width="16%" HorizontalAlign="Left" BackColor="white" ForeColor="black"
                                                                Wrap="true" />
                                                            <ItemStyle Width="16%" HorizontalAlign="left" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLocation" runat="server" Text='<%# Eval("Location")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Service Type">
                                                            <FooterStyle Width="12%" HorizontalAlign="Left" BackColor="white" ForeColor="black"
                                                                Wrap="true" />
                                                            <ItemStyle Width="12%" HorizontalAlign="left" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblServiceType" runat="server" Text='<%# Eval("ServiceType")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Start Date">
                                                            <FooterStyle Width="8%" HorizontalAlign="Left" BackColor="white" ForeColor="black"
                                                                Wrap="true" />
                                                            <ItemStyle Width="8%" HorizontalAlign="left" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStartDate" runat="server" Text='<%# Eval("Start_Date")==DBNull.Value?"": clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Start_Date")))%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="End Date">
                                                            <FooterStyle Width="8%" HorizontalAlign="Left" BackColor="white" ForeColor="black"
                                                                Wrap="true" />
                                                            <ItemStyle Width="8%" HorizontalAlign="left" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEndDate" runat="server" Text='<%# Eval("End_Date")==DBNull.Value?"":clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("End_Date")))%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Monthly Cost">
                                                            <FooterStyle Width="13%" HorizontalAlign="right" BackColor="white" ForeColor="black"
                                                                Wrap="true" />
                                                            <ItemStyle Width="13%" HorizontalAlign="right" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblMonthlyCost" runat="server" Text='<%#"$ " + clsGeneral.GetStringValue(Eval("Monthly_Cost"))%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Annual Cost">
                                                            <FooterStyle Width="13%" HorizontalAlign="right" BackColor="white" ForeColor="black"
                                                                Wrap="true" />
                                                            <ItemStyle Width="13%" HorizontalAlign="right" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAnnualCost" runat="server" Text='<%#"$ " + clsGeneral.GetStringValue(Eval("Annual_Cost"))%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                    <EmptyDataTemplate>
                                                        Currently there is No record found.
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td valign="middle">
                                                <table width="100%" cellpadding="4" cellspacing="0" border="0" style="font-weight: bold;
                                                    background-color: #507CD1; color: White;" id="tblFooter" runat="server">
                                                    <tr>
                                                        <td align="left" style="width: 16%">
                                                            Report Grand Total
                                                        </td>
                                                        <td align="left" style="width: 14%">
                                                            <asp:Label ID="lblRegionTotal" runat="server" />
                                                        </td>
                                                        <td align="left" style="width: 16%">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" style="width: 12%">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" style="width: 8%">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" style="width: 8%">
                                                            &nbsp;
                                                        </td>
                                                        <td align="right" style="width: 13%">
                                                            <asp:Label ID="lblMonthly_Cost" runat="server" />
                                                        </td>
                                                        <td align="right" style="width: 13%">
                                                            <asp:Label ID="lblAuunual_Cost" runat="server" />
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
        <tr>
            <td class="Spacer" style="height: 10px;">
            </td>
        </tr>       
    </table>
</asp:Content>
