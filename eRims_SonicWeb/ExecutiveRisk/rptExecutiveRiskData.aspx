<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="rptExecutiveRiskData.aspx.cs" Inherits="SONIC_ClaimInfo_rptExecutiveRiskData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery.maskedinput.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:CustomValidator ID="cvErrorMsg" runat="server" ErrorMessage="" EnableClientScript="false"
            ValidationGroup="vsErrorGroup" Display="None"></asp:CustomValidator>
    </div>
    <script type="text/javascript">
        function claimsearch() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_ddlSearch").value == "Employee") {
                oWnd = window.open("../Claim/EmployeePopup.aspx?Page=ClaimSearch", "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=700,height=450");
                oWnd.moveTo(200, 130);
                return false;
            }
            if (document.getElementById("ctl00_ContentPlaceHolder1_ddlSearch").value == "Claimant") {
                oWnd = window.open("../Claim/Claimant_search.aspx?Page=ClaimSearch", "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=610,height=350");
                oWnd.moveTo(250, 200);
                return false;
            }
            if (document.getElementById("ctl00_ContentPlaceHolder1_ddlSearch").value == "Driver") {
                oWnd = window.open("../Claim/Driver_Search.aspx?Page=ClaimSearch", "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=610,height=350");
                oWnd.moveTo(250, 200);
                return false;
            }
        }

        function Search() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_txtClaimNo").value == "__-_____-__") {
                document.getElementById("ctl00_ContentPlaceHolder1_txtClaimNo").value = "";
            }
            return true;
        }

        jQuery(function ($) {
            $("#<%=txtClaimNo.ClientID%>").mask("99-99999-99");
            $("#<%=txtOCFrom.ClientID%>").mask("99/99/9999");
            $("#<%=txtOCTo.ClientID%>").mask("99/99/9999");
        });
    </script>
    <div style="width: 100%" id="divSearch" runat="server">
        <table style="width: 100%" cellspacing="2" cellpadding="0" border="0">
            <tbody>
                <tr>
                    <td colspan="2" class="Spacer" style="height: 10px;">
                    </td>
                </tr>
                <tr>
                    <td class="ghc" colspan="2">
                        Executive Risk Data
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="Spacer" style="height: 10px;">
                    </td>
                </tr>
                <tr>
                    <td width="20%">
                        &nbsp;
                    </td>
                    <td>
                        <table style="width: 100%" cellspacing="5" cellpadding="1" border="0">
                            <tbody>
                                <tr>
                                    <td style="width: 20%" class="lc" align="left">
                                        SONIC Location Code
                                    </td>
                                    <td class="lc" width="5%">
                                        :
                                    </td>
                                    <td class="ic" valign="top" align="left">
                                        <asp:DropDownList ID="ddlRMLocationNumber" AutoPostBack="true" SkinID="dropGen" runat="server"
                                            Width="375px" OnSelectedIndexChanged="ddlRMLocationNumber_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td align="left">
                                        Legal Entity
                                    </td>
                                    <td align="left">
                                        :
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList runat="server" ID="ddlLegalEntity" AutoPostBack="true" SkinID="dropGen"
                                            Width="375px" OnSelectedIndexChanged="ddlLegalEntity_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td align="left">
                                        Location d/b/a
                                    </td>
                                    <td align="left">
                                        :
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList runat="server" ID="ddlLocationdba" AutoPostBack="true" SkinID="dropGen"
                                            Width="375px" OnSelectedIndexChanged="ddlLocationdba_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="lc" align="left">
                                        Entity
                                    </td>
                                    <td class="lc" width="5%">
                                        :
                                    </td>
                                    <td class="ic" valign="top" align="left">
                                        <asp:DropDownList ID="ddlEntity" runat="server" SkinID="dropGen" Width="375px" OnSelectedIndexChanged="ddlEntity_SelectedIndexChanged"
                                            AutoPostBack="true">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="ic">
                                        <asp:Label ID="lblCliamNo" runat="server">Claim Number</asp:Label>
                                    </td>
                                    <td class="ic">
                                        :
                                    </td>
                                    <td class="ic" colspan="3">
                                        <asp:TextBox ID="txtClaimNo" runat="server" Width="200px"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="rev3AdminTel" runat="server" ValidationGroup="vsErrorGroup"
                                            Display="none" ErrorMessage="Please Enter the Claim Number in xx-xxxxx-xx format."
                                            ControlToValidate="txtClaimNo" ValidationExpression="\d{2}-\d{5}-\d{2}$"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="ic">
                                        <asp:Label ID="lblExecutiveRisk" runat="server">Type Of Executive Risk</asp:Label>
                                    </td>
                                    <td class="lc">
                                        :
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlExecutiveRisk" Width="205px" runat="server" SkinID="dropGen">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <table cellspacing="2" cellpadding="0" width="100%" border="0">
                                            <tbody>
                                                <tr>
                                                    <td style="width: 20%" class="ic">
                                                        <asp:Label ID="lblOClFrom" runat="server">Date Of Loss From</asp:Label>
                                                    </td>
                                                    <td class="ic" style="width: 5%">
                                                        &nbsp;:
                                                    </td>
                                                    <td style="width: 20" class="ic" align="left">
                                                        &nbsp;&nbsp;<asp:TextBox ID="txtOCFrom" runat="server" Width="100px"></asp:TextBox>
                                                        <img onmouseover="javascript:this.style.cursor='hand';" alt="" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtOCFrom', 'mm/dd/y');"
                                                            src="../Images/iconPicDate.gif" align="middle" /><br />
                                                        <asp:RegularExpressionValidator ID="revOCFrom" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Date Not Valid(Open Claims From)" ControlToValidate="txtOCFrom"
                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"></asp:RegularExpressionValidator>
                                                    </td>
                                                    <td style="width: 12%" class="ic">
                                                        <asp:Label ID="lblOCTo" runat="server">Date Of Loss To</asp:Label>
                                                    </td>
                                                    <td class="ic" style="width: 1%">
                                                        :
                                                    </td>
                                                    <td style="width: 43%" class="ic" align="left">
                                                        <asp:TextBox ID="txtOCTo" runat="server" Width="100px"></asp:TextBox>
                                                        <img onmouseover="javascript:this.style.cursor='hand';" alt="" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtOCTo', 'mm/dd/y');"
                                                            src="../Images/iconPicDate.gif" align="middle" /><br />
                                                        <asp:RegularExpressionValidator ID="revOCTo" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Date Not Valid(Open Claims To)" ControlToValidate="txtOCTo"
                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"></asp:RegularExpressionValidator>
                                                        <asp:CompareValidator ID="cvCompOC" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Please Enter Date Of Loss To Greater Than Or Equal To Date Of Loss From."
                                                            ControlToValidate="txtOCTo" Type="Date" Operator="GreaterThanEqual" ControlToCompare="txtOCFrom">
                                                        </asp:CompareValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 20%" class="ic" valign="top">
                                                        <asp:Label ID="Label1" runat="server">Open Claim From</asp:Label>
                                                    </td>
                                                    <td class="ic" valign="top">
                                                        &nbsp;:
                                                    </td>
                                                    <td class="ic" valign="top" colspan="3">
                                                        <asp:RadioButtonList ID="rbtnOCFrom" runat="server" RepeatDirection="vertical" RepeatColumns="1">
                                                            <asp:ListItem Text="Open" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Closed" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Open and Closed" Value="3"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                    <td class="ic" align="left" colspan="3">
                                        &nbsp;&nbsp;<asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" ValidationGroup="vsErrorGroup"
                                            Text=" Generate Report " OnClientClick="javascript:Search();"></asp:Button>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div style="display: none; width: 100%" id="divGrid" runat="server">
        <table style="width: 100%" cellspacing="1" cellpadding="0" border="0">
            <tbody>
                <tr>
                    <td>
                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                            <tbody>
                                <tr>
                                    <td class="ghc" align="left">
                                        Executive Risk Data Report
                                    </td>
                                </tr>
                                <tr>
                                    <td class="spacer" height="10px">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="Div1" runat="server" style="width: 998px; overflow-x: scroll">
                                            <asp:GridView ID="gvSearch" runat="server" Width="4650px" AutoGenerateColumns="False"
                                                OnRowDataBound="gvSearch_RowDataBound" BorderWidth="1px"
                                                BorderColor="silver" OnRowCreated="gvSearch_RowCreated" EmptyDataText="No Record Found !"
                                                EnableTheming="false" GridLines="None">
                                                <HeaderStyle CssClass="HeaderStyle" />
                                                <RowStyle CssClass="RowStyle"/>
                                                <AlternatingRowStyle CssClass="AlterRowStyle" BackColor="White" />
                                                <FooterStyle ForeColor="Black" Font-Bold="true" />
                                                <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Location Code" HeaderStyle-Width="130px">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblPrimaryID" Text='<%# Eval("PrimaryID") %>' Visible="false"></asp:Label>
                                                            <asp:Label runat="server" ID="lblTableName" Text='<%# Eval("TableName") %>' Visible="false"></asp:Label>
                                                            <asp:Label runat="server" ID="lblPK_Executive_Risk" Text='<%# Eval("PK_Executive_Risk") %>'
                                                                Visible="false"></asp:Label>
                                                            <%# Eval("Sonic_Location_Code")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:BoundField DataField="Sonic_Location_Code" HeaderText="Location Code">
                                                        <HeaderStyle Width="70px" />
                                                    </asp:BoundField>--%>
                                                    <asp:BoundField DataField="dba" HeaderText="Sonic d/b/a">
                                                        <HeaderStyle Width="280px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Complainant_Plaintiff" HeaderText="Complainant/Plaintiff">
                                                        <HeaderStyle Width="200px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Claim_Number" HeaderText="Claim Number">
                                                        <HeaderStyle Width="150px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Type_of_Claim" HeaderText="Type of Claim">
                                                        <HeaderStyle Width="150px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Claim_Type_Other" HeaderText="Other">
                                                        <HeaderStyle Width="150px" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Type of Allegation" HeaderStyle-Width="240px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblType_of_Allegation" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date Claim Opened" HeaderStyle-Width="200px">
                                                        <ItemTemplate>
                                                            <%# Eval("Claim_Open_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Claim_Open_Date"))) : ""%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Bordereau Report" HeaderStyle-Width="200px">
                                                        <ItemTemplate>
                                                            <%# Eval("Bordereau_Report").ToString() == "Y" ? "Yes" : "No"%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:BoundField DataField="Bordereau_Report" HeaderText="Bordereau Report">
                                                        <HeaderStyle Width="75px" />
                                                    </asp:BoundField>--%>
                                                    <asp:TemplateField HeaderText="EEOC" HeaderStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <%# Eval("EEOC").ToString() == "Y" ? "Yes" : "No" %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="State_Employment_Commission" HeaderText="State of Employment Commission">
                                                        <HeaderStyle Width="250px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Jurisdiction" HeaderText="Jurisdiction">
                                                        <HeaderStyle Width="150px" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Date Complaint Suit Filed" HeaderStyle-Width="200px">
                                                        <ItemTemplate>
                                                            <%# Eval("Date_Complaint_Suit_Filed") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Complaint_Suit_Filed"))) : ""%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Policy Effective Date" HeaderStyle-Width="200px">
                                                        <ItemTemplate>
                                                            <%# Eval("Primary_Policy_Effective_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Primary_Policy_Effective_Date"))) : ""%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Policy Expiration Date" HeaderStyle-Width="200px">
                                                        <ItemTemplate>
                                                            <%# Eval("Primary_Policy_Expiration_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Primary_Policy_Expiration_Date"))) : ""%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date of Alleged Wrongful Act" HeaderStyle-Width="200px">
                                                        <ItemTemplate>
                                                            <%# Eval("Date_Alleged_Wrongful_Act") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Alleged_Wrongful_Act"))) : ""%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date Legal Received Complaint" HeaderStyle-Width="250px">
                                                        <ItemTemplate>
                                                            <%# Eval("Date_Legal_Received_Complaint") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Legal_Received_Complaint"))) : ""%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Defense Attorney(s)" HeaderStyle-Width="350px" ItemStyle-VerticalAlign="Top">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDefenceAttorney" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Plaintiff Attorney(s)" HeaderStyle-Width="350px" ItemStyle-VerticalAlign="Top">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPlatiniffAttorney" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                                                        HeaderText="Estimated Demand Exposure" HeaderStyle-Width="200px">
                                                        <ItemTemplate>
                                                            <%# String.Format("{0:C2}", Eval("Estimated_Demand_Exposure"))%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                                                        HeaderText="Estimated Defense Expense" HeaderStyle-Width="200px">
                                                        <ItemTemplate>
                                                            <%#   String.Format("{0:C2}", Eval("Estimated_Defense_Expense"))%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                                                        HeaderText="Actual Settlement" HeaderStyle-Width="150px">
                                                        <ItemTemplate>
                                                            <%# String.Format("{0:C2}", Eval("Actual_Settlement"))%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                        HeaderText="Actual Settlement Date" HeaderStyle-Width="150px">
                                                        <ItemTemplate>
                                                            <%# Eval("Actual_Settlement_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Actual_Settlement_Date"))) : ""%>
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
                    <td class="spacer" height="10px">
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnMainBack" OnClick="btnBack_Click" runat="server" Text="Back To Filter"
                            Visible="false"></asp:Button>&nbsp;&nbsp;
                        <asp:Button ID="btnGenerateReport" OnClick="btnGenerateReport_Click" runat="server"
                            Text="Export To Excel" Visible="false" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <br />
</asp:Content>
