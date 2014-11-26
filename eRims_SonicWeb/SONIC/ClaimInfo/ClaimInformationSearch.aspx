<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="ClaimInformationSearch.aspx.cs"
    Inherits="SONIC_ClaimInformationSearch" Title="eRIMS Sonic :: Claim Information Search" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery.maskedinput.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>
    <script type="text/javascript">
        var GB_ROOT_DIR = '<%=AppConfig.SiteURL%>' + 'greybox/';
        function OpenClaimNumber() {
            GB_showCenter('Claim Number', '<%=AppConfig.SiteURL%>SONIC/ClaimInfo/ClaimNumberPopup.aspx', 500, 650, '');
            return false;
        }

        function OpenClaimantName() {
            GB_showCenter('Claimant Name', '<%=AppConfig.SiteURL%>SONIC/ClaimInfo/ClaimantNamePopup.aspx', 500, 500, '');
            return false;
        }

        function OpenAssociateName() {
            GB_showCenter('Associate Name', '<%=AppConfig.SiteURL%>SONIC/ClaimInfo/AssociateNamePopup.aspx', 500, 500, '');
            return false;
        }

        function AssignValue(EmpName) {
            document.getElementById('<%=txtClaimNumber.ClientID%>').innerText = EmpName;
        }
    
    </script>
    <link href="<%=AppConfig.SiteURL%>greybox/gb_styles.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/gb_scripts.js"></script>
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
            <table cellspacing="0" cellpadding="0" width="100%">
                <tbody>
                    <tr>
                        <td class="groupHeaderBar" align="left">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px" class="Spacer">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlSearch" runat="server" DefaultButton="btnSearch">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tbody>
                                        <tr>
                                            <td style="width: 150px">
                                                &nbsp;&nbsp;Claim Information Search
                                            </td>
                                            <td class="Spacer">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Spacer">
                                            </td>
                                            <td>
                                                <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 14%" align="left">
                                                                SONIC Location Code
                                                            </td>
                                                            <td style="width: 4%" align="center">
                                                                :
                                                            </td>
                                                            <td style="width: 32%" align="left">
                                                                <asp:DropDownList ID="ddlRMLocationNumber" runat="server" AutoPostBack="true" Width="170px"
                                                                    OnSelectedIndexChanged="ddlRMLocationNumber_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 18%" align="left">
                                                                Date of Incident
                                                            </td>
                                                            <td style="width: 4%" align="center">
                                                                :
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
                                                            <td align="left">
                                                                Associate Name
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtAssociateName" runat="server" Width="165px" SkinID="txtDisabled"></asp:TextBox>
                                                                <asp:Button ID="btnAssociateName" runat="server" Text="V" OnClientClick="OpenAssociateName();" />
                                                            </td>
                                                            <td>
                                                                First Report Number
                                                            </td>
                                                            <td align="center">
                                                                :
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
                                                            <td align="left">
                                                                Location d/b/a
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlLocationdba" runat="server" AutoPostBack="true" Width="170px"
                                                                    OnSelectedIndexChanged="ddlLocationdba_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left">
                                                                Legal Entity
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlLegalEntity" runat="server" AutoPostBack="true" Width="170px"
                                                                    OnSelectedIndexChanged="ddlLegalEntity_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Location f/k/a
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlLocationfka" runat="server" AutoPostBack="true" Width="170px"
                                                                    OnSelectedIndexChanged="ddlLocationfka_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left">
                                                                Carrier/TPA Claim Number
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <%--<asp:DropDownList ID="ddlClaimNumber" runat="server" Width="170px">
                                                                </asp:DropDownList>--%>
                                                                <asp:TextBox ID="txtClaimNumber" runat="server" Width="165px" SkinID="txtDisabled"></asp:TextBox>
                                                                <asp:Button ID="btnClaimNumber" runat="server" Text="V" OnClientClick="OpenClaimNumber();" />
                                                            </td>
                                                        </tr>
                                                        <tr valign="top">
                                                            <td align="left">
                                                                Claimant Name
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <%--<asp:DropDownList ID="ddlClaimantName" runat="server" Width="170px">
                                                                </asp:DropDownList>--%>
                                                                <asp:TextBox ID="txtClaimantName" runat="server" Width="165px" SkinID="txtDisabled"></asp:TextBox>
                                                                <asp:Button ID="btnClaimantName" runat="server" Text="V" OnClientClick="OpenClaimantName();" />
                                                            </td>
                                                            <td align="left">
                                                                Claim Type
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlClaimType" runat="server" Width="170px" OnSelectedIndexChanged="ddlLegalEntity_SelectedIndexChanged">
                                                                    <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                                                    <asp:ListItem>NS</asp:ListItem>
                                                                    <asp:ListItem>WC</asp:ListItem>
                                                                    <asp:ListItem>AL</asp:ListItem>
                                                                    <asp:ListItem>DPD</asp:ListItem>
                                                                    <asp:ListItem>Property</asp:ListItem>
                                                                    <asp:ListItem>PL</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr valign="top">
                                                            <td align="left">
                                                                Claims
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:RadioButtonList ID="rdoClaim" runat="server" RepeatDirection="Vertical" RepeatColumns="1">
                                                                    <asp:ListItem Text="Both Opened and Closed" Selected="True"></asp:ListItem>
                                                                    <asp:ListItem Text="Closed Only" Value="C"></asp:ListItem>
                                                                    <asp:ListItem Text="Open Only" Value="O"></asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 20px" class="Spacer" colspan="6">
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                &nbsp;
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
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px" class="Spacer">
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
