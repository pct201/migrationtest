<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="RptSonicCauseCodeReclassification.aspx.cs" Inherits="SONIC_FirstReport_RptSonicCauseCodeReclassification" %>

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
                Sonic Cause Code Reclassification
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
                        <td colspan="4">
                            <asp:ListBox ID="lstRegion" runat="server" Rows="4" SelectionMode="Multiple" Width="250px">
                            </asp:ListBox>
                        </td>
                    </tr>
                    <tr valign="top" align="left">
                        <td>
                            Location
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
                        <td style="width: 25%;">
                            Date of Injury Begin
                        </td>
                        <td align="right" style="width: 3%;">
                            :
                        </td>
                        <td style="width: 25%;">
                            <asp:TextBox ID="txtInjuryDateFrom" runat="server" MaxLength="10" SkinID="txtDate"></asp:TextBox>
                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtInjuryDateFrom.ClientID%>', 'mm/dd/y');"
                                alt="Date of Injury Begin" src="../../Images/iconPicDate.gif" align="middle" />
                            <asp:RegularExpressionValidator ID="rvtxtInjuryDateFrom" runat="server" ControlToValidate="txtInjuryDateFrom"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                ErrorMessage="Date of Injury Begin is Not Valid Date." Display="none" SetFocusOnError="true">
                            </asp:RegularExpressionValidator>
                        </td>
                        <td style="width: 14%;">
                            Date of Injury End
                        </td>
                        <td align="right" style="width: 3%;">
                            :
                        </td>
                        <td style="width: 30%;">
                            <asp:TextBox ID="txtInjuryDateEnd" runat="server" MaxLength="10" SkinID="txtDate"></asp:TextBox>
                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtInjuryDateEnd.ClientID%>', 'mm/dd/y');"
                                alt="Date of Injury End" src="../../Images/iconPicDate.gif" align="middle" />
                            <asp:RegularExpressionValidator ID="revtxtInjuryDateEnd" runat="server" ControlToValidate="txtInjuryDateEnd"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                ErrorMessage="LCD To is Not Valid Date." Display="none" SetFocusOnError="true"> 
                            </asp:RegularExpressionValidator>
                            <asp:CompareValidator ID="cfvLCD" runat="server" ControlToCompare="txtInjuryDateFrom"
                                Display="None" Type="Date" Operator="GreaterThanEqual" ControlToValidate="txtInjuryDateEnd"
                                ErrorMessage="Date of Injury Begin Date must be Less Than Or Equal To Date of Injury End Date."
                                SetFocusOnError="true"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr valign="top" align="left">
                        <td>
                            First Report Number
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td align="left" colspan="4">
                            <asp:TextBox ID="txtFirstReportNumber" runat="server" onKeyPress="return FormatInteger(event);" onpaste="return false"
                                MaxLength="20" Width="250px">
                            </asp:TextBox>
                            <asp:RegularExpressionValidator ID="REVFirstReportNumber" runat="server" ControlToValidate="txtFirstReportNumber"
                                Display="none" SetFocusOnError="true" ErrorMessage="First Report Number must be numeric"
                                ValidationExpression="^\d+$" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr valign="top" align="left">
                        <td>
                            Incident Investigation Number
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td align="left" colspan="4">
                            <asp:TextBox ID="txtIncidentNumber" runat="server" onKeyPress="return FormatInteger(event);" onpaste="return false"
                                MaxLength="20" Width="250px">
                            </asp:TextBox>
                            <asp:RegularExpressionValidator ID="REVIncidentNumber" runat="server" ControlToValidate="txtIncidentNumber"
                                Display="none" SetFocusOnError="true" ErrorMessage="Incident Investigation Number must be numeric"
                                ValidationExpression="^\d+$" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr valign="top" align="left">
                        <td>
                            Claim Number
                        </td>
                        <td align="right">
                            :
                        </td>
                        <td align="left" colspan="4">
                            <asp:TextBox ID="txtClaimNumber" runat="server" Width="250px">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="center">
                            <asp:Button runat="server" ID="btnShowReport" Text="Show Report" OnClick="btnShowReport_Click"
                                CausesValidation="true" />
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
                    <table width="2400px" cellpadding="4" cellspacing="0" border="0" style="font-weight: bold;"
                        id="tblHeader" runat="server">
                        <tr class="HeaderStyle">
                            <td align="left" colspan="2">
                                Sonic Automotive
                            </td>
                            <td align="center" colspan="9">
                                Sonic Cause Code Reclassification
                            </td>
                            <td align="right" colspan="3">
                                <%=DateTime.Now.ToString()  %>
                            </td>
                        </tr>
                        <tr align="left" valign="bottom" class="HeaderStyle">
                            <td width="150px" align="left">
                                Region
                            </td>
                            <td width="150px" align="left">
                                Location
                            </td>
                            <td width="140px" align="left">
                                Claim Number
                            </td>
                            <td width="160px" align="left">
                                First Report Number
                            </td>
                            <td width="210px" align="left">
                                Incident Investigation Number
                            </td>
                            <td width="150px" align="left">
                                Date of Injury
                            </td>
                            <td width="150px" align="left">
                                Date Reported to Sonic
                            </td>
                            <td width="180px" align="left">
                                Date Reported to SRS
                            </td>
                            <td width="200px" align="left">
                                Date when SRS Closed File/Claim
                            </td>
                            <td width="170px" align="left">
                                Original S0 Code
                            </td>
                            <td width="200px" align="left">
                                Reclassified S-Code
                            </td>
                            <td width="150px" align="right">
                                Total Incurred
                            </td>
                            <td width="150px" align="right">
                                Total Paid
                            </td>
                            <td width="150px" align="right">
                                Total Outstanding
                            </td>
                        </tr>
                    </table>
                </div>               
                <div runat="server" id="dvGrid" style="overflow-x: hidden; overflow-y: hidden; text-align: left; width: 997px;">
                    <asp:GridView ID="gvDescription" EnableTheming="false" DataKeyNames="dba" runat="server"
                        AutoGenerateColumns="false" Width="100%" HorizontalAlign="Left" GridLines="None"
                        ShowHeader="true" ShowFooter="true" EmptyDataText="No Record Found !" CellPadding="0"
                        CellSpacing="0">
                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle" />
                        <RowStyle CssClass="RowStyle" HorizontalAlign="Left" />
                        <AlternatingRowStyle CssClass="AlterRowStyle" BackColor="White" HorizontalAlign="Left" />
                        <FooterStyle ForeColor="Black" Font-Bold="true" />
                        <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <table width="2400px" cellpadding="4" cellspacing="0" border="0" style="font-weight: bold;
                                        display: none;" id="tblHeader" runat="server">
                                        <tr class="HeaderStyle">
                                            <td align="left" colspan="2">
                                                Sonic Automotive
                                            </td>
                                            <td align="center" colspan="9">
                                                Sonic Cause Code Reclassification
                                            </td>
                                            <td align="right" colspan="3">
                                                <%=DateTime.Now.ToString()  %>
                                            </td>
                                        </tr>
                                        <tr align="left" valign="bottom" class="HeaderStyle">
                                            <td width="150px" align="left">
                                                Region
                                            </td>
                                            <td width="150px" align="left">
                                                Location
                                            </td>
                                            <td width="140px" align="left">
                                                Claim Number
                                            </td>
                                            <td width="160px" align="left">
                                                First Report Number
                                            </td>
                                            <td width="210px" align="left">
                                                Incident Investigation Number
                                            </td>
                                            <td width="150px" align="left">
                                                Date of Injury
                                            </td>
                                            <td width="150px" align="left">
                                                Date Reported to Sonic
                                            </td>
                                            <td width="180px" align="left">
                                                Date Reported to SRS
                                            </td>
                                            <td width="200px" align="left">
                                                Date when SRS Closed File/Claim
                                            </td>
                                            <td width="170px" align="left">
                                                Original S0 Code
                                            </td>
                                            <td width="200px" align="left">
                                                Reclassified S-Code
                                            </td>
                                            <td width="150px" align="right">
                                                Total Incurred
                                            </td>
                                            <td width="150px" align="right">
                                                Total Paid
                                            </td>
                                            <td width="150px" align="right">
                                                Total Outstanding
                                            </td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table width="2400px" cellpadding="4" cellspacing="0" border="0" id="tblDetails" runat="server">
                                        <tr align="left" valign="top">
                                            <td width="150px" align="left">
                                                <%# Eval("Region")%>
                                            </td>
                                            <td width="150px" align="left">
                                                <%# Eval("DBA")%>
                                            </td>
                                            <td width="140px" align="left">
                                                <%# Eval("Origin_Claim_Number")%>
                                            </td>
                                            <td width="160px" align="left">
                                                <%# Eval("WC_FR_Number")%>
                                            </td>
                                            <td width="210px" align="left">
                                                <%# Eval("PK_Investigation_Id")%>
                                            </td>
                                            <td width="150px" align="left">
                                                <%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Date_Of_Accident"))%>
                                            </td>
                                            <td width="150px" align="left">
                                                <%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Date_Reported_To_Employer"))%>
                                            </td>
                                            <td width="180px" align="left">
                                                <%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Date_Reported_To_Insurer"))%>
                                            </td>
                                            <td width="200px" align="left">
                                                <%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Date_Closed"))%>
                                            </td>
                                            <td width="170px" align="left">
                                                <%# Eval("Original_Sonic_S0_Cause_Code")%>
                                            </td>
                                            <td width="200px" align="left">
                                                <%# Eval("Sonic_Cause_Code")%>
                                            </td>
                                            <td width="150px" align="right">
                                                <%# String.Format("{0:C2}", Eval("TotalIncurred"))%>
                                            </td>
                                            <td width="150px" align="right">
                                                <%# String.Format("{0:C2}", Eval("TotalPaid"))%>
                                            </td>
                                            <td width="150px" align="right">
                                                <%# String.Format("{0:C2}", Eval("TotalOutstanding"))%>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <table width="100%" cellpadding="4" cellspacing="0" style="font-weight: bold; background-color: #507CD1;
                                        color: White;" id="tblFooter" runat="server">
                                        <tr>
                                            <td width="150px" align="left">
                                              Report Grand Totals
                                            </td>
                                            <td width="150px" align="left">
                                                <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                            </td>
                                            <td width="140px" align="left">
                                                &nbsp;
                                            </td>
                                            <td width="150px" align="left">
                                                &nbsp;
                                            </td>
                                            <td width="210px" align="left">
                                                &nbsp;
                                            </td>
                                            <td width="150px" align="left">
                                                &nbsp;
                                            </td>
                                            <td width="150px" align="left">
                                                &nbsp;
                                            </td>
                                            <td width="180px" align="left">
                                                &nbsp;
                                            </td>
                                            <td width="200px" align="left">
                                                &nbsp;
                                            </td>
                                            <td width="170px" align="left">
                                                &nbsp;
                                            </td>
                                            <td width="200px" align="left">
                                                &nbsp;
                                            </td>
                                            <td width="150px" align="right">
                                                <asp:Label ID="lblTotalIncurred" runat="server"></asp:Label>
                                            </td>
                                            <td width="150px" align="right">
                                                <asp:Label ID="lblTotalPaid" runat="server"></asp:Label>
                                            </td>
                                            <td width="150px" align="right">
                                                <asp:Label ID="lblTotalOutstanding" runat="server"></asp:Label>
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
