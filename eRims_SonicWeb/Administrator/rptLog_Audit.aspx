<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="rptLog_Audit.aspx.cs" Inherits="Administrator_rptLog_Audit" %>

    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>
      <script type="text/javascript" language="javascript" src="../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery.maskedinput.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Validator.js"></script>

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Date_Validation.js"></script>
     <script language="javascript" type="text/javascript">
         jQuery(function ($) {
             $("#<%=txtBegin_Date.ClientID%>").mask("99/99/9999");
             $("#<%=txtEnd_Date.ClientID%>").mask("99/99/9999");
         });
    </script>
    <asp:ValidationSummary ID="vsLogAudit" runat="server" ValidationGroup="vsLogAudit"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following fields"
        BorderWidth="1" BorderColor="DimGray" CssClass="errormessage" />
    <table width="100%">
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td align="left" class="ghc">
                Login Audit Report
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Panel ID="pnlFilters" runat="server" Visible="false">
                    <table align="center" width="70%" cellpadding="3" cellspacing="0">
                        <tr>
                            <td colspan="2" align="right" valign="top">
                                User :
                            </td>
                            <td colspan="2" align="left">
                            <asp:ListBox ID="drpUser" Rows="7" runat="server" SelectionMode="Multiple" Width="250px"></asp:ListBox>
                                <%--<asp:DropDownList ID="drpUser" runat="server" Width="170px">
                                </asp:DropDownList>--%>
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="5%">
                                &nbsp;
                            </td>
                            <td align="right" width="10%">
                                From :
                            </td>
                            <td align="left" width="25%">
                                <asp:TextBox ID="txtBegin_Date" runat="server" ></asp:TextBox>
                                <img onclick="return showCalendar('<%= txtBegin_Date.ClientID %>', 'mm/dd/y');"
                                    onmouseover="javascript:this.style.cursor='hand';" alt="" src="../Images/iconPicDate.gif"
                                    align="middle" id="img2" />
                                   <br />
                                <asp:RegularExpressionValidator ID="revtxtDateofLossFrom" runat="server" ControlToValidate="txtBegin_Date"
                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                    ErrorMessage="Begin Date is Not Valid Date" Display="none" ValidationGroup="vsLogAudit"
                                    SetFocusOnError="true">
                                </asp:RegularExpressionValidator>
                            </td>
                            <td style="width: 10%;" align="right">
                                To :
                            </td>
                            <td align="left" width="33%">
                                <asp:TextBox ID="txtEnd_Date" runat="server" onblur="javascript:Claer_Format(this);"></asp:TextBox>
                                <img onclick="return showCalendar('<%= txtEnd_Date.ClientID %>', 'mm/dd/y');"
                                    onmouseover="javascript:this.style.cursor='hand';" alt="" src="../Images/iconPicDate.gif"
                                    align="middle" id="img1" />
                                    <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEnd_Date"
                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                    ErrorMessage="End Date is Not Valid Date" Display="none" ValidationGroup="vsLogAudit"
                                    SetFocusOnError="true">
                                </asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="cmpvtxtOccurenceToDate" runat="server" ControlToCompare="txtEnd_Date"
                                    ControlToValidate="txtBegin_Date" Display="None" ErrorMessage="Begin Date must be Less Than or Equal To End Date."
                                    Operator="LessThanEqual" Type="Date" ValidationGroup="vsLogAudit"></asp:CompareValidator>
                            </td>
                            <td align="left">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" align="center" height="40px" valign="bottom">
                                <asp:Button ID="btnReport" runat="server" ValidationGroup="vsLogAudit" Text="Generate Report"
                                    OnClick="btnReport_Click"  />
                                &nbsp;<asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear All"
                                    CausesValidation="false" OnClick="btnClearCriteria_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlReport" runat="server" Visible="false">
                    <table width="99%" align="center" cellpadding="2" cellspacing="1" border="0">
                    <tr>
                        <td align="right">
                            <asp:LinkButton ID="btnExcel" Text="Export To Excel" runat="server" OnClick="btnExcel_Click" />
                        </td>
                    </tr>
                        <tr>
                            <td>
                                
                                <asp:Literal ID="ltrReport" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnBack" Text="Back" runat="server" OnClick="btnBack_Click" />                                
                            </td>
                        </tr>
                    </table>
                    <table width="100%">
                        <tr>
                            <td class="Spacer" style="height: 15px;">
                            </td>
                        </tr>
                        <%--<tr>
                            <td width="100%" class="Spacer" style="height: 50px;">
                            </td>
                        </tr>--%>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
