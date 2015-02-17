<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.master" CodeFile="COISearch.aspx.cs"
    Inherits="Admin_COISearch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Calender/Calender.ascx" TagName="ctrlCalendar" TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" src="../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar.js"></script>
    <script type="text/javascript">
        function CheckDate() {

        }
        function ShowDialog() {
            var w = 480, h = 340;
            var width = 750, height = 500;
            if (document.all || document.layers) {
                w = screen.availWidth;
                h = screen.availHeight;
            }

            var leftPos, topPos;
            var popW = width, popH = height;
            if (document.all)
            { leftPos = (w - popW) / 2; topPos = (h - popH) / 2; }
            else
            { leftPos = w / 2; topPos = h / 2; }
            var QryString = 'Search.aspx?txtID=<%=txtInsured.ClientID%>&tbl=<%=(int)clsGeneral.Tables.Insureds%>'
            window.open(QryString, "popup", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=" + popW + ",height=" + popH + ",top=" + topPos + ",left=" + leftPos);
            return false;
        }
    </script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td align="left" class="heading">
                &nbsp; Certificates of Insurance Search
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="2" cellspacing="2" width="100%" align="center">
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td width="10%">
                        </td>
                        <td align="left" width="30%">
                            Insured Name
                        </td>
                        <td width="5%" align="left">
                            :
                        </td>
                        <td align="left" width="55%">
                            <asp:TextBox ID="txtInsured" runat="server" MaxLength="254" Width="170"></asp:TextBox>&nbsp;
                            <asp:Button ID="btnEntityPopUp" runat="server" Text="V" OnClientClick="javascript:return ShowDialog()" />
                        </td>
                    </tr>
                    <tr>
                        <td width="10%">
                        </td>
                        <td align="left" width="30%" valign="top">
                            Location D/B/A
                        </td>
                        <td width="5%" align="left" valign="top">
                            :
                        </td>
                        <td align="left" width="55%">
                            <asp:ListBox ID="lstLocationDBA" runat="server" Width="250" SelectionMode="Multiple"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="10%">
                        </td>
                        <td align="left" width="30%" valign="top">
                            Location Code
                        </td>
                        <td width="5%" align="left" valign="top">
                            :
                        </td>
                        <td align="left" width="55%">
                            <asp:ListBox ID="lstLocationCode" runat="server" Width="250" SelectionMode="Multiple"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="left">
                            Address
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtAddress" runat="server" MaxLength="100" Width="195"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="left">
                            City
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtCity" runat="server" MaxLength="50" Width="195"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="left">
                            State
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <table width="100%">
                                <tr>
                                    <td width="35%">
                                        <asp:DropDownList ID="drpState" runat="server" Width="200px" SkinID="dropGen">
                                        </asp:DropDownList>
                                    </td>
                                    <td width="65%">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="left">
                            Issue Date
                        </td>
                        <td align="left">
                            From
                        </td>
                        <td align="left">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td align="left" valign="top" style="width: 35%">
                                        <asp:TextBox ID="txtIssueDateFrom" runat="server" ReadOnly="false" MaxLength="10"
                                            Width="180px" SkinID="txtDate"></asp:TextBox>
                                        <img onclick="return showCalendarControl(<%=txtIssueDateFrom.ClientID %>, 'mm/dd/y');"
                                            onmouseover="javascript:this.style.cursor='hand';" src="<%=AppConfig.SiteURL%>JavaScript/iconPicDate.gif"
                                            align="absmiddle" />
                                        <asp:RegularExpressionValidator ID="revIssueDateFrom" runat="server" ControlToValidate="txtIssueDateFrom"
                                            ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                            ErrorMessage="Please Enter Valid Issue From Date" Display="none" ValidationGroup="vsErrorGroup"
                                            SetFocusOnError="true">
                                        </asp:RegularExpressionValidator>
                                    </td>
                                    <td align="right" style="width: 5%" valign="top">
                                        To&nbsp;&nbsp; &nbsp;&nbsp;
                                    </td>
                                    <td valign="top" width="35%">
                                        <asp:TextBox ID="txtIssueDateTo" SkinID="txtDate" runat="server" ReadOnly="false"
                                            MaxLength="10" Width="127px"></asp:TextBox>
                                        <img onclick="return showCalendarControl(<%=txtIssueDateTo.ClientID %>, 'mm/dd/y');"
                                            onmouseover="javascript:this.style.cursor='hand';" src="<%=AppConfig.SiteURL%>JavaScript/iconPicDate.gif"
                                            align="absmiddle" />
                                        <asp:RegularExpressionValidator ID="revIssueDateTo" runat="server" ControlToValidate="txtIssueDateTo"
                                            ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                            ErrorMessage="Please Enter Valid Issue To Date" Display="none" ValidationGroup="vsErrorGroup"
                                            SetFocusOnError="true">
                                        </asp:RegularExpressionValidator>
                                        <asp:CompareValidator ID="cvCompDate" runat="server" ControlToValidate="txtIssueDateTo"
                                            ValidationGroup="vsErrorGroup" ErrorMessage="Issue date From must be Less than or equal to Issue date To"
                                            Type="Date" Operator="GreaterThanEqual" ControlToCompare="txtIssueDateFrom" Display="none">
                                        </asp:CompareValidator>
                                    </td>
                                    <td style="width: 5%">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>        
                    <tr>
                        <td>
                        </td>
                        <td align="left">
                            General Policy Number
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtGenPolicyNumber" runat="server" MaxLength="35" Width="195"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="left">
                            Automobile Policy Number
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtAutoPolicyNumber" runat="server" MaxLength="35" Width="195"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="left">
                            Excess Policy Number
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtExcessPolicyNumber" runat="server" MaxLength="35" Width="195"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="left">
                            Workers' Compensation/Employer’s Liability Policy Number
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtWCPolicyNumber" runat="server" MaxLength="35" Width="195"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="left">
                            Property Policy Number
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPropertyPolicyNumber" runat="server" MaxLength="35" Width="195"></asp:TextBox>
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
                <asp:Button ID="btnSearch" runat="server" SkinID="Search" OnClick="btnSearch_Click"
                    ValidationGroup="vsErrorGroup" />&nbsp;&nbsp; &nbsp; &nbsp;
                <asp:Button ID="btnAddNew" runat="server" SkinID="Add" OnClick="btnAddNew_Click"
                    Width="60px" />
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 15px;">
            </td>
        </tr>
    </table>
</asp:Content>
