<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="EmployeeSearch.aspx.cs"
    Inherits="EmployeeSearch" Title="eRIMS Sonic :: Search" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server"> 
    <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>

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
               <tr><td colspan="2" class="Spacer" style="height:10px;"></td></tr>
                <tr>
                    <td class="ghc" colspan="2">
                        Search
                    </td>
                </tr>
                <tr><td colspan="2" class="Spacer" style="height:10px;"></td></tr>
                <tr>
                <td width="20%">&nbsp;</td>
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
                                        <asp:DropDownList ID="ddlRMLocationNumber" AutoPostBack="true" SkinID="dropGen" runat="server" Width="375px"
                                            OnSelectedIndexChanged="ddlRMLocationNumber_SelectedIndexChanged">
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
                                        <asp:DropDownList runat="server" ID="ddlLegalEntity" AutoPostBack="true" SkinID="dropGen" Width="375px"
                                            OnSelectedIndexChanged="ddlLegalEntity_SelectedIndexChanged">
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
                                        <asp:DropDownList runat="server" ID="ddlLocationdba" AutoPostBack="true" SkinID="dropGen" Width="375px"
                                            OnSelectedIndexChanged="ddlLocationdba_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <%--<tr>
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
                                </tr>--%>
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
                                 <td colspan="2">&nbsp;</td>
                                    <td class="ic" align="left" colspan="3">
                                         &nbsp;&nbsp;<asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" ValidationGroup="vsErrorGroup"
                                            Text=" Search " OnClientClick="javascript:Search();"></asp:Button>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnAddNew" runat="server" Text="Add New" OnClick="btnAddNew_Click" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div id="divSearchpaging" runat="server" style="display: none;">
        <table style="width: 100%;" cellpadding="1" cellspacing="1">
            <tr><td colspan="2" class="Spacer" height="10px"></td></tr>
            <tr>
                <td style="width: 20%;" align="left" class="lc">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td align="left">
                                <span class="heading">Executive Risk Search Result</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                &nbsp;
                                <asp:Label ID="lblBankDetailsTotal" runat="server"></asp:Label>&nbsp;Found
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 80%;" align="right">
                    <table width="75%" cellpadding="2" cellspacing="2">
                        <tr>
                            <td class="lc">
                                No. of Records per page :
                                <asp:DropDownList ID="ddlPage" SkinID="dropGen" runat="server" DataSourceID="xdsPaging"
                                    DataTextField="Text" DataValueField="Value" AutoPostBack="True" OnSelectedIndexChanged="ddlPage_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:XmlDataSource ID="xdsPaging" runat="server" DataFile="~/App_Data/PagingTable.xml">
                                </asp:XmlDataSource>
                            </td>
                            <td class="ic">
                                <asp:Button ID="btnPrev" runat="server" OnClick="btnPrev_Click" Text=" < " SkinID="btnGen" />
                            </td>
                            <td class="lc">
                                <asp:Label ID="lblPageInfo" runat="server"></asp:Label>
                            </td>
                            <td class="ic">
                                <asp:Button ID="btnNext" runat="server" OnClick="btnNext_Click" Text=" > " SkinID="btnGen" />
                            </td>
                            <td class="lc">
                                Go to Page:
                            </td>
                            <td class="ic">
                                <asp:Panel runat="server" ID="pnl" DefaultButton="btnGo">
                                    <asp:TextBox ID="txtPageNo" runat="server" Width="20px" onkeypress="return numberOnly(event);"
                                        MaxLength="6"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="revPageNumber" runat="server" ErrorMessage="*"
                                        ControlToValidate="txtPageNo" Display="dynamic" ValidationExpression="^([0-9]*|\d*\d{1}?\d*)$"
                                        ValidationGroup="Paging"></asp:RegularExpressionValidator>
                                </asp:Panel>
                            </td>
                            <td class="ic">
                                <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" ValidationGroup="Paging"
                                    CausesValidation="true" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
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
                                        Search Result
                                    </td>
                                </tr>
                                <tr>
                                    <td class="spacer" height="10px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:GridView ID="gvSearch" runat="server" Width="100%" OnRowCommand="gvSearch_RowCommand"
                                            AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" OnSorting="gvSearch_Sorting"
                                            OnPageIndexChanging="gvSearch_PageIndexChanging" OnRowDataBound="gvSearch_RowDataBound"
                                            OnRowDeleting="gvSearch_RowDeleting" OnRowCreated="gvSearch_RowCreated" BorderWidth="1px"
                                            BorderColor="silver">
                                            <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center"></EmptyDataRowStyle>
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="2px" >
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblPrimaryID" Text='<%# Eval("PK_Employee_ID") %>'
                                                            Visible="false"></asp:Label>
                                                        <asp:Label runat="server" ID="lblTableName" Text='<%# Eval("TableName") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Claim_Number" SortExpression="Claim_Number" HeaderText="Claim Number">
                                                    <HeaderStyle></HeaderStyle>
                                                </asp:BoundField>                                              
                                                <asp:BoundField DataField="Location_Code" SortExpression="Location_Code"
                                                    HeaderText="Location Code"></asp:BoundField>
                                                     <asp:BoundField DataField="Location_Dba" SortExpression="Location_Dba"
                                                    HeaderText="Location dba"></asp:BoundField>
                                                <asp:BoundField DataField="Complainant_Plaintiff" SortExpression="Complainant_Plaintiff"
                                                    HeaderText="Complainant/Plaintiff"></asp:BoundField>
                                                <asp:BoundField HtmlEncode="False" DataFormatString="{0:MM/dd/yyyy}" DataField="DateOfLoss"
                                                    SortExpression="DateOfLoss" HeaderText="Date Of Loss"></asp:BoundField>
                                                <asp:TemplateField SortExpression="Claim Type" Visible="False" HeaderText="Claim Type">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblClaimTypeID" Text='<%# Eval("FK_Major_Claim_Type") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="FK_Major_Claim_Type" HeaderText="Claim Type">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblClaimType"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemStyle Width="40px" HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnEdit" CommandName="EditItem" runat="server" Text="Edit" ToolTip="Edit Claim" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemStyle Width="45px" HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" ToolTip="View Claim" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemStyle Width="55px" HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" ToolTip="Delete Claim" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnAddTo" runat="server" Text="Add to" CommandName="AddTo" ToolTip="Add to new claim" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="55px" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                No data found.
                                            </EmptyDataTemplate>
                                            <PagerSettings Visible="False" />
                                            <PagerStyle BackColor="#7F7F7F" BorderColor="#7F7F7F" HorizontalAlign="Left" VerticalAlign="Middle">
                                            </PagerStyle>
                                        </asp:GridView>
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
                        <asp:Button ID="btnMainBack" OnClick="btnBack_Click" runat="server" Text="Back To Search"
                            Visible="false"></asp:Button>&nbsp;&nbsp;
                        <asp:Button ID="btnAdd" runat="server" Text="Add New" OnClick="btnAddNew_Click" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>   
    <br />
</asp:Content>
