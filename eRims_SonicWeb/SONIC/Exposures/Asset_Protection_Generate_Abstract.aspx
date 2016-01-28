<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Asset_Protection_Generate_Abstract.aspx.cs"
    Inherits="SONIC_Exposures_Asset_Protection_Generate_Abstract" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Generate Abstract</title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server" ID="scMain" EnablePartialRendering="true">
    </asp:ScriptManager>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <div>
        <table border="0" cellpadding="3" cellspacing="3" width="100%">
            <tr>
                <td align="left" colspan="3">
                    <div class="bandHeaderRow">
                        Generate Abstract</div>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="3">
                </td>
            </tr>
            <tr>
                <td>
                   
                </td>
                <td>
                    
                </td>
                <td align="left">
                    <asp:RadioButtonList ID="rbtnList" runat="server">
                        <asp:ListItem Selected="True" Text="All Sections" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Current Section" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top" width="18%">
                    Begin Date
                </td>
                <td align="center" valign="top" width="4%">
                    :
                </td>
                <td align="left" valign="top" width="28%">
                    <asp:TextBox ID="txtBegin_Date" runat="server" MaxLength="10" SkinID="txtdate" Width="150px"></asp:TextBox>
                    <img alt="Begin Date" onclick="return showCalendar('<%=txtBegin_Date.ClientID %>', 'mm/dd/y');"
                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                        align="middle" />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptNegative="Left"
                        DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                        OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtBegin_Date"
                        CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                    </cc1:MaskedEditExtender>
                    <asp:RequiredFieldValidator ID="rdq" runat="server" ErrorMessage="Please enter Begin Date"
                        InitialValue="" Display="None" ControlToValidate="txtBegin_Date" SetFocusOnError="true"
                        ValidationGroup="vsErrorGroup" />
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="vsErrorGroup"
                        Display="none" ErrorMessage="Begin Date is not a valid date" SetFocusOnError="true"
                        ControlToValidate="txtBegin_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top" width="18%">
                    End Date
                </td>
                <td align="center" valign="top" width="4%">
                    :
                </td>
                <td align="left" valign="top" width="28%">
                    <asp:TextBox ID="txtEndDate" runat="server" MaxLength="10" SkinID="txtdate" Width="150px"></asp:TextBox>
                    <img alt="End Date" onclick="return showCalendar('<%=txtEndDate.ClientID %>', 'mm/dd/y');"
                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                        align="middle" />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AcceptNegative="Left"
                        DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                        OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtEndDate"
                        CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                    </cc1:MaskedEditExtender>
                    <asp:RequiredFieldValidator ID="revenddate" runat="server" ErrorMessage="Please enter End Date"
                        InitialValue="" Display="None" ControlToValidate="txtEndDate" SetFocusOnError="true"
                        ValidationGroup="vsErrorGroup" />
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="vsErrorGroup"
                        Display="none" ErrorMessage="End Date is not a valid date" SetFocusOnError="true"
                        ControlToValidate="txtEndDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                    <asp:CompareValidator ID="cvCompDate" runat="server" ControlToValidate="txtEndDate"
                        ValidationGroup="vsErrorGroup" ErrorMessage="End Date Must Be Greater Than Begin Date"
                        Type="Date" Operator="GreaterThanEqual" ControlToCompare="txtBegin_Date" Display="none">
                    </asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="center" valign="top" colspan="3">
                </td>
            </tr>
            <tr>
                <td align="center" valign="top" colspan="3">
                    <asp:Button ID="btnGenerateAbstract" Text="Generate Abstract" runat="server" OnClick="btnGenerateAbstract_OnClick"
                        CausesValidation="true" ValidationGroup="vsErrorGroup" />&nbsp;&nbsp;
                    <asp:Button ID="brnCancel" Text="Close" runat="server" CausesValidation="false" OnClientClick="window.close();" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
