<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.master"
    CodeFile="LetterHistorySearch.aspx.cs" Inherits="Admin_LetterHistorySearch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

  <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar_new.js"></script>

<script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar-en.js"></script>

<script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar.js"></script>
 <script type="text/javascript" language="javascript">
 function ShowDialogBox() {
            
            var w = 480, h = 340;
            var width = 670, height = 500;
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
           // return false;
        }
         </script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" class="Spacer" style="height: 25px;">
            </td>
        </tr>
        <tr>
            <td align="left" class="heading">
                &nbsp;&nbsp;Letter History Search
            </td>
        </tr>     
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="2" cellspacing="2" width="100%">
                    <tr>
                        <td width="20%">
                        </td>
                        <td width="10%" align="left" style="height: 17px;">
                            Insured
                        </td>
                        <td width="5%" align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtInsured" runat="server" Width="180px" MaxLength="254"></asp:TextBox>&nbsp;
                            <a href="javascript:ShowDialogBox();">
                                <img src="<%=AppConfig.SiteURL%>Images/dropdown_icon.gif" height="17" align="top" /></a>
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
                                    <td width="34%" align="left">
                                        <asp:TextBox ID="txtIssueDateFrom" runat="server" ReadOnly="false" MaxLength="10"
                                            Width="180px" SkinID="txtDate"></asp:TextBox>
                                        <img onclick="return showCalendarControl(<%=txtIssueDateFrom.ClientID %>, 'mm/dd/y');" onmouseover="javascript:this.style.cursor='hand';"
                                            src="<%=AppConfig.SiteURL%>JavaScript/iconPicDate.gif" align="absmiddle" />
                                        <asp:RegularExpressionValidator ID="revIssueDateFrom" runat="server" ControlToValidate="txtIssueDateFrom"
                                            ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                            ErrorMessage="Please Enter Valid Issue From Date" Display="none" ValidationGroup="vsErrorGroup"
                                            SetFocusOnError="true">
                                        </asp:RegularExpressionValidator>
                                    </td>
                                    <td align="center" width="5%">
                                        To
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtIssueDateTo" runat="server" ReadOnly="false" MaxLength="10" Width="180px" SkinID="txtDate"></asp:TextBox>
                                        <img onclick="return showCalendarControl(<%=txtIssueDateTo.ClientID %>, 'mm/dd/y');" onmouseover="javascript:this.style.cursor='hand';"
                                            src="<%=AppConfig.SiteURL%>JavaScript/iconPicDate.gif" align="absmiddle" />
                                        <asp:RegularExpressionValidator ID="revIssueDateTo" runat="server" ControlToValidate="txtIssueDateTo"
                                            ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                            ErrorMessage="Please Enter Valid Issue To Date" Display="none" ValidationGroup="vsErrorGroup"
                                            SetFocusOnError="true">
                                        </asp:RegularExpressionValidator>
                                        <asp:CompareValidator ID="cvCompDate" runat="server" ControlToValidate="txtIssueDateTo"
                                            ValidationGroup="vsErrorGroup" ErrorMessage="Issue date FROM must be Greater than or equal to Issue date TO"
                                            Type="Date" Operator="GreaterThanEqual" ControlToCompare="txtIssueDateFrom" Display="none">
                                        </asp:CompareValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="left">
                            Date Letter Sent
                        </td>
                        <td align="left">
                            From
                        </td>
                        <td align="left">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td width="34%" align="left">
                                        <asp:TextBox ID="txtDateLetterFrom" runat="server" ReadOnly="false" MaxLength="10"
                                            Width="180px" SkinID="txtDate"></asp:TextBox>
                                        <img onclick="return showCalendarControl(<%=txtDateLetterFrom.ClientID %>, 'mm/dd/y');"
                                            onmouseover="javascript:this.style.cursor='hand';" src="<%=AppConfig.SiteURL%>JavaScript/iconPicDate.gif"
                                            align="absmiddle" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtDateLetterFrom"
                                            ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                            ErrorMessage="Please Enter Valid Letter Sent From Date" Display="none" ValidationGroup="vsErrorGroup"
                                            SetFocusOnError="true">
                                        </asp:RegularExpressionValidator>
                                    </td>
                                    <td align="center" width="5%">
                                        To
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDateLetterTo" runat="server" ReadOnly="false" MaxLength="10"
                                            Width="180px" SkinID="txtDate"></asp:TextBox>
                                        <img onclick="return showCalendarControl(<%=txtDateLetterTo.ClientID %>, 'mm/dd/y');" onmouseover="javascript:this.style.cursor='hand';"
                                            src="<%=AppConfig.SiteURL%>JavaScript/iconPicDate.gif" align="absmiddle" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtDateLetterTo"
                                            ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                            ErrorMessage="Please Enter Valid Letter Sent To Date" Display="none" ValidationGroup="vsErrorGroup"
                                            SetFocusOnError="true">
                                        </asp:RegularExpressionValidator>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtDateLetterTo"
                                            ValidationGroup="vsErrorGroup" ErrorMessage="Letter Sent date FROM must be Greater than or equal to Letter Sent date TO"
                                            Type="Date" Operator="GreaterThanEqual" ControlToCompare="txtDateLetterFrom"
                                            Display="none">
                                        </asp:CompareValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td width="100%" class="Spacer" style="height: 25px;">
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnSearch" runat="server" SkinID="Search" OnClick="btnSearch_Click"
                    ValidationGroup="vsErrorGroup" />
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 25px;">
            </td>
        </tr>
    </table>
</asp:Content>
