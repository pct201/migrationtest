<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Employee.aspx.cs"
    Inherits="Administrator_Employee" Title="eRIMS Sonic :: Employee" %>

<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Validator.js"></script>

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Date_Validation.js"></script>

    <script type="text/javascript" language="javascript">
        function CheckIsNumeric(source, arguments) {
            if (trim(arguments.Value) != '')
                arguments.IsValid = IsNumericNoAlert(RemoveCommas(arguments.Value));
        }

        function CheckBirthDate(source, args) {
            args.IsValid = CompareDateLessThanTodayNoAlert(args.Value);
            return args.IsValid;
        }

        function CheckDeathDate(source, args) {
            args.IsValid = CompareDateGreaterThanTodayNoAlert(args.Value);
            return args.IsValid;
        }
        
    </script>

    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields :" BorderWidth="1" BorderColor="DimGray">
    </asp:ValidationSummary>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="bandHeaderRow" align="left">
                Employee
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlEdit" runat="server">
                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="lblError" runat="server" Visible="False" Font-Bold="True" CssClass="error"></asp:Label>
                            </td>
                        </tr>
                        <tr valign="top">
                            <td>
                                Employee ID <span style="color: Red;">*</span>
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmployeeID" runat="server" MaxLength="50" Width="170px">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtEmployeeID" runat="server" Display="None" ErrorMessage="Please Enter Employee ID."
                                    ControlToValidate="txtEmployeeID" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">
                                First Name <span style="color: Red;">*</span>
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                <asp:TextBox ID="txtFirstName" runat="server" MaxLength="50" Width="170px"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="rfvAssociateName" ControlToValidate="txtFirstName"
                                    Display="none" ErrorMessage="Please Enter First Name." SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </td>
                            <td align="left" width="18%">
                                Last Name <span style="color: Red;">*</span>
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                <asp:TextBox ID="txtLastName" runat="server" MaxLength="50" Width="170px"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="rfvtxtLastName" ControlToValidate="txtLastName"
                                    Display="none" ErrorMessage="Please Enter Last Name." SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">
                                Middle Initial
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                <asp:TextBox ID="txtMIddleName" runat="server" Width="170px" MaxLength="50">
                                </asp:TextBox>
                            </td>
                            <td align="left" width="18%">
                                Date of Birth
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                <asp:TextBox ID="txtDate_Of_Birth" runat="server" Width="170px" SkinID="txtDate"
                                    MaxLength="10"></asp:TextBox>
                                <img alt="Date of Birth" onclick="return showCalendar('<%= txtDate_Of_Birth.ClientID %>', 'mm/dd/y');"
                                    onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                    align="middle" id="imgtxtDate_Of_Birth" /><br />
                                <asp:CustomValidator ID="csmvtxtDate_Of_Birth" runat="server" ErrorMessage="Date of Birth must be Less Than Current Date."
                                    Display="None" SetFocusOnError="true" ControlToValidate="txtDate_Of_Birth" ClientValidationFunction="CheckBirthDate"></asp:CustomValidator>
                                <asp:RegularExpressionValidator ID="rvtxtDate_Of_Birth" runat="server" ControlToValidate="txtDate_Of_Birth"
                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                    ErrorMessage="Date of Birth is Not Valid Date." Display="none" SetFocusOnError="true">
                                </asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Gender
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="M" Selected="True">Male</asp:ListItem>
                                    <asp:ListItem Value="F">Female</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td align="left">
                                Marital Status
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlMaritalStatus" runat="server" Width="170px" SkinID="ddlSONIC">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Number of Dependents
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtNumber_of_Dependents" runat="server" Width="170px" MaxLength="2"></asp:TextBox>
                                <asp:CustomValidator ID="csmvtxtNumber_of_Dependents" runat="server" ControlToValidate="txtNumber_of_Dependents"
                                    SetFocusOnError="true" ClientValidationFunction="CheckIsNumeric" Display="None"
                                    ErrorMessage="Number of Dependents is not valid Number."> 
                                </asp:CustomValidator>
                            </td>
                            <td align="left">
                                Date of Death
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDate_of_Death" runat="server" Width="170px" SkinID="txtDate"
                                    MaxLength="10"></asp:TextBox>
                                <img alt="Date of Death" onclick="return showCalendar('<%= txtDate_of_Death.ClientID %>', 'mm/dd/y');"
                                    onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                    align="middle" id="img2" />
                                <asp:CustomValidator ID="csmvtxtDate_of_Death" runat="server" ErrorMessage="Date of Death must be Less Than Current Date."
                                    Display="None" SetFocusOnError="true" ControlToValidate="txtDate_of_Death" ClientValidationFunction="CheckBirthDate"></asp:CustomValidator>
                                <asp:RegularExpressionValidator ID="revtxtDate_of_Death" runat="server" ControlToValidate="txtDate_of_Death"
                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                    ErrorMessage="Date of Death is Not Valid Date." Display="none" SetFocusOnError="true">
                                </asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="cmpvtxtDate_of_Death" runat="server" ControlToValidate="txtDate_of_Death"
                                    ControlToCompare="txtDate_Of_Birth" Type="Date" Operator="GreaterThanEqual" Display="None"
                                    ErrorMessage="Date of Death must be Greater than Date of Birth."></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Address 1&nbsp;
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtAddress_1" Width="170px" MaxLength="50"></asp:TextBox>
                            </td>
                            <td align="left">
                                Social Security Number
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtSocial_Security_Number" Width="170px" MaxLength="9"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Address 2
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtAddress_2" Width="170px" runat="server" MaxLength="50">
                                </asp:TextBox>
                            </td>
                            <td align="left">
                                Date of Hire
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDate_of_Hire" runat="server" Width="170px" SkinID="txtDate" MaxLength="10"></asp:TextBox>
                                <img alt="Date of Hire" onclick="return showCalendar('<%= txtDate_of_Hire.ClientID %>', 'mm/dd/y');"
                                    onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                    align="middle" id="img1" /><br />
                                <asp:RegularExpressionValidator ID="rvtxtDate_of_Hire" runat="server" ControlToValidate="txtDate_of_Hire"
                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                    ErrorMessage="Date of Hire is Not Valid Date." Display="none" SetFocusOnError="true">
                                </asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                City
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtCity" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                            </td>
                            <td align="left">
                                State
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlState" runat="server" Width="170px" SkinID="ddlSONIC">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Zip Code
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtZip_code" runat="server" Width="170px" MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revZipCode" runat="server" ErrorMessage="Zip Code is not valid"
                                    SetFocusOnError="true" ControlToValidate="txtZip_code" ValidationExpression="\b[0-9]{5}-[0-9]{4}\b|\b[0-9]{5}\b"
                                    Display="none" />
                            </td>
                            <td align="left">
                                Home Telephone (XXX-XXX-XXXX)
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtHome_Phone" runat="server" Width="170px" MaxLength="12" SkinID="txtPhone"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revtxtHome_Phone" ControlToValidate="txtHome_Phone"
                                    runat="server" ErrorMessage="Please Enter Home Telephone in XXX-XXX-XXXX format."
                                    Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Cell Phone (XXX-XXX-XXXX)
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtCell_phone" runat="server" Width="170px" SkinID="txtPhone" MaxLength="12"
                                    onpaste="return false"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revtxtCell_phone" ControlToValidate="txtCell_phone"
                                    runat="server" ErrorMessage="Please Enter Cell Phone in XXX-XXX-XXXX format."
                                    Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                            </td>
                            <td align="left">
                                Work Phone (XXX-XXX-XXXX)
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtWork_Phone" runat="server" Width="170px" MaxLength="12" SkinID="txtPhone"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revtxtWork_Phone" ControlToValidate="txtWork_Phone"
                                    runat="server" ErrorMessage="Please Enter Work Phone in XXX-XXX-XXXX format."
                                    Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Email Address
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtemail" runat="server" Width="170px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revtxtemail" runat="server" ControlToValidate="txtemail"
                                    Display="None" ErrorMessage="Email Address is not valid" SetFocusOnError="True"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </td>
                            <td align="left">
                                In Active
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtInactive" Width="170px" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                                Cost Center <span style="color: Red;">*</span>
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlCostCenter" runat="server" Width="170px" SkinID="ddlSONIC">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvddlCostCenter" runat="server" ControlToValidate="ddlCostCenter"
                                    Display="None" ErrorMessage="Please Select Cost Center" InitialValue="0"></asp:RequiredFieldValidator>
                            </td>
                            <td align="left">
                                Department
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDepartment" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Salary
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSalary" runat="server" Width="170px" onkeypress="return currencyFormat(this,',','.',event);"
                                    MaxLength="15"></asp:TextBox>
                                <asp:CustomValidator ID="cmvtxtSalary" runat="server" ControlToValidate="txtSalary"
                                    SetFocusOnError="true" ClientValidationFunction="CheckIsNumeric" Display="None"
                                    ErrorMessage="Salary is not valid Number."> 
                                </asp:CustomValidator>
                            </td>
                            <td align="left">
                                Salary Frequency
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSalary_Frequency" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Wages YTD
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtWages_YTD" runat="server" Width="170px" MaxLength="15"></asp:TextBox>
                                <asp:CustomValidator ID="csmvtxtWages_YTD" runat="server" ControlToValidate="txtWages_YTD"
                                    SetFocusOnError="true" ClientValidationFunction="CheckIsNumeric" Display="None"
                                    ErrorMessage="Wages YTD is not valid Number."> 
                                </asp:CustomValidator>
                            </td>
                            <td align="left">
                                Active Inactive Leave
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtActive_Inactive_Leave" runat="server" Width="170px" MaxLength="12"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Job Title
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtJob_Title" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                            </td>
                            <td align="left">
                                Job Classification
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlJobClassification" runat="server" Width="170px" SkinID="ddlSONIC">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Job Description
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtOccupation_description" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                            </td>
                            <td align="left">
                                Supervisor Name
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSupervisor_Name" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Driver's License State
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlDriver_License_state" runat="server" Width="170px" SkinID="ddlSONIC">
                                </asp:DropDownList>
                            </td>
                            <td align="left">
                                Driver's License Number
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDriver_License_Number" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Driver's License Type
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDriver_License_Type" runat="server" Width="170px" MaxLength="50">
                                </asp:TextBox>
                            </td>
                            <td align="left">
                                Driver's License Class
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDriver_License_Class" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Driver's License Restrictions
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDrivers_License_Restrictions" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                            </td>
                            <td align="left">
                                Driver's License Endorsements
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDrivers_License_Endorsements" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Driver's License Issued
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDrivers_License_Issued" runat="server" Width="170px" MaxLength="10"
                                    SkinID="txtDate"></asp:TextBox>
                                <img alt="Date of Birth" onclick="return showCalendar('<%= txtDrivers_License_Issued.ClientID %>', 'mm/dd/y');"
                                    onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                    align="middle" id="img3" /><br />
                                <asp:RegularExpressionValidator ID="rvtxtDrivers_License_Issued" runat="server" ControlToValidate="txtDrivers_License_Issued"
                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                    ErrorMessage="Driver's License Issued is Not Valid Date." Display="none" SetFocusOnError="true">
                                </asp:RegularExpressionValidator>
                            </td>
                            <td align="left">
                                Driver's License Expires
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDrivers_License_Expires" runat="server" Width="170px" MaxLength="10"
                                    SkinID="txtDate"></asp:TextBox>
                                <img alt="Date of Birth" onclick="return showCalendar('<%= txtDrivers_License_Expires.ClientID %>', 'mm/dd/y');"
                                    onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                    align="middle" id="img4" /><br />
                                <asp:RegularExpressionValidator ID="rvtxtDrivers_License_Expires" runat="server"
                                    ControlToValidate="txtDrivers_License_Expires" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                    ErrorMessage="Driver's License Expires is Not Valid Date." Display="none" SetFocusOnError="true">
                                </asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="cmpvtxtLicense_Expires" runat="server" ControlToValidate="txtDrivers_License_Expires"
                                    ControlToCompare="txtDrivers_License_Issued" Type="Date" Operator="GreaterThanEqual"
                                    Display="None" ErrorMessage="Driver's License Expires Date must be Greater than Or Equal to Driver's License Issued Date."></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Bank Number
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBankNumber" runat="server" Width="170px" SkinID="ddlSONIC">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:Button runat="server" ID="btnAssociateSave" Text="Save & View" OnClick="btnAssociateSave_Click"
                                    ToolTip="Save & View" />
                                &nbsp;&nbsp;
                                <asp:Button runat="server" ID="btnBackToSearch" Text="Back To Search" OnClick="btnBackToSearch_Click"
                                    ToolTip="Back To Search" CausesValidation="false" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlView" runat="server">
                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                        <tr valign="top">
                            <td>
                                Employee ID
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td>
                                <asp:Label ID="lblEmployeeID" runat="server">                                 
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">
                                First Name
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                <asp:Label ID="lblFirstName" runat="server"></asp:Label>
                            </td>
                            <td align="left" width="18%">
                                Last Name
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                <asp:Label ID="lblLastName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">
                                Middle Initial
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                <asp:Label ID="lblMIddleName" runat="server">
                                </asp:Label>
                            </td>
                            <td align="left" width="18%">
                                Date of Birth
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                <asp:Label ID="lblDate_Of_Birth" runat="server" SkinID="lblDate"></asp:Label>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Gender
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblGender" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                Marital Status
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblMaritalStatus" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Number of Dependents
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblNumber_of_Dependents" runat="server" onKeyPress="return FormatInteger(event);"></asp:Label>
                            </td>
                            <td align="left">
                                Date of Death
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblDate_of_Death" runat="server" SkinID="lblDate"></asp:Label>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Address 1&nbsp;
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label runat="server" ID="lblAddress_1"></asp:Label>
                            </td>
                            <td align="left">
                                Social Security Number
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label runat="server" ID="lblSocial_Security_Number"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Address 2
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblAddress_2" runat="server">
                                </asp:Label>
                            </td>
                            <td align="left">
                                Date of Hire
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblDate_of_Hire" runat="server" SkinID="lblDate"></asp:Label>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                City
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblCity" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                State
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblState" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Zip Code
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblZip_code" runat="server" onKeyPress="javascript:return FormatZipCode(event,this.id);"></asp:Label>
                            </td>
                            <td align="left">
                                Home Telephone (XXX-XXX-XXXX)
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblHome_Phone" runat="server" SkinID="lblPhone"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Cell Phone (XXX-XXX-XXXX)
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblCell_phone" runat="server" SkinID="lblPhone" onpaste="return false"></asp:Label>
                            </td>
                            <td align="left">
                                Work Phone (XXX-XXX-XXXX)
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblWork_Phone" runat="server" SkinID="lblPhone"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Email Address
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblemail" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                In Active
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label runat="server" ID="lblInactive"></asp:Label>
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                                Cost Center
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblCostCenter" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                Department
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblDepartment" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Salary
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblSalary" runat="server" onkeypress="return currencyFormat(this,',','.',event);"
                                    onpaste="return false"></asp:Label>
                            </td>
                            <td align="left">
                                Salary Frequency
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblSalary_Frequency" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Wages YTD
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblWages_YTD" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                Active Inactive Leave
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblActive_Inactive_Leave" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Job Title
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblJob_Title" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                Job Classification
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblJobClassification" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Job Description
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblOccupation_description" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                Supervisor Name
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblSupervisor_Name" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Driver's License State
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblDriver_License_state" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                Driver's License Number
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblDriver_License_Number" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Driver's License Type
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblDriver_License_Type" runat="server">
                                </asp:Label>
                            </td>
                            <td align="left">
                                Driver's License Class
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblDriver_License_Class" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Driver's License Restrictions
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblDrivers_License_Restrictions" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                Driver's License Endorsements
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblDrivers_License_Endorsements" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Driver's License Issued
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblDrivers_License_Issued" runat="server" SkinID="lblDate"></asp:Label>
                                <br />
                            </td>
                            <td align="left">
                                Driver's License Expires
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblDrivers_License_Expires" runat="server" SkinID="lblDate"></asp:Label>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Bank Number
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td>
                                <asp:Label ID="lblBankNumber" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:Button runat="server" ID="btnBackToEdit" Text=" Edit " OnClick="btnBackToEdit_Click"
                                    ToolTip="Edit" />
                                &nbsp;&nbsp;
                                <asp:Button runat="server" ID="btnBack" Text="Back To Search" OnClick="btnBackToSearch_Click"
                                    ToolTip="Back To Search" CausesValidation="false" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
