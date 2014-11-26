<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Calender.ascx.cs" Inherits="Controls_Calender" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

 

<script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar_new.js"></script>

<script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar-en.js"></script>

<script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar.js"></script>

<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="left" style="height: 15px;" valign="top" width="180px">
            <asp:TextBox ID="txtDate" runat="server" ReadOnly="false" MaxLength="10" Width="175px"></asp:TextBox>
        </td>
        <td valign="top" align="left">
            &nbsp;<img onclick="return showCalendarControl(<%=txtDate.ClientID %>, 'mm/dd/y');" onmouseover="javascript:this.style.cursor='hand';"
                src="<%=AppConfig.SiteURL%>JavaScript/iconPicDate.gif" align="absmiddle" />
            <cc1:MaskedEditExtender ID="Mask" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                OnInvalidCssClass="MaskedEditError" TargetControlID="txtDate" CultureName="en-US"
                AutoComplete="true" AutoCompleteValue="05/23/1964">
            </cc1:MaskedEditExtender>
            <asp:RegularExpressionValidator ID="revCal" runat="server" ControlToValidate="txtDate"
                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                ErrorMessage="[Claim Identification]/Date Reported to FairPoint is Not Valid."
                Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true">
            </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="reqDate" runat="server" ControlToValidate="txtDate"
                Display="none" Text="*" ErrorMessage="Please Enter Date " ValidationGroup="vsErrorGroup"
                SetFocusOnError="true"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="Mask"
                ControlToValidate="txtDate" IsValidEmpty="true" MaximumValue="" InvalidValueMessage="Invalid Date"
                Display="Dynamic" MaximumValueMessage="" MinimumValueMessage="" TooltipMessage=""
                MinimumValue="" ValidationGroup="vsErrorGroup">
            </cc1:MaskedEditValidator>
        </td>
        <td>
        </td>
    </tr>
</table>
