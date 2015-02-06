<%@ Page Title="eRIMS Sonic :: Ohio WC Claim Information Search" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="OhioWCClaimSearch.aspx.cs" Inherits="SONIC_ClaimInfo_OhioWCClaimSearch"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery.maskedinput.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>
    <script language="javascript" type="text/javascript">
        //check Date Validation
        function CheckDate(sender, args) {
            args.IsValid = (ValidateDate(args.Value));
            return args.IsValid;
        }

        jQuery(function ($) {
            $("#<%=txtIncidentDate.ClientID%>").mask("99/99/9999");
        });
    </script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <div>
        <asp:UpdateProgress runat="server" ID="upProgress" DisplayAfter="100">
            <ProgressTemplate>
                <div class="UpdatePanelloading" id="divProgress" style="width: 100%;">
                    <table id="ProgressTable" cellpadding="0" cellspacing="0" border="0" style="width: 100%;
                        height: 100%;">
                        <tr align="center" valign="middle">
                            <td class="LoadingText" align="center" valign="middle">
                                <img src="../../Images/indicator.gif" alt="Loading" />&nbsp;&nbsp;&nbsp;Please Wait..
                            </td>
                        </tr>
                    </table>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
    <asp:UpdatePanel runat="server" ID="UpdSearch">
        <ContentTemplate>
            <asp:Panel ID="pnlSearchOhioWCClaim" runat="server">
                <table cellspacing="0" cellpadding="0" width="100%">
                    <tbody>
                        <tr>
                            <td class="groupHeaderBar" align="left">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 20px" class="Spacer"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlSearch" runat="server" DefaultButton="btnSearch">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tbody>
                                            <tr>
                                                <td style="width: 150px">
                                                </td>
                                                <td class="Spacer"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">&nbsp;&nbsp;Ohio WC Claim Information Search
                                                </td>                                               
                                            </tr>
                                            <tr>
                                                <td class="Spacer"></td>
                                                <td>
                                                    <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 14%" align="left">SONIC Location Code
                                                                </td>
                                                                <td style="width: 4%" align="center">:
                                                                </td>
                                                                <td style="width: 32%" align="left">
                                                                    <asp:DropDownList ID="ddlRMLocationNumber" runat="server" Width="170px"
                                                                        >
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="width: 18%" align="left">Date of Incident
                                                                </td>
                                                                <td style="width: 4%" align="center">:
                                                                </td>
                                                                <td style="width: 28%" align="left">
                                                                    <asp:TextBox ID="txtIncidentDate" runat="server" Width="160px"></asp:TextBox>
                                                                    <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtIncidentDate', 'mm/dd/y');"
                                                                        alt="Incident Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                    <asp:RegularExpressionValidator ID="revtxtIncidentDate" runat="server" ControlToValidate="txtIncidentDate"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                        ErrorMessage="Date Not Valid(Date of Incident)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                    <asp:CustomValidator ID="cvIncidentDate" runat="server" ControlToValidate="txtIncidentDate"
                                                                        ValidationGroup="vsErrorGroup" ClientValidationFunction="CheckDate" ErrorMessage="Date of Incident is not valid."
                                                                        Display="None">
                                                                    </asp:CustomValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Associate Name
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlAssociateName" runat="server" Width="160px"></asp:DropDownList>
                                                                    <%--<asp:TextBox ID="txtAssociateName" runat="server" Width="165px" SkinID="txtDisabled"></asp:TextBox>
                                                                <asp:Button ID="btnAssociateName" runat="server" Text="V" OnClientClick="OpenAssociateName();" />--%>
                                                                </td>
                                                                <td>First Report Number
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtFirstReportNumber" Width="180px" onKeyPress="return FormatInteger(event);"
                                                                        MaxLength="12"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="REVFirstReportNumber" runat="server" ControlToValidate="txtFirstReportNumber"
                                                                        Display="none" SetFocusOnError="true" ErrorMessage="First Report Number must be numeric"
                                                                        ValidationExpression="^\d+$" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Location d/b/a
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlLocationdba" runat="server"  Width="170px"
                                                                        >
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left">Legal Entity
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlLegalEntity" runat="server"  Width="170px"
                                                                        >
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr valign="top">
                                                                <td align="left">Claim Number
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlClaimNumber" runat="server" Width="170px">
                                                                    </asp:DropDownList>
                                                                    <%-- <asp:TextBox ID="txtClaimNumber" runat="server" Width="165px" SkinID="txtGeneral"></asp:TextBox>--%>
                                                                    <%-- <asp:Button ID="btnClaimNumber" runat="server" Text="V" OnClientClick="OpenClaimNumber();" />--%>
                                                                </td>
                                                              <%--  <td align="left">Claimant Name
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlClaimantName" runat="server" Width="170px">
                                                                    </asp:DropDownList>
                                                                    <asp:Button ID="btnClaimantName" runat="server" Text="V" OnClientClick="OpenClaimantName();" />
                                                                </td>--%>
                                                            </tr>
                                                            <tr valign="top">
                                                                <td align="left">Claim Status
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlClaimStatus" runat="server">
                                                                      <%--  <asp:ListItem Value="1" Selected="True">Active and Inactive</asp:ListItem>
                                                                        <asp:ListItem Value="Open" >Inactive Only</asp:ListItem>
                                                                        <asp:ListItem Value="Closed" >Active Only</asp:ListItem>--%>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 20px" class="Spacer" colspan="6"></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2">&nbsp;
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tbody>
                                        <tr>
                                            <td style="height: 24px" align="center">
                                                <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" ValidationGroup="vsErrorGroup"
                                                    Text="Search Claims" CausesValidation="true" ToolTip="Search"></asp:Button>&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnClear" runat="server" Text="  Clear  " OnClick="btnClear_Click" />&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnAdd" runat="server" Text="  Add  " OnClick="btnAdd_Click" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 20px" class="Spacer"></td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlSearchResult" runat="server">
                <table cellpadding="0" cellspacing="0" width="99%" align="center">
                    <tr>
                        <td width="100%" class="Spacer" style="height: 20px;"></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td width="45%">
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                            <tr>
                                                <td align="left">
                                                    <span class="heading">Ohio Claim Information Search Grid</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">&nbsp;
                                        <asp:Label ID="lblNumber" runat="server" Text="0"></asp:Label>&nbsp;Claim Informations
                                        Found
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="top" align="right">
                                        <uc:ctrlPaging ID="ctrlPageClaimInfo" runat="server" OnGetPage="GetPage" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 10px;"></td>
                    </tr>
                    <tr>
                        <td class="groupHeaderBar">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 20px;"></td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td width="100%" colspan="7" valign="top">
                                        <asp:GridView ID="gvClaimInfoSearchGrid" runat="server" DataKeyNames="PK_ID,Claim_Type,Imported"
                                            AutoGenerateColumns="false" Width="100%" AllowSorting="True" OnRowCommand="gvClaimInfoSearchGrid_RowCommand"
                                            OnRowCreated="gvClaimInfoSearchGrid_RowCreated" OnRowDataBound="gvClaimInfoSearchGrid_RowDataBound"
                                            OnSorting="gvClaimInfoSearchGrid_Sorting">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Claim Number" SortExpression="Origin_Claim_Number">
                                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="lnkView" CommandName="View">
                                                            <%#Eval("Origin_Claim_Number")%>
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sonic Location d/b/a" SortExpression="dba">
                                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                    <ItemTemplate>
                                                        <%#Eval("dba")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Name" SortExpression="Employee_Name">
                                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                    <ItemTemplate>
                                                        <%#Eval("Employee_Name")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date of Incident" SortExpression="Date_of_Accident">
                                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                    <ItemTemplate>
                                                        <asp:Label runat="Server" ID="lblDate_of_Accident"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Claim Type" SortExpression="Claim_Type">
                                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                    <ItemTemplate>
                                                        <%# Eval("Claim_Type")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <table cellpadding="4" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                                            <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" class="Spacer" style="height: 20px;"></td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="btnSearchAgain" runat="server" Text="Search Again" OnClick="btnSearchAgain_Click"
                                            ToolTip="Search Again" />
                                        <asp:Button ID="btnAddNew" runat="server" Text="  Add  " OnClick="btnAdd_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 20px;"></td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

