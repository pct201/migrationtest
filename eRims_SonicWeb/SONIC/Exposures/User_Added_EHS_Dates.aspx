<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User_Added_EHS_Dates.aspx.cs" Inherits="SONIC_Exposures_User_Added_EHS_Dates" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Added EHS Dates</title>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>

    <script type="text/javascript" language="javascript">
        function ConfirmDelete() {
            return confirm("Are you sure that you want to delete the Date information shown on the User Added EHS Dates window?");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
                HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
                ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
            <table cellpadding="3" cellspacing="1" border="0" width="860px" class="dvContainer">
                <tr>
                    <td class="bandHeaderRow" colspan="7" width="100%">User Added EHS Dates
                    </td>
                </tr>
                <tr>
                    <td class="Spacer" colspan="7" style="height: 8px;" width="100%"></td>
                </tr>
                <tr>
                    <td style="width: 15%" align="left">Location <span style="color: Red">*</span>

                    </td>
                    <td style="width: 1%" align="center">:
                    </td>
                    <td style="width: 30%" align="left">

                        <asp:DropDownList ID="ddlLocation" runat="server" Width="150px" SkinID="ddlSONIC"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvLocation" runat="server" ErrorMessage="Please Select Location"
                            ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToValidate="ddlLocation"
                            InitialValue="0" Display="None"></asp:RequiredFieldValidator>
                    </td>
                    <td style="width: 4%">&nbsp;

                    </td>
                    <td style="width: 22%" align="left">Category <span style="color: Red">*</span>

                    </td>
                    <td style="width: 1%" align="center">: </td>
                    <td style="width: 27%" align="left">

                        <asp:TextBox ID="txtCategory" runat="Server" MaxLength="75" Width="170px"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="rfvCategory" runat="Server" ControlToValidate="txtCategory"
                            SetFocusOnError="true" ErrorMessage="Please Enter Category" Display="None"
                            CssClass="NormalFont" ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left">Type 

                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">

                        <asp:TextBox ID="txtType" runat="Server" MaxLength="75" Width="170px"></asp:TextBox>
                    </td>
                    <td>&nbsp;

                    </td>
                    <td align="left">Date Due/Completion Date  <span style="color: Red">*</span>

                    </td>
                    <td align="center">: </td>
                    <td align="left">
                        <asp:TextBox ID="txtDue_Date" runat="server" Width="150px" SkinID="txtDate" />
                        <img alt="Date Due/Completion Date" onclick="return showCalendar('txtDue_Date', 'mm/dd/y');" onmouseover="javascript:this.style.cursor='pointer';"
                            src="../../Images/iconPicDate.gif" align="middle" />

                        <asp:RegularExpressionValidator ID="revDate" runat="server" ValidationGroup="vsErrorGroup"
                            Display="none" ErrorMessage="Date Due/Completion Date Is not a valid date" SetFocusOnError="true"
                            ControlToValidate="txtDue_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvDue_Date" runat="Server" ControlToValidate="txtDue_Date"
                            SetFocusOnError="true" ErrorMessage="Please Enter Date Due/Completion Date" Display="None"
                            CssClass="NormalFont" ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="Spacer" colspan="7" style="height: 8px;" width="100%"></td>
                </tr>
                <tr valign="top">
                    <td colspan="7" align="center">
                        <asp:Button ID="btnSave" runat="Server" Text="Save" ValidationGroup="vsErrorGroup" OnClick="btnSave_Click" />&nbsp;
                            <asp:Button ID="btnClose" runat="server" Text="Cancel" OnClientClick="javascript:window.close();" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" Visible="false" OnClientClick="javascript:return ConfirmDelete();" OnClick="btnDelete_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
