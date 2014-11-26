<%@ Page Language="C#" Title="eRIMS :: Loss Stratification Report" MasterPageFile="~/Tatva_ScheduleMaster.master"
    AutoEventWireup="true" CodeFile="ScheduleLossStratification.aspx.cs" Inherits="ClaimDetailReport_ScheduleLossStratification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>

    <script type="text/javascript" language="javascript" src="../../Controls/MonthSelector/MonthSelector.js"></script>

    <script type="text/javascript" language="javascript">
   
        function CheckScheduleDate(obj,args)
        {
            var retVal = true;
            ErrorMsg = '';                                                           
                
            if(document.getElementById('<%=txtScheduleDate.ClientID %>').value != '')
            {
                var dateSelected = new Date(document.getElementById('<%=txtScheduleDate.ClientID %>' ).value);
                var dateEnd = new Date(document.getElementById('<%=txtScheduleEndDate.ClientID %>' ).value);
                var dateToday =new Date();
                if(dateSelected < dateToday)
                {
                    args.IsValid = false;
                    retVal= false;
                }
            }
            return retVal;
        }
        
        function CheckScheduleEndDate(obj,args)
        {
            var retVal = true;
            ErrorMsg = '';                                                           
                
            if(document.getElementById('<%=txtScheduleDate.ClientID %>').value != '' && document.getElementById('<%=txtScheduleEndDate.ClientID %>').value != '')
            {
                var dateSelected = new Date(document.getElementById('<%=txtScheduleDate.ClientID %>' ).value);
                var dateEnd = new Date(document.getElementById('<%=txtScheduleEndDate.ClientID %>' ).value);
                if(dateEnd < dateSelected)
                {
                    args.IsValid = false;
                    retVal= false;
                }
            }
            return retVal;
        }
    
    </script>

    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        CssClass="errormessage"></asp:ValidationSummary>
    <asp:HiddenField ID="hdnInnerHtml" runat="server" />
    <table width="100%">
        <tr>
            <td align="left" class="ghc">
                Loss Stratification Report
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 15px;">
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 21px">
                <asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="red" Font-Bold="true"></asp:Label>
                <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Green" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                <table width="80%" align="center" cellpadding="5" cellspacing="0">
                    <tr>
                        <td style="width: 30%;" valign="top">
                            &nbsp; Accident Year <span style="color: Red;">*</span>
                        </td>
                        <td align="left" valign="top" width="4">
                            :
                        </td>
                        <td style="width: 65%;">
                            <asp:ListBox ID="lsbPolicyYear" runat="server" SelectionMode="Multiple" Rows="4"
                                ToolTip="Select Accident Year" AutoPostBack="false" Width="166px"></asp:ListBox>
                            <asp:RequiredFieldValidator ID="rfvPolicyYear" runat="server" ErrorMessage="Please Select Accident Year"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="lsbPolicyYear" SetFocusOnError="false"></asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 65%">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            &nbsp; Claim Type <span style="color: Red;">*</span>
                        </td>
                        <td align="left" valign="top" width="4">
                            :
                        </td>
                        <td valign="top">
                            <asp:ListBox ID="lsbClaimType" runat="server" SelectionMode="Multiple" Rows="4" ToolTip="Select Claim Type"
                                AutoPostBack="false" Width="166px">
                                <asp:ListItem Value="W" Text="Workers Compensation"></asp:ListItem>
                                <asp:ListItem Value="A" Text="Auto Loss"></asp:ListItem>
                                <asp:ListItem Value="P" Text="Premises Loss"></asp:ListItem>
                            </asp:ListBox>
                            <asp:RequiredFieldValidator ID="rfvlsbClaimType" runat="server" ErrorMessage="Please Select Claim Type"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="lsbClaimType" SetFocusOnError="false"></asp:RequiredFieldValidator>
                        </td>
                        <td valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="150">
                            Scheduled Date<span class="mf">*</span>
                        </td>
                        <td align="center" width="4">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtScheduleDate" Width="100px" SkinID="txtDate"></asp:TextBox>
                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtScheduleDate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtScheduleDate"
                                ErrorMessage="Scheduled Date must not be Blank" SetFocusOnError="true" Display="none" />
                            <asp:RangeValidator ID="RangeValidator6" ControlToValidate="txtScheduleDate" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Scheduled Date is not valid"
                                runat="server" SetFocusOnError="true" Display="none" />
                            <asp:CustomValidator ID="cstValidator" runat="server" ErrorMessage="Scheduled Date must greater than current date."
                                ClientValidationFunction="CheckScheduleDate" Display="None" SetFocusOnError="false"
                                Text=""></asp:CustomValidator>
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="150">
                            Scheduled End Date<span class="mf">*</span>
                        </td>
                        <td align="center" width="4">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtScheduleEndDate" Width="100px" SkinID="txtDate"></asp:TextBox>
                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtScheduleEndDate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtScheduleEndDate"
                                ErrorMessage="Scheduled End Date must not be Blank" SetFocusOnError="true" Display="none" />
                            <asp:RangeValidator ID="RangeValidator7" ControlToValidate="txtScheduleEndDate" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Scheduled End Date is not valid"
                                runat="server" SetFocusOnError="true" Display="none" />
                            <asp:CustomValidator ID="csvtxtScheduleEndDate" runat="server" ErrorMessage="Scheduled End Date must greater than Scheduled Date."
                                ClientValidationFunction="CheckScheduleEndDate" Display="None" SetFocusOnError="false"
                                Text=""></asp:CustomValidator>
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="150">
                            Recurring Period<span class="mf">*</span>
                        </td>
                        <td align="center" width="4">
                            :
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="drpRecurringPeriod" runat="server" EnableTheming="True" SkinID="dropGen"
                                Width="150px">
                                <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Weekly"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Monthly"></asp:ListItem>
                                <asp:ListItem Value="3" Text="Quarterly"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvdrpRecurringPeriod" runat="server" ErrorMessage="Please Select Recurring Period."
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="drpRecurringPeriod"
                                InitialValue="0" SetFocusOnError="false"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="150">
                            Recipient List<span class="mf">*</span>
                        </td>
                        <td align="center" width="4">
                            :
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="drpRecipientList" runat="server" EnableTheming="True" SkinID="dropGen"
                                Width="150px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please Select Recipient List"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="drpRecipientList"
                                InitialValue="0" SetFocusOnError="false"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="150">
                        </td>
                        <td align="center" width="4">
                        </td>
                        <td align="left">
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                            &nbsp;
                            <input type="button" class="btn" value="Close" onclick="javascript:window.close();" />
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
