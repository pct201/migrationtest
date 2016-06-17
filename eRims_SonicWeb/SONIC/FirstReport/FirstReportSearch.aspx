<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="FirstReportSearch.aspx.cs"
    Inherits="SONIC_FirstReportSearch" Title="eRIMS Sonic :: First Report Search" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>
      <script type="text/javascript" language="javascript" src="../../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery.maskedinput.js"></script>
    <script language="javascript" type="text/javascript">
        //check Date Validation
        function CheckDate(sender, args) {
            args.IsValid = (ValidateDate(args.Value));
            return args.IsValid;
        }

        jQuery(function ($) {
            $("#<%=txtIncidentStartDate.ClientID%>").mask("99/99/9999");
            $("#<%=txtIncidentDate.ClientID%>").mask("99/99/9999");
            $("#<%=txtIncidentEndDate.ClientID%>").mask("99/99/9999");
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
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td class="groupHeaderBar" align="left">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="Spacer" style="height: 20px;">
                        <asp:HiddenField runat="server" ID="HdnEmployeeID" />
                         <asp:HiddenField runat="server" ID="HdnEmployeeName" />
                        <input type="hidden" id="hdnEmpval" name="hdnEmpval" />
                        <input type="hidden" id="hdnEmpName" name="hdnEmpName" />
                         <asp:Button ID="btnAssName" OnClick="btnAssName_OnClick" runat="server" Style="display: none;" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel runat="server" ID="pnlSearch" DefaultButton="btnSearch">
                            <table cellpadding="4" cellspacing="1" border="0" width="100%">
                                <tr>
                                    <td class="headerrow">
                                        &nbsp;&nbsp;First Report Search
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table cellpadding="3" cellspacing="1" width="95%" border="0">
                                            <tr>
                                                <td align="left" style="width: 12%">
                                                    SONIC Location Code
                                                </td>
                                                <td align="center" style="width: 4%">
                                                    :
                                                </td>
                                                <td align="left" style="width: 36%">
                                                    <asp:DropDownList ID="ddlRMLocationNumber" AutoPostBack="true" SkinID="dropGen" Width="250px"
                                                        runat="server" OnSelectedIndexChanged="ddlRMLocationNumber_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 14%">
                                                    Date of Incident
                                                </td>
                                                <td align="center" style="width: 2%">
                                                    :
                                                </td>
                                                <td align="left" style="width: 28%">
                                                    <asp:TextBox ID="txtIncidentDate" runat="server" Width="170px"></asp:TextBox>
                                                    <img alt="Incident Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtIncidentDate', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                        align="middle" /><br />
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
                                                    <a href="#" id="lnkAssName" onclick="OpenAssociateName();" runat="server">Associate Name</a>
                                                </td>
						<td>
							&nbsp;
						</td>
						<td>
							&nbsp;
						</td>
						<td>
							&nbsp;
						</td>
                                            </tr>
                                            <tr>
                                                <%--<td align="left">
                                                    Legal Entity 
                                                </td>
                                                 <td align="center">
                                                    :
                                                </td>
                                                 <td align="left">
                                                 <asp:DropDownList runat="server" ID="ddlLegalEntity" AutoPostBack="true" SkinID="dropGen"  Width="250px"
                                                        OnSelectedIndexChanged="ddlLegalEntity_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                 </td>--%>

                                                <td align="left">
                                                  Date of Incident Start 
                                                </td>
                                                <td align="center">
                                                   :
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtIncidentStartDate" runat="server" SkinID="txtDate" Width="170px"></asp:TextBox>
                                                    <img alt="Incident Start Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtIncidentStartDate', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                        align="middle" />
                                                    <asp:RangeValidator ID="revStartRangeDate" ControlToValidate="txtIncidentStartDate"
                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Incident Start Date is not valid."
                                                        runat="server" ValidationGroup="vsErrorGroup" Display="none" />
                                                </td>

                                                 <td align="left">
                                                    Date of Incident End
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtIncidentEndDate" runat="server" SkinID="txtDate" Width="170px"></asp:TextBox>
                                                    <img alt="Incident End Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtIncidentEndDate', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                        align="middle" />
                                                       <asp:RangeValidator ID="revDate" ControlToValidate="txtIncidentEndDate" MinimumValue="01/01/1753"
                                                        MaximumValue="12/31/9999" Type="Date" ErrorMessage="Incident End Date is not valid."
                                                        runat="server" ValidationGroup="vsErrorGroup" Display="none" />
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
                                                    <asp:DropDownList runat="server" ID="ddlLocationdba" AutoPostBack="true" SkinID="Default"
                                                        Width="250px" OnSelectedIndexChanged="ddlLocationdba_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left">
                                                    First Report Number 
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                   <asp:TextBox runat="server" ID="txtFirstReportNumber" Width="190px" onKeyPress="return FormatInteger(event);"
                                                        MaxLength="12"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="REVFirstReportNumber" runat="server" ControlToValidate="txtFirstReportNumber"
                                                        Display="none" SetFocusOnError="true" ErrorMessage="First Report Number must be numeric"
                                                        ValidationExpression="^\d+$" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
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
                                                    <asp:DropDownList runat="server" ID="ddlLocationfka" AutoPostBack="true" SkinID="dropGen" Width="250px"
                                                        OnSelectedIndexChanged="ddlLocationfka_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left">
                                                   First Report Category 
                                                </td>
                                                <td align="center">
                                                   :
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList runat="server" ID="ddlCategory" SkinID="dropGen" Width="195px">
                                                        <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                                        <asp:ListItem>NS</asp:ListItem>
                                                        <asp:ListItem>WC</asp:ListItem>
                                                        <asp:ListItem>AL</asp:ListItem>
                                                        <asp:ListItem>DPD</asp:ListItem>
                                                        <asp:ListItem>PL</asp:ListItem>
                                                        <asp:ListItem>Property</asp:ListItem>
                                                    </asp:DropDownList> 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" style="height: 20px;" colspan="3">
                                                </td>
                                                <td align="left">
                                                    Carrier/TPA Claim Number
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlClaimNumber" SkinID="dropGen" Width="195px" runat="server" Enabled="false">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" style="height: 20px;" colspan="3">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                            <tr>
                                                <td align="center" style="height: 24px">
                                                    <asp:Button ID="btnSearch" runat="server" Text="Search First Reports" CausesValidation="true"
                                                        ValidationGroup="vsErrorGroup" OnClick="btnSearch_Click" ToolTip="Search" OnClientClick="return CheckDates();"/>
                                                    &nbsp;&nbsp;<asp:Button ID="btnAdd" runat="server" Text="Add First Report" CausesValidation="false"
                                                        OnClick="btnAdd_Click" ToolTip="Add" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td class="Spacer" style="height: 20px;">
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">

        var GB_ROOT_DIR = '<%=AppConfig.SiteURL%>' + 'greybox/';
        function OpenAssociateName() {
            GB_showCenter('Associate Name', '<%=AppConfig.SiteURL%>SONIC/FirstReport/AssociateNamePopup.aspx', 500, 500, ReturnFunc);
        }
        function ReturnFunc() {
            document.getElementById('<%=HdnEmployeeID.ClientID %>').value = document.getElementById('hdnEmpval').value;
        }
    </script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/gb_scripts.js"></script>
    <script language="javascript" type="text/javascript">
        //used to get height of scrollbar and add to total screen height +  scollbar height
        function getScrollHeight() {
            var h = window.pageYOffset ||
           document.body.scrollTop ||
           document.documentElement.scrollTop;
            document.getElementById('divProgress').style.height = screen.height + h;
            document.getElementById('ProgressTable').style.height = screen.height + h;
        }
    </script>
    <script language="javascript" type="text/javascript">
        window.onscroll = getScrollHeight;
    </script>
    <script type="text/javascript">
        document.body.onkeypress = function () { if (event.keyCode == 13) document.getElementById('<%=btnSearch.ClientID%>').click(); }
        function CheckDates() {
            if (Page_ClientValidate()) {
                var dtStartDate = document.getElementById('<%=txtIncidentStartDate.ClientID%>').value;
                var dtEndDate = document.getElementById('<%=txtIncidentEndDate.ClientID%>').value;
                if (compareDate(dtStartDate, dtEndDate) == -1) {
                    alert("Incident Start Date must be less than or equal to Incident End Date");
                    return false;
                }
                else {
                    return true;
                }
            }
        }
</script>
</asp:Content>
