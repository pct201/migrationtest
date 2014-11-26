<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="EmployeeSearch.aspx.cs"
    Inherits="EmployeeSearch" Title="Risk Management Insurance System" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <asp:ScriptManager runat="server" ID="scManager">
    </asp:ScriptManager>
    <script type="text/javascript" language="javascript" src="JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="JavaScript/jquery.maskedinput.js"></script>
    <script type="text/javascript" language="javascript" src="JavaScript/Calendar.js"></script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:CustomValidator ID="cvErrorMsg" runat="server" ErrorMessage="" EnableClientScript="false"
            ValidationGroup="vsErrorGroup" Display="None"></asp:CustomValidator>
    </div>
    <script type="text/javascript">

        function claimsearch() {
            alert(document.getElementById("ctl00_ContentPlaceHolder1_ddlSearch").value);
            if (document.getElementById("ctl00_ContentPlaceHolder1_ddlSearch").value == "Employee") {
                oWnd = window.open("WorkerCompensation/Employee_Search_Popup.aspx?Page=ClaimSearch", "Erims1", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
                oWnd.moveTo(300, 200);
                return false;
            }
            if (document.getElementById("ctl00_ContentPlaceHolder1_ddlSearch").value == "Claimant") {
                oWnd = window.open("Liability/Claimant_search.aspx?Page=ClaimSearch", "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
                oWnd.moveTo(300, 200);
                return false;
            }
        }
        function Search() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_txtClaimNo").value == "__-_____-__") {
                document.getElementById("ctl00_ContentPlaceHolder1_txtClaimNo").value = "";
            }
            if (document.getElementById("ctl00_ContentPlaceHolder1_txtSSN").value == "___-__-____") {
                document.getElementById("ctl00_ContentPlaceHolder1_txtSSN").value = "";
            }
            return true;
        }

        jQuery(function ($) {
            $("#<%=txtClaimNo.ClientID%>").mask("99-99999-99");
            $("#<%=txtSSN.ClientID%>").mask("999-99-9999");
            $("#<%=txtDOIncident.ClientID%>").mask("99/99/9999");
            $("#<%=txtOCFrom.ClientID%>").mask("99/99/9999");
            $("#<%=txtOCTo.ClientID%>").mask("99/99/9999");
            $("#<%=txtCCFrom.ClientID%>").mask("99/99/9999");
            $("#<%=txtCCTo.ClientID%>").mask("99/99/9999");
        });
    </script>
    <link href="../App_Themes/Default/stylecal.css" type="text/css" rel="Stylesheet" />
    <div style="width: 100%" runat="server" id="divSearch">
        <table border="1" cellpadding="0" cellspacing="2" style="width: 98%;">
            <tr>
                <td>
                    <table cellpadding="2" cellspacing="4" border="0" style="width: 100%;">
                        <tr>
                            <td class="ghc" colspan="5">
                                Search
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <asp:TextBox runat="server" ID="txtEmpID" Style="display: none;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="ic" style="width: 20%;">
                                <asp:DropDownList runat="server" ID="ddlSearch">
                                    <asp:ListItem Value="Employee" Text="Employee"></asp:ListItem>
                                    <asp:ListItem Value="Claimant" Text="Claimant"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="lc" style="width: 5%;">
                                :
                            </td>
                            <td class="ic" style="width: 25%;">
                                <asp:TextBox ReadOnly="true" runat="server" ID="txtLastName"></asp:TextBox>
                                <asp:Button runat="server" ID="btnEmpSearch" Text=">>" OnClientClick="javascript:claimsearch();" /><br />
                                (Last Name)
                            </td>
                            <td class="ic" style="width: 25%;">
                                <asp:TextBox ReadOnly="true" runat="server" ID="txtMiddleName"></asp:TextBox><br />
                                (Middle Name)
                            </td>
                            <td class="ic" style="width: 25%;">
                                <asp:TextBox ReadOnly="true" runat="server" ID="txtFirstName"></asp:TextBox><br />
                                (First Name)
                            </td>
                        </tr>
                        <tr>
                            <td class="ic">
                                <asp:Label ID="lblSSN" runat="server">SSN</asp:Label>
                            </td>
                            <td class="lc">
                                :
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtSSN" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revSSN" ControlToValidate="txtSSN" runat="server"
                                    ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the SSN in xxx-xx-xxxx format."
                                    Display="none" ValidationExpression="\d{3}-\d{2}-\d{4}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ic">
                                <asp:Label ID="lblDOIncident" runat="server">Date of Incident</asp:Label>
                            </td>
                            <td class="lc">
                                :
                            </td>
                            <td colspan="3" class="ic">
                                <asp:TextBox ID="txtDOIncident" runat="server"></asp:TextBox>
                                <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDOIncident', 'mm/dd/y');"
                                    onmouseover="javascript:this.style.cursor='hand';" src="Images/iconPicDate.gif"
                                    align="middle" /><br />
                                <asp:RegularExpressionValidator ID="revDOInciden" runat="server" ControlToValidate="txtDOIncident"
                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                    ErrorMessage="Date Not Valid(Date of Incident)." Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ic" valign="top">
                                <asp:Label ID="lblClaimType" runat="server">Claim Type</asp:Label>
                            </td>
                            <td class="ic" valign="top">
                                :
                            </td>
                            <td class="ic" colspan="3">
                                <asp:CheckBoxList ID="chkLstClaimType" runat="server" RepeatDirection="vertical">
                                    <asp:ListItem Text="Workers Compensation" Value="Workers_Comp"></asp:ListItem>
                                    <asp:ListItem Text="Auto Liability" Value="Liability_Claim"></asp:ListItem>
                                    <asp:ListItem Text="General Liability" Value="Liability_Claim"></asp:ListItem>
                                    <asp:ListItem Text="Property Loss" Value="Liability_Claim"></asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td class="ic">
                                <asp:Label runat="server" ID="lblCliamNo">Claim Number</asp:Label>
                            </td>
                            <td class="ic">
                                :
                            </td>
                            <td class="ic" colspan="3">
                                <asp:TextBox runat="server" ID="txtClaimNo"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="rev3AdminTel" ControlToValidate="txtClaimNo"
                                    runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Claim Number in xx-xxxxx-xx format."
                                    Display="none" ValidationExpression="\d{2}-\d{5}-\d{2}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <table cellpadding="0" cellspacing="2" border="0" width="100%">
                                    <tr>
                                        <td style="width: 20%" class="ic">
                                            <asp:Label runat="server" ID="lblOClFrom">Open Claims From</asp:Label>
                                        </td>
                                        <td style="width: 5%" class="ic">
                                            :
                                        </td>
                                        <td style="width: 25%;" class="ic">
                                            <asp:TextBox ID="txtOCFrom" runat="server"></asp:TextBox>
                                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtOCFrom', 'mm/dd/y');"
                                                onmouseover="javascript:this.style.cursor='hand';" src="Images/iconPicDate.gif"
                                                align="middle" /><br />
                                            <asp:RegularExpressionValidator ID="revOCFrom" runat="server" ControlToValidate="txtOCFrom"
                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                ErrorMessage="Date Not Valid(Open Claims From)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                        </td>
                                        <td style="width: 20%" class="ic">
                                            <asp:Label runat="server" ID="lblOCTo">Open Claims To</asp:Label>
                                        </td>
                                        <td style="width: 5%" class="ic">
                                            :
                                        </td>
                                        <td style="width: 25%;" class="ic">
                                            <asp:TextBox ID="txtOCTo" runat="server"></asp:TextBox>
                                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtOCTo', 'mm/dd/y');"
                                                onmouseover="javascript:this.style.cursor='hand';" src="Images/iconPicDate.gif"
                                                align="middle" /><br />
                                            <asp:RegularExpressionValidator ID="revOCTo" runat="server" ControlToValidate="txtOCTo"
                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                ErrorMessage="Date Not Valid(Open Claims To)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                            <asp:CompareValidator ID="cvCompOC" runat="server" ControlToValidate="txtOCTo" ValidationGroup="vsErrorGroup"
                                                ErrorMessage="Please Enter Open Claims To Greater Than Open Claims From." Type="Date"
                                                Operator="GreaterThan" ControlToCompare="txtOCFrom" Display="none">
                                            </asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" class="ic">
                                            <asp:Label runat="server" ID="Label1">Closed Claims From</asp:Label>
                                        </td>
                                        <td style="width: 5%" class="ic">
                                            :
                                        </td>
                                        <td style="width: 25%;" class="ic">
                                            <asp:TextBox ID="txtCCFrom" runat="server"></asp:TextBox>
                                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCCFrom', 'mm/dd/y');"
                                                onmouseover="javascript:this.style.cursor='hand';" src="Images/iconPicDate.gif"
                                                align="middle" /><br />
                                            <asp:RegularExpressionValidator ID="revCCFrom" runat="server" ControlToValidate="txtCCFrom"
                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                ErrorMessage="Date Not Valid(Closed Claims From)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                        </td>
                                        <td style="width: 20%" class="ic">
                                            <asp:Label runat="server" ID="Label2">Closed Claims To</asp:Label>
                                        </td>
                                        <td style="width: 5%" class="ic">
                                            :
                                        </td>
                                        <td style="width: 25%;" class="ic">
                                            <asp:TextBox ID="txtCCTo" runat="server"></asp:TextBox>
                                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCCTo', 'mm/dd/y');"
                                                onmouseover="javascript:this.style.cursor='hand';" src="Images/iconPicDate.gif"
                                                align="middle" /><br />
                                            <asp:RegularExpressionValidator ID="revCCTo" runat="server" ControlToValidate="txtCCTo"
                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                ErrorMessage="Date Not Valid(Closed Claims To)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                            <asp:CompareValidator ID="cmCompCC" runat="server" ControlToValidate="txtCCTo" ValidationGroup="vsErrorGroup"
                                                ErrorMessage="Please Enter Closed Claims To Greater Than Closed Claims From."
                                                Type="Date" Operator="GreaterThan" ControlToCompare="txtCCFrom" Display="none">
                                            </asp:CompareValidator>
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
                        <tr>
                            <td class="ic" align="center" colspan="5">
                                <asp:Button ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click"
                                    ValidationGroup="vsErrorGroup" OnClientClick="javascript:Search();" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div style="width: 100%; display: none;" runat="server" id="divGrid">
        <table cellpadding="0" cellspacing="2" border="1" style="width: 98%;">
            <tr>
                <td>
                    <table cellpadding="2" cellspacing="4" border="0" style="width: 100%;">
                        <tr>
                            <td align="left" class="ghc">
                                Search Result
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">
                                <asp:GridView ID="gvSearch" runat="server" Width="100%" OnRowCommand="gvSearch_RowCommand"
                                    AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" OnSorting="gvSearch_Sorting"
                                    OnPageIndexChanging="gvSearch_PageIndexChanging" OnRowDataBound="gvSearch_RowDataBound"
                                    PageSize="20">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblPrimaryID" Text='<%# Eval("PK_Employee_ID") %>'
                                                    Visible="false"></asp:Label>
                                                <asp:Label runat="server" ID="lblTableName" Text='<%# Eval("TableName") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Claim_Number" HeaderText="Claim Number" SortExpression="Claim_Number">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Social_Security_Number" HeaderText="SSN" SortExpression="Social_Security_Number">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Last_Name" HeaderText="Last Name" SortExpression="Last_Name">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="First_Name" HeaderText="First Name" SortExpression="First_Name">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Middle_Name" HeaderText="Middle Name" SortExpression="Middle_Name">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Incident_Date" HeaderText="Date Of Incident" SortExpression="Incident_Date"
                                            DataFormatString="{0:MM/dd/yyyy}" HtmlEncode="false"></asp:BoundField>
                                        <asp:BoundField DataField="Claim_Close_Date" HeaderText="Close Date" SortExpression="Claim_Close_Date"
                                            DataFormatString="{0:MM/dd/yyyy}" HtmlEncode="false"></asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnEdit" CommandName="EditItem" runat="server" Text="Edit" ToolTip="Edit the Check Details" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%# Eval("PK_Employee_ID") %>'
                                                    ToolTip="View the Check Details" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataRowStyle ForeColor="red" HorizontalAlign="Center" />
                                    <EmptyDataTemplate>
                                        Currently there is no search result.<br />
                                        <br />
                                        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
                                    </EmptyDataTemplate>
                                    <PagerSettings Visible="true" />
                                    <PagerStyle BackColor="#7F7F7F" BorderColor="#7F7F7F" HorizontalAlign="Left" VerticalAlign="Middle" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <br />
</asp:Content>
