<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="ExposureSearch.aspx.cs"
    Inherits="Exposures_ExposureSearch" Title="eRIMS Sonic :: Exposures Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
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
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel runat="server" ID="pnlSearch">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td colspan="2" width="100%">
                                        &nbsp;&nbsp;<span class="heading">Exposures Search</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="height: 10px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="width: 50px;">
                                    </td>
                                    <td>
                                        <table cellpadding="3" cellspacing="1" width="100%" border="0">
                                            <tr>
                                                <td align="left" style="width: 16%">
                                                    Sonic Location Code
                                                </td>
                                                <td align="center" style="width: 4%">
                                                    :
                                                </td>
                                                <td align="left" style="width: 36%">
                                                    <asp:DropDownList ID="ddlRMLocationNumber" AutoPostBack="true" SkinID="Default" Width="90%"
                                                        runat="server" OnSelectedIndexChanged="ddlRMLocationNumber_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <%--<td align="left" style="width: 12%">
                                                    Date Range Start
                                                </td>
                                                <td align="center" style="width: 4%">
                                                    :
                                                </td>
                                                <td align="left" style="width: 28%">
                                                    <asp:TextBox ID="txtStartRangeDate" runat="server" SkinID="txtDate"></asp:TextBox>
                                                    <img alt="Range Start Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtStartRangeDate', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                        align="middle" />
                                                    <asp:RangeValidator ID="revStartRangeDate" ControlToValidate="txtStartRangeDate"
                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Range Start Date is not valid."
                                                        runat="server" ValidationGroup="vsErrorGroup" Display="none" />
                                                </td>--%>
                                            </tr>
                                            <tr>
                                                <%--<td align="left">
                                                    Legal Entity
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList runat="server" ID="ddlLegalEntity" AutoPostBack="true" SkinID="Default"
                                                        Width="90%" OnSelectedIndexChanged="ddlLegalEntity_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>--%>
                                                <td align="left" style="width: 12%">
                                                    Date Range Start
                                                </td>
                                                <td align="center" style="width: 4%">
                                                    :
                                                </td>
                                                <td align="left" style="width: 28%">
                                                    <asp:TextBox ID="txtStartRangeDate" runat="server" SkinID="txtDate"></asp:TextBox>
                                                    <img alt="Range Start Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtStartRangeDate', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                        align="middle" />
                                                    <asp:RangeValidator ID="revStartRangeDate" ControlToValidate="txtStartRangeDate"
                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Range Start Date is not valid."
                                                        runat="server" ValidationGroup="vsErrorGroup" Display="none" />
                                                </td>
                                                <td>
                                                    Date Range End
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtEndRangeDate" runat="server" SkinID="txtDate"></asp:TextBox>
                                                    <img alt="Range End Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtEndRangeDate', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                        align="middle" />
                                                    <asp:RangeValidator ID="revDate" ControlToValidate="txtEndRangeDate" MinimumValue="01/01/1753"
                                                        MaximumValue="12/31/9999" Type="Date" ErrorMessage="Range End Date is not valid."
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
                                                        Width="90%" OnSelectedIndexChanged="ddlLocationdba_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left">
                                                    &nbsp;
                                                </td>
                                                <td align="center">
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    &nbsp;
                                                </td>
                                            </tr>
<!--
                                            <tr>
                                                <td align="left">
                                                    Location f/k/a
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList runat="server" ID="ddlLocationfka" AutoPostBack="true" SkinID="Default"
                                                        Width="90%" OnSelectedIndexChanged="ddlLocationfka_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left">
                                                    &nbsp;
                                                </td>
                                                <td align="center">
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    &nbsp;
                                                </td>
                                            </tr>
-->
                                            <tr>
                                                <td align="left">
                                                    Main Address
                                                </td>    
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtMainAddress" runat="server" Width="175px" MaxLength="50" />
                                                </td>
                                                <td align="left">
                                                    Building Address
                                                </td>    
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtBuildingAddress" runat="server" Width="175px" MaxLength="50" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    Main City
                                                </td>    
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtMainCity" runat="server" Width="175px" MaxLength="50" />
                                                </td>
                                                <td align="left">
                                                    Building City
                                                </td>    
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtBuildingCity" runat="server" Width="175px" MaxLength="50" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    Main State
                                                </td>    
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="drpMainState" runat="server" Width="180px" SkinID="dropGen" />
                                                </td>
                                                <td align="left">
                                                    Building State
                                                </td>    
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="drpBuildingState" runat="server" Width="180px" SkinID="dropGen" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    Main Zip
                                                </td>    
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtMainZip" runat="server" Width="175px" MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);"/>
                                                </td>
                                                <td align="left">
                                                    Building Zip
                                                </td>    
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtBuildingZip" runat="server" Width="175px" MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" style="height: 20px;" colspan="6">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                            <tr>
                                                <td align="center" style="height: 24px">
                                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CausesValidation="true" ValidationGroup="vsErrorGroup"
                                                        ToolTip="Search" OnClick="btnSearch_Click" OnClientClick="return CheckDates();" />
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
        document.body.onkeypress = function() { if (event.keyCode == 13) document.getElementById('<%=btnSearch.ClientID%>').click(); }
        function CheckDates() {
            if (Page_ClientValidate()) {
                var dtStartDate = document.getElementById('<%=txtStartRangeDate.ClientID%>').value;
                var dtEndDate = document.getElementById('<%=txtEndRangeDate.ClientID%>').value;
                if (compareDate(dtStartDate, dtEndDate) == -1) {
                    alert("Start Date must be less than End Date");
                    return false;
                }
                else {
                    return true;
                }
            }
        }
    </script>

</asp:Content>
