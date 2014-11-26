<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckSearch.aspx.cs" Inherits="CheckWriting_CheckSearch"
    MasterPageFile="~/Default.master" Theme="Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../JavaScript/popcalendar.js"></script>
    <script type="text/javascript" src="../JavaScript/calendar.js"></script>
     <script type="text/javascript" language="javascript" src="../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery.maskedinput.js"></script>
    <script type="text/javascript">
    jQuery(function ($) {
        $("#<%=txtDtStart.ClientID%>").mask("99/99/9999");
        $("#<%=txtDtEnd.ClientID%>").mask("99/99/9999");
        $("#<%=txtFDtClose.ClientID%>").mask("99/99/9999");
        $("#<%=txtFDtCloseTo.ClientID%>").mask("99/99/9999");
        });
        </script>
  <%--  <asp:ScriptManager ID="smCheckSearch" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>--%>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" CssClass="errormessage" ValidationGroup="vsErrorGroup"
            EnableClientScript="true" BorderColor="DimGray" BorderWidth="1" HeaderText="Verify the following fields:"
            ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
        <asp:CustomValidator ID="cvErrorMsg" runat="server" ValidationGroup="vsErrorGroup"
            EnableClientScript="true" Display="None" ErrorMessage=""></asp:CustomValidator>
    </div>
    <div id="dvCheckSearch" runat="server">
        <table width="100%">
            <tr>
                <td align="center">
                    <table width="99%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;
                        text-align: left;">
                        <tr>
                            <td class="ghc" colspan="6">
                                <asp:Label ID="lblHeader" runat="server" Text="Search"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="80%">
                                    <tr>
                                        <td class="lc" style="width: 25%;" valign="top">
                                            <asp:Label ID="lblLClaimType" runat="server" Text="Claim Type"></asp:Label>
                                        </td>
                                        <td class="lc" valign="top">
                                            :
                                        </td>
                                        <td class="ic" style="width: 25%;" valign="top">
                                            <asp:CheckBoxList ID="chkLstClaimType" runat="server" RepeatDirection="vertical">
                                                <asp:ListItem Text="Workers Compensation" Value="Workers_Comp"></asp:ListItem>
                                                <asp:ListItem Text="Auto Liability" Value="Liability_Claim"></asp:ListItem>
                                                <asp:ListItem Text="General Liability" Value="Liability_Claim"></asp:ListItem>
                                                <asp:ListItem Text="Property Loss" Value="Liability_Claim"></asp:ListItem>
                                            </asp:CheckBoxList>
                                        </td>
                                        <td class="lc" style="width: 25%;">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="lc" style="width: 25%;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lc" style="width: 25%;">
                                            <asp:Label ID="lblLClaimNo" runat="server" Text="Claim Number"></asp:Label>
                                        </td>
                                        <td class="lc">
                                            :
                                        </td>
                                        <td class="ic" style="width: 25%;">
                                            <asp:TextBox ID="txtClaimNo" runat="server"></asp:TextBox>
                                        </td>
                                        <td class="lc" style="width: 25%;">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="lc" style="width: 25%;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 25%" class="lc" align="left">
                                            <asp:Label ID="lblLClaimOpenFrom" runat="server" Text="Open Claims From"></asp:Label>
                                        </td>
                                        <td class="lc">
                                            :
                                        </td>
                                        <td style="width: 25%" class="lc" align="left">
                                            <asp:TextBox ID="txtDtStart" runat="server" ValidationGroup="vsErrorGroup"></asp:TextBox>
                                            <img style="vertical-align: baseline" id="imgStartDate" onclick="popUpCalendar(this,ctl00$ContentPlaceHolder1$txtDtStart,'mm/dd/yyyy');"
                                                height="17" alt="Calendar" src="../Images/iconPicDate.gif" runat="server" />
                                            <asp:RegularExpressionValidator ID="revChkDtStart" runat="server" ControlToValidate="txtDtStart"
                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                ErrorMessage="Date Not Valid(Open Claims From Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                        </td>
                                        <td style="width: 25%" class="lc" align="left">
                                            <asp:Label ID="lblLClaimsOpenTo" runat="server" Text="Open Claims To"></asp:Label>
                                        </td>
                                        <td class="lc">
                                            :
                                        </td>
                                        <td class="lc" style="width: 25%;" align="left">
                                            <asp:TextBox ID="txtDtEnd" runat="server"></asp:TextBox>
                                            <img style="vertical-align: baseline" id="imgEndDate" onclick="popUpCalendar(this,ctl00_ContentPlaceHolder1_txtDtEnd,'mm/dd/yyyy');"
                                                height="17" alt="Calendar" src="../Images/iconPicDate.gif" runat="server" />
                                            <asp:RegularExpressionValidator ID="revtxtDtEnd" runat="server" ControlToValidate="txtDtEnd"
                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                ErrorMessage="Date Not Valid(Open Claims To Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 25%" class="lc" align="left">
                                            <asp:Label ID="lblLClaimCloseFrom" runat="server" Text="Closed Claims From"></asp:Label>
                                        </td>
                                        <td class="lc">
                                            :
                                        </td>
                                        <td style="width: 25%" class="lc" align="left">
                                            <asp:TextBox ID="txtFDtClose" runat="server" ValidationGroup="vsErrorGroup"></asp:TextBox>
                                            <img style="vertical-align: baseline" id="imgDtClose" onclick="popUpCalendar(this,ctl00$ContentPlaceHolder1$txtFDtClose,'mm/dd/yyyy');"
                                                height="17" alt="Calendar" src="../Images/iconPicDate.gif" runat="server" />
                                            <asp:RegularExpressionValidator ID="revtxtFDtClose" runat="server" ControlToValidate="txtFDtClose"
                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                ErrorMessage="Date Not Valid(Closed Claims From Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                        </td>
                                        <td style="width: 25%" class="lc" align="left">
                                            <asp:Label ID="lblLClaimCloseTo" runat="server" Text="Closed Claims To"></asp:Label>
                                        </td>
                                        <td class="lc">
                                            :
                                        </td>
                                        <td class="lc" style="width: 25%;" align="left">
                                            <asp:TextBox ID="txtFDtCloseTo" runat="server"></asp:TextBox>
                                            <img style="vertical-align: baseline" id="imgDtCloseTo" onclick="popUpCalendar(this,ctl00_ContentPlaceHolder1_txtFDtCloseTo,'mm/dd/yyyy');"
                                                height="17" alt="Calendar" src="../Images/iconPicDate.gif" runat="server" />
                                            <asp:RegularExpressionValidator ID="revtxtFDtCloseTo" runat="server" ControlToValidate="txtFDtCloseTo"
                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                ErrorMessage="Date Not Valid(Closed Claims To Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lc" style="width: 25%;">
                                            <asp:Label ID="lblLChkNo" runat="server" Text="Check Number"></asp:Label>
                                        </td>
                                        <td class="lc">
                                            :
                                        </td>
                                        <td class="ic" style="width: 25%;">
                                            <asp:TextBox ID="txtChkNo" runat="server"></asp:TextBox>
                                        </td>
                                        <td class="lc" style="width: 25%;">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="lc" style="width: 25%;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6" align="center">
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div id="dvGrd" runat="server" style="padding-top: 15px;">
        <asp:GridView ID="gvChkEditDel" runat="server" Width="100%" AllowPaging="false" AllowSorting="false"
            AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <input name="chkItem" type="checkbox" value='<%# Eval("Pk_check_no")%>' onclick="javascript:UnCheckHeader('gvChkEditDel')" />
                    </ItemTemplate>
                    <ItemStyle Width="10px" />
                    <HeaderTemplate>
                        <input id="chkHeader" name="chkHeader" type="checkbox" runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                    </HeaderTemplate>
                    <HeaderStyle Width="10px" />
                </asp:TemplateField>
                <asp:BoundField DataField="CEDClaimNo" HeaderText="Claim Number" SortExpression="CEDClaimNo">
                </asp:BoundField>
                <asp:BoundField DataField="CDCheckNumber" HeaderText="Check Number" SortExpression="CDCheckNumber">
                </asp:BoundField>
                <asp:BoundField DataField="RecIssueDate" HeaderText="Issue Date" SortExpression="RecIssueDate"
                    DataFormatString="{0:MM/dd/yyyy}" HtmlEncode="false"></asp:BoundField>
                <asp:BoundField DataField="AEPPaymentID" HeaderText="PaymentID" SortExpression="AEPPaymentID">
                </asp:BoundField>
                <asp:BoundField DataField="AEPDtServiceBegin" HeaderText="Begin Date" SortExpression="AEPDtServiceBegin"
                    DataFormatString="{0:MM/dd/yyyy}" HtmlEncode="false"></asp:BoundField>
                <asp:BoundField DataField="AEPDtServiceEnd" HeaderText="End Date" SortExpression="AEPDtServiceEnd"
                    DataFormatString="{0:MM/dd/yyyy}" HtmlEncode="false"></asp:BoundField>
                <asp:BoundField DataField="AEPInvoiceNo" HeaderText="Invoice Number" SortExpression="AEPInvoiceNo">
                </asp:BoundField>
                <asp:BoundField DataField="Check_Amount" HeaderText="Payment Amount" SortExpression="Check_Amount"
                    DataFormatString="{0:C}" HtmlEncode="false"></asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" CommandName="EditItem" CommandArgument='<%# Eval("Pk_check_no") %>'
                            runat="server" Text="Edit" ToolTip="Edit the Check Details" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%# Eval("Pk_check_no") %>'
                            ToolTip="View the Check Details" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
            <EmptyDataTemplate>
                Currently There Is No Check for Searched Criteria.
            </EmptyDataTemplate>
            <PagerSettings Visible="False" />
        </asp:GridView>
    </div>
</asp:Content>
