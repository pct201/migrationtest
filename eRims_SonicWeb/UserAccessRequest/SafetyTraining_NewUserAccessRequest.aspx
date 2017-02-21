<%@ Page Title="" Language="C#" MasterPageFile="~/SafetyTrainingNewUserAccessRequest.master" AutoEventWireup="true" CodeFile="SafetyTraining_NewUserAccessRequest.aspx.cs" Inherits="UserAccessRequest_SafetyTraining_NewUserAccessRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Date_Validation.js"></script>

    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
   
        <div runat="server" id="DivEditAccessUser">
            <table width="100%" cellpadding="3" cellspacing="1" border="0">
                <tr>
                    <td class="PropertyInfoBG" colspan="6" align="left" style="padding-left: 10px;">New User Access Request
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="padding-left: 10px; padding-right: 30px;">
                        <h5 style="font-weight: normal;">For access to Sonic/EchoPark Safety Training, and in order to receive proper credit for taking the training, please complete ALL of the fields below as accurately as possible:</h5>
                    </td>
                </tr>

                <tr>
                    <td align="left" style="padding-left: 10px; font-size: 12px;">First Name&nbsp;<span style="color: Red;">*</span>
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:TextBox runat="server" ID="txtFirstName" MaxLength="50" Width="170px" AutoComplete="off"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFirstName" ControlToValidate="txtFirstName" Display="None"
                            runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter First Name."  SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </td>
                    <td align="left" style="font-size: 12px;">Last Name&nbsp;<span style="color: Red;">*</span>
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:TextBox runat="server" ID="txtLastName" MaxLength="50" Width="170px" AutoComplete="off"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvLastName" ControlToValidate="txtLastName" Display="None"
                            runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Last Name."  SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="padding-left: 10px; font-size: 12px;">Social Security Number&nbsp;<span style="color: Red;">*</span>
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:TextBox runat="server" ID="txtSocialSecurityNumber" MaxLength="12" Width="170px" AutoComplete="off"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rfvSocialSecurityNumber" ControlToValidate="txtSocialSecurityNumber"
                            runat="server" ErrorMessage="Please Enter Social Security Number." Display="none" SetFocusOnError="true"></asp:RegularExpressionValidator>
                    </td>
                    <td align="left" style="font-size: 12px;">E-Mail Address&nbsp;<span style="color: Red;">*</span>
                    </td>
                    <td align="center">:
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtEmail" MaxLength="65" Width="170px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtEmail" ControlToValidate="txtEmail" Display="None"
                            runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter E-Mail Address."></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                            ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="E-mail Address Is Invalid."
                            SetFocusOnError="True" Text="*" ToolTip="E-mail Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="padding-left: 10px; font-size: 12px;">Location&nbsp;<span style="color: Red;">*</span>
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:DropDownList runat="server" ID="ddlLocation" AutoPostBack="false" Style="width: 175px;"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvLocation" runat="server" InitialValue="0" ValidationGroup="vsErrorGroup"
                            ErrorMessage="Please Select Location" Display="None" ControlToValidate="ddlLocation"
                            SetFocusOnError="true" />
                    </td>
                    <td align="left" style="font-size: 12px;">Department&nbsp;<span style="color: Red;">*</span>
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:DropDownList runat="server" ID="ddlDepartment" AutoPostBack="false" Style="width: 175px;"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvDepartment" runat="server" InitialValue="0" ValidationGroup="vsErrorGroup"
                            ErrorMessage="Please Select Department" Display="None" ControlToValidate="ddlDepartment"
                            SetFocusOnError="true" />
                    </td>
                </tr>
                <tr>
                    <td align="left" style="padding-left: 10px; font-size: 12px;">Job Title&nbsp;<span style="color: Red;">*</span>
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:DropDownList runat="server" ID="ddlJobTitle" AutoPostBack="false" Style="width: 175px;"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvJobTitle" runat="server" InitialValue="0" ValidationGroup="vsErrorGroup"
                            ErrorMessage="Please Select Job Title" Display="None" ControlToValidate="ddlJobTitle"
                            SetFocusOnError="true" />
                    </td>
                    <td align="left" style="font-size: 12px;">Date of Hire &nbsp;<span style="color: Red;">*</span></td>
                    <td align="center">:</td>
                    <td align="left">
                        <asp:TextBox ID="txtCurrentDate" runat="server" Style="display: none"></asp:TextBox>
                        <asp:TextBox ID="txtDateOfHire" runat="server" Width="170px" SkinID="txtDate" MaxLength="10"></asp:TextBox>
                        <img alt="Date of Hire" onclick="return showCalendar('<%= txtDateOfHire.ClientID %>', 'mm/dd/y');"
                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                            align="middle" id="img0" /><br />
                        <asp:RequiredFieldValidator ID="rfvDateOfHire" runat="server" ControlToValidate="txtDateOfHire"
                            Display="None" ErrorMessage="Please select Date Of Hire." ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rfvLast_Date_of_Hire" runat="server" ControlToValidate="txtDateOfHire" ValidationGroup="vsErrorGroup"
                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                            ErrorMessage="Date of Hire is Not Valid Date." Display="none" SetFocusOnError="true">
                        </asp:RegularExpressionValidator>
                       <asp:CompareValidator ID="CurrentFromDateCompare" runat="server" ControlToValidate="txtDateOfHire"
                            ControlToCompare="txtCurrentDate" Operator="LessThan" Type="Date" Display="None" ErrorMessage="Date of Hire should less than Current Date."
                            SetFocusOnError="true" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <table width="100%" cellpadding="3" cellspacing="1" border="0">
                <tr>
                    <td align="center">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td align="center">&nbsp;<asp:Label runat="server" ID="Label1" CssClass="error" EnableViewState="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnSave" runat="server" Text=" Save " CausesValidation="true" ValidationGroup="vsErrorGroup" OnClick="btnSave_Click" />
                                    &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false" OnClick="btnCancel_Click" />
                                    &nbsp;&nbsp;&nbsp;
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div runat="server" id="DivViewAccessUser">
            <table width="100%" cellpadding="3" cellspacing="1" border="0">
                <tr>
                    <td class="PropertyInfoBG" colspan="6" align="left">New User Access Request
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" style="padding-left: 10px; font-size: 12px;">First Name
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:Label runat="server" ID="lblFirstName"></asp:Label>
                    </td>
                    <td align="left" style="font-size: 12px;">Last Name
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:Label runat="server" ID="lblLastName"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="padding-left: 10px; font-size: 12px;">Social Security Number
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:Label runat="server" ID="lblSocialSecurityNumber"></asp:Label>
                    </td>
                    <td align="left" style="font-size: 12px;">E-Mail Address
                    </td>
                    <td align="center">:
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblEmail"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="padding-left: 10px; font-size: 12px;">Location</td>
                    <td align="center">:</td>
                    <td>
                        <asp:Label runat="server" ID="lblLocation"></asp:Label>
                        <asp:HiddenField runat="server" ID="hdnLocationID" />
                    </td>
                    <td align="left" style="font-size: 12px;">Department 
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:Label runat="server" ID="lblDepartment"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="padding-left: 10px; font-size: 12px;">Job Title 
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:Label runat="server" ID="lblJobTitle"></asp:Label>
                    </td>
                    <td align="left" style="font-size: 12px;">Date of Hire 
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:Label runat="server" ID="lblDateOfHire" Width="135px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <table width="100%" cellpadding="3" cellspacing="1" border="0">
                <tr>
                    <td align="center">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td align="center">&nbsp;<asp:Label runat="server" ID="Label2" CssClass="error" EnableViewState="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnEdit" runat="server" Text=" Edit " CausesValidation="true" ValidationGroup="vsErrorGroup" OnClick="btnEdit_Click" OnClientClick=""/>
                                    &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CausesValidation="false" OnClick="btnSubmit_Click" />
                                    &nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
</asp:Content>

