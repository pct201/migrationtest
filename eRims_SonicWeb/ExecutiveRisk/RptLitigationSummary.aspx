<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="RptLitigationSummary.aspx.cs"
    Inherits="ERReports_LitigationSummary" Title="eRIMS Sonic :: EPLI Pending Investigation and Litigation Summary Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Validator.js"></script>

    <asp:ValidationSummary ID="vsErrSum" ValidationGroup="vsError" runat="server" ShowMessageBox="true"
        ShowSummary="false" HeaderText="Verify the following fields" BorderWidth="1"
        BorderColor="DimGray" CssClass="errormessage" />
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" class="Spacer" style="height: 15px;">
            </td>
        </tr>
        <tr>
            <td width="100%" class="ghc">
                &nbsp;&nbsp;EPLI Pending Investigation and Litigation Summary Report
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 15px;">
            </td>
        </tr>
        <tr>
            <td align="left">
                <table cellpadding="3" cellspacing="0" width="50%" align="center">
                    <tr>
                        <td width="28%" align="left">
                            Start Date
                        </td>
                        <td width="4%" align="center">
                            :
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtStartDate" Width="170px" SkinID="txtDate"></asp:TextBox>
                            <img alt="Date Opened" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtStartDate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                align="middle" />
                            <asp:RequiredFieldValidator ID="rfvStartDate" runat="server" ControlToValidate="txtStartDate"
                                ErrorMessage="Please enter Start Date" ValidationGroup="vsError" Display="none" />
                            <asp:RangeValidator ID="revDate" ControlToValidate="txtStartDate" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Start Date is not valid."
                                runat="server" SetFocusOnError="true" ValidationGroup="vsError" Display="none" />
                        </td>
                    </tr>
                    <tr>
                        <td width="28%" align="left">
                            End Date
                        </td>
                        <td width="4%" align="center">
                            :
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtEndDate" Width="170px" SkinID="txtDate"></asp:TextBox>
                            <img alt="Date Opened" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtEndDate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                align="middle" />
                            <asp:RequiredFieldValidator ID="rfvEndDate" runat="server" ControlToValidate="txtEndDate"
                                ErrorMessage="Please enter End Date" ValidationGroup="vsError" Display="none" />
                            <asp:RangeValidator ID="revEndDate" ControlToValidate="txtEndDate" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="End Date is not valid." runat="server"
                                SetFocusOnError="true" ValidationGroup="vsError" Display="none" />
                            <asp:CompareValidator ID="cvDate" runat="server" ControlToValidate="txtEndDate" ControlToCompare="txtStartDate"
                                Type="Date" ErrorMessage="End Date must be greater than or equal to Start Date"
                                Operator="GreaterThanEqual" SetFocusOnError="true" ValidationGroup="vsError"
                                Display="none"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Region
                        </td>
                        <td align="center">
                            :
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="drpRegion" runat="server" SkinID="ddlSONIC" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Market
                        </td>
                        <td align="center">
                            :
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlMarket" runat="server" SkinID="ddlSONIC" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:Button ID="btnGenerateReport" runat="server" Text="Generate Report" OnClick="btnGenerateReport_Click"
                                CausesValidation="true" ValidationGroup="vsError" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 15px;">
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="0" width="1000px">
                    <tr>
                        <td align="right">
                            <asp:LinkButton ID="lnkExport" runat="server" Text="Export To Excel" OnClick="lnkExport_Click"
                                Visible="false" /> &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" class="Spacer" style="height: 5px;">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <div style="display: none; text-align: left;" id="divReport_Grid" runat="server" width="995px">
                                <asp:GridView ID="gvReport" runat="server" Width="100%" EmptyDataText="No Records Found"
                                    OnRowCreated="gvReport_RowCreated" EnableTheming="false" GridLines="None" ShowFooter="true"
                                    AutoGenerateColumns="false" OnRowDataBound="gvReport_RowDataBound">
                                    <HeaderStyle HorizontalAlign="Left" CssClass="HeaderStyle" VerticalAlign="top" />
                                    <RowStyle BackColor="White" HorizontalAlign="Left" VerticalAlign="top" />
                                    <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="true" HorizontalAlign="left" />
                                    <AlternatingRowStyle BackColor="White" HorizontalAlign="Left" VerticalAlign="top" />
                                    <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="100%" align="left">
                                                            <table cellpadding="4" cellspacing="0" width="100%" style="font-weight: bold;" id="tblHeader"
                                                                runat="server">
                                                                <tr>
                                                                    <td style="width: 150px;">
                                                                        <asp:Label ID="lblH1" runat="server" Width="150px" Text='Region' />
                                                                    </td>
                                                                    <td style="width: 150px;">
                                                                        <asp:Label ID="Label1" runat="server" Width="150px" Text='Store' />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label2" runat="server" Width="120px" Text='Date Claim Opened' />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label3" runat="server" Width="120px" Text='Complainant/Plaintiff' />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label4" runat="server" Width="120px" Text='Defense Attorney' />
                                                                    </td>
                                                                    <td style="width: 300px;">
                                                                        <asp:Label ID="Label5" runat="server" Width="300px" Text='Claim Description' />
                                                                    </td>
                                                                    <td style="width: 300px;">
                                                                        <asp:Label ID="Label6" runat="server" Width="300px" Text='Claim Status/Comments' />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                    <%--<tr>
                                                        <td align="left" style="background-color: White; height: 25px; color: Black;" width="100%">
                                                            <b>
                                                                <asp:Label ID="lblRegion" runat="server"><%#Eval("Region")%></asp:Label>
                                                            </b>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvClaimData" runat="server" ShowHeader="false" Width="100%" OnRowDataBound="gvClaimData_RowDataBound"
                                                                CellPadding="4" GridLines="None" CssClass="GridClass" AutoGenerateColumns="false"
                                                                EnableTheming="false" HorizontalAlign="Left" ShowFooter="true">
                                                                <FooterStyle BackColor="white" ForeColor="black" Font-Bold="true" HorizontalAlign="left" />
                                                                <RowStyle HorizontalAlign="Left" CssClass="RowStyle" VerticalAlign="top" />
                                                                <AlternatingRowStyle HorizontalAlign="left" CssClass="AlterRowStyle" VerticalAlign="top" />
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="150px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl1" runat="server" Width="150px" Text='<%# Eval("Region")%>' />
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            Total
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="150px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl2" runat="server" Width="150px" Text='<%#Eval("Location_Description")%>' />
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblTotal" runat="server" />
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl15" runat="server" Width="120px" Text='<%#Eval("Claim_Open_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Claim_Open_Date"))) : ""%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl16" runat="server" Width="120px" Text='<%# Eval("Complainant_Plaintiff")%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl3" runat="server" Width="120px" Text='<%#Eval("DefenseAttorney")%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="300px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSummary" runat="server" Width="300px" /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="300px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl5" runat="server" Width="300px" Text='<%# Eval("Claim_Status_Comments")%>' /></ItemTemplate>
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
                                                        <td width="100%" align="left">
                                                            <table cellpadding="4" cellspacing="0" width="100%" style="font-weight: bold;background-color:#507CD1;color:white;"
                                                                id="tblFooter" runat="server">
                                                                <tr>
                                                                    <td style="width: 150px;">
                                                                        <asp:Label ID="lblH1" runat="server" Width="150px" Text='Grand Total' />
                                                                    </td>
                                                                    <td style="width: 150px;" align="left">
                                                                        <asp:Label ID="lblFTotal" runat="server" Width="150px" />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label2" runat="server" Width="120px" />
                                                                    </td>
                                                                    <td style="width: 120px;" align="left">
                                                                        <asp:Label ID="Label3" runat="server" Width="120px" />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label4" runat="server" Width="120px" />
                                                                    </td>
                                                                    <td style="width: 300px;">
                                                                        <asp:Label ID="Label5" runat="server" Width="300px" />
                                                                    </td>
                                                                    <td style="width: 300px;">
                                                                        <asp:Label ID="Label6" runat="server" Width="300px" />
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
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 15px;">
            </td>
        </tr>
    </table>
</asp:Content>
