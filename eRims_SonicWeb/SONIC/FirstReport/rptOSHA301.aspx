<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="rptOSHA301.aspx.cs" Inherits="SONIC_FirstReport_rptOSHA301" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery.maskedinput.js"></script>
    <script language="javascript" type="text/javascript">

        jQuery(function ($) {
            $("#<%=txtIncident_Begin.ClientID%>").mask("99/99/9999");
             $("#<%=txtIncident_End.ClientID%>").mask("99/99/9999");
        });

        function CheckDates() {
            if (Page_ClientValidate()) {
                var dtStartDate = document.getElementById('<%=txtIncident_Begin.ClientID%>').value;
                var dtEndDate = document.getElementById('<%=txtIncident_End.ClientID%>').value;
                if (compareDate(dtStartDate, dtEndDate) == -1) {
                    alert("Incident Date Begin must be less than or equal to Incident Date End ");
                    return false;
                }
                else {
                    return true;
                }
            }
        }
    </script>

    <asp:ValidationSummary ID="valSummay" runat="server" ValidationGroup="vsErrorGroup"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following field(s):" />
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td colspan="6">&nbsp;
            </td>
        </tr>
        <tr>
            <td class="ghc" colspan="6">OSHA 301
            </td>
        </tr>
        <tr>
            <td colspan="6">&nbsp;
            </td>
        </tr>

        <tr>
            <td width="23%" align="right">
                Incident Date Begin <span id="Span1" style="color: Red;" runat="server">*</span>
            </td>
            <td width="4%" align="center">:
            </td>
            <td align="left" width="23%">
                <asp:TextBox runat="server" ID="txtIncident_Begin" Width="180px"></asp:TextBox>
                <img alt="Incident Date Begin" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtIncident_Begin', 'mm/dd/y');"
                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                    align="middle" />
                <asp:RequiredFieldValidator runat="server" ID="rfvIncident_Begin" ControlToValidate="txtIncident_Begin" ErrorMessage="Please Enter Incident Date Begin"
                    Display="None" ValidationGroup="vsErrorGroup">  </asp:RequiredFieldValidator>
            </td>
            <td width="23%" align="right">
               Incident Date End <span id="Span3" style="color: Red;" runat="server">*</span>
            </td>
            <td width="4%" align="center">:
            </td>
            <td align="left" width="23%">
                <asp:TextBox runat="server" ID="txtIncident_End" Width="180px"></asp:TextBox>
                <img alt="Incident Date End" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtIncident_End', 'mm/dd/y');"
                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                    align="middle" />
                <asp:RequiredFieldValidator runat="server" ID="rfvIncident_End" ControlToValidate="txtIncident_End" ErrorMessage="Please Enter Incident Date End"
                    Display="None" ValidationGroup="vsErrorGroup">  </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="6">&nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
               OSHA Coordinator <span id="Span2" style="color: Red;" runat="server">*</span>
            </td>
            <td align="center">:
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlOSHA_Coordinator" runat="server" Width="200px" SkinID="dropGen">
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ID="rfvOSHA_Coordinator" ControlToValidate="ddlOSHA_Coordinator" InitialValue="0" ErrorMessage="Please select OSHA Coordinator"
                    Display="None" ValidationGroup="vsErrorGroup">  </asp:RequiredFieldValidator>
            </td>
            <td colspan="3"></td>

        </tr>
        <tr>
            <td colspan="6">&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="6" align="center">
                <asp:Button ID="btnGenerate" runat="server" Text="Generate Report" ValidationGroup="vsErrorGroup" OnClick="btnGenerate_Click"  OnClientClick="return CheckDates();"/>
            </td>
        </tr>
        <tr>
            <td colspan="6">&nbsp;
            </td>
        </tr>
    </table>

</asp:Content>
