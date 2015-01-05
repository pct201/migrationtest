<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="security.aspx.cs"
    Inherits="Administrator_security" Title="eRIMS Sonic :: Security" MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
     <script type="text/javascript" language="javascript" src="../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery.maskedinput.js"></script>
    <script type="text/javascript">
        var GB_ROOT_DIR = '<%=AppConfig.SiteURL%>' + 'greybox/';
        function OpenAssociateName() {
            GB_showCenter('Associate Name', '<%=AppConfig.SiteURL%>SONIC/FirstReport/AssociateNamePopup.aspx', 500, 500, '');
        }
        function OPenChangePasswordPopup() {
            GB_showCenter('Associate Name', '<%=AppConfig.SiteURL%>Administrator/ChangePassword_Popup.aspx?UserName=' + document.getElementById('<%=txtUserID.ClientID %>').value + '&id=0&UID=' + document.getElementById('<%=hdnPKUserID.ClientID %>').value, 500, 500, '');
        }
        function AssignValue(EmpName, EmpID) {
            document.getElementById('<%=lnkAssName.ClientID%>').innerText = EmpName;
            document.getElementById('hdnEmpval').value = EmpID;
            document.getElementById('<%=HdnEmployeeID.ClientID %>').value = EmpID;
            document.getElementById('<%=HdnEmployeeName.ClientID %>').value = EmpName;
        }
        jQuery(function ($) {
            $("#<%=txtPhone.ClientID%>").mask("999-999-9999");
        });
    </script>
    <link href="<%=AppConfig.SiteURL%>greybox/gb_styles.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/gb_scripts.js"></script>
    <script language="javascript" type="text/javascript">
        function CheckVal() {
            if (document.getElementById('<%=txtPhone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtPhone.ClientID%>').value = "";

            ctl = document.getElementById('<%=rdoIsSonicEmployee.ClientID %>');
            rdo = document.getElementById(ctl.id + "_0");
            //check if Is employee is true than only check employee is selected or not.
            if (rdo.checked == true) {
                //check Employee is selected or not.        
                if (document.getElementById('<%=HdnEmployeeID.ClientID %>').value == "") {
                    alert('Please select Employee.');
                    return false;
                }
            }
            if (Page_ClientValidate()) {
                return true;
            }
            else
                return false;
        }
        function CheckEmployee() {

            ctl = document.getElementById('<%=rdoIsSonicEmployee.ClientID %>');
            ctlRegion = document.getElementById('<%=rdoIsRegionalOfficer.ClientID %>');
            rdo = document.getElementById(ctl.id + "_0");
            rdoRegion = document.getElementById(ctlRegion.id + "_0");

            var IsRegional = '<%=clsSession.IsUserRegionalOfficer%>';
            var UserID = '<%=clsSession.UserID%>';
            var PK = '<%=PK_Security_ID %>';
            if (IsRegional == "True" && UserID != PK) {
                document.getElementById('<%=tdEmployee.ClientID %>').style.display = "";
                document.getElementById('<%=tdRigionalOfficer.ClientID %>').style.display = "";
                document.getElementById('<%=tdRegion.ClientID %>').style.display = "";
                //document.getElementById('<%=trReportType.ClientID %>').style.display = "none";
                document.getElementById('<%=rfvRegion.ClientID %>').enabled = true;
                if (rdo.checked == true) {
                    document.getElementById('<%=tdEmployee.ClientID %>').style.display = "";
                }
                else {
                    document.getElementById('<%=tdEmployee.ClientID %>').style.display = "none";
                    document.getElementById('<%=HdnEmployeeID.ClientID %>').value = "";
                    document.getElementById('<%=HdnEmployeeName.ClientID %>').value = "";
                    document.getElementById('<%=lnkAssName.ClientID%>').innerText = "Associate Name";
                    document.getElementById('hdnEmpval').value = "";
                }
            }
            else {
                if (rdo.checked == true) {
                    document.getElementById('<%=tdEmployee.ClientID %>').style.display = "";
                    document.getElementById('<%=tdRigionalOfficer.ClientID %>').style.display = "";
                    document.getElementById('<%=tdRegion.ClientID %>').style.display = "";
                    document.getElementById('<%=revIsRegionalOfficer.ClientID %>').enabled = true;
                    checkIsRegion();
                }
                else {
                    document.getElementById('<%=tdEmployee.ClientID %>').style.display = "none";
                    document.getElementById('<%=HdnEmployeeID.ClientID %>').value = "";
                    document.getElementById('<%=HdnEmployeeName.ClientID %>').value = "";
                    document.getElementById('<%=lnkAssName.ClientID%>').innerText = "Associate Name";
                    document.getElementById('hdnEmpval').value = "";
                    document.getElementById('<%=tdRigionalOfficer.ClientID %>').style.display = "none";

                    //document.getElementById('<%=tdRegion.ClientID %>').style.display="none";
                    document.getElementById('<%=revIsRegionalOfficer.ClientID %>').enabled = false;
                    //document.getElementById('ctl00_ContentPlaceHolder1_trReportType').style.display = "none";
                    //checkIsRegion();
                }
            }

        }
        function checkIsRegion() {
            ctl = document.getElementById('<%=rdoIsRegionalOfficer.ClientID %>');
            rdo = document.getElementById(ctl.id + "_0");

            if (rdo.checked == true) {
                //document.getElementById('<%=tdEmployee.ClientID %>').style.display="none";
                //document.getElementById('<%=tdRegion.ClientID %>').style.display="block";
                document.getElementById('<%=rfvRegion.ClientID %>').enabled = true;
                document.getElementById('<%=trReportType.ClientID %>').style.display = "";
            }
            else {
                //document.getElementById('<%=tdRegion.ClientID %>').style.display="none";
                document.getElementById('<%=rfvRegion.ClientID %>').enabled = false;
                //document.getElementById('<%=trReportType.ClientID %>').style.display = "none";
            }
        }

        //Functions for Mover control - FROI E-Mail Recipients
        function CheckListItemLocation() {
            var lstLocation = document.getElementById('<%=lstFROIeMailRecipients.ClientID %>');

            if (lstLocation.length <= 0) {
                alert('No record!');
                return false;
            }
            if (lstLocation.selectedIndex < 0) {
                alert('Please select at least one Locations field(s)');
                return false;
            }
        }
        function CheckACIListItemLocation() {
            var lstLocation = document.getElementById('<%=lstSecurityLocation.ClientID %>');

            if (lstLocation.length <= 0) {
                alert('No record!');
                return false;
            }
            if (lstLocation.selectedIndex < 0) {
                alert('Please select at least one ACI Locations field(s)');
                return false;
            }
        }

        function CheckListItemSelected() {
            var lstSelected = document.getElementById('<%=lstSelectedFields.ClientID %>');
            if (lstSelected.length <= 0) {
                alert('No records');
                return false;
            }
            if (lstSelected.selectedIndex < 0) {
                alert('Please select at least one Locations field(s)');
                return false;
            }
        }


        function CheckACIListItemSelected() {
            var lstSelected = document.getElementById('<%=lstSecuritySelectedLocation.ClientID %>');
             if (lstSelected.length <= 0) {
                 alert('No records');
                 return false;
             }
             if (lstSelected.selectedIndex < 0) {
                 alert('Please select at least one ACI Locations field(s)');
                 return false;
             }
        }

        function CheckListItemSelectedAll() {
            var lstSelected = document.getElementById('<%=lstSelectedFields.ClientID %>');
            if (lstSelected.length <= 0)
            { alert('No records'); return false; }
        }

        function CheckACIListItemSelectedAll() {
            var lstSelected = document.getElementById('<%=lstSecuritySelectedLocation.ClientID %>');
            if (lstSelected.length <= 0)
            { alert('No records'); return false; }
        }

        function CheckLocationField(source, arguments) {
            var lstSelected = document.getElementById('<%=lstSelectedFields.ClientID %>');
            if (lstSelected.length <= 0) {
                arguments.IsValid = false;
                return arguments.IsValid;
            }
            else {
                arguments.IsValid = true;
                return arguments.IsValid;
            }
        }
    </script>
    <script type="text/javascript" src="../JavaScript/JFunctions.js">
    </script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>
    <br />
    <asp:HiddenField ID="hdnMode" runat="server" Value="0"></asp:HiddenField>
    <div runat="Server" id="divViewAdminList">
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td class="bandHeaderRow" colspan="4" align="left">
                    Security
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;<asp:HiddenField runat="server" ID="HdnEmployeeID" />
                    <asp:HiddenField runat="server" ID="HdnEmployeeName" />
                    <input type="hidden" id="hdnEmpval" name="hdnEmpval" />
                    <input type="hidden" id="hdnEmpName" name="hdnEmpName" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td style="width: 70%" align="right">
                                Search by User Name
                            </td>
                            <td style="width: 5%">
                                &nbsp;
                            </td>
                            <td style="width: 12%" align="right">
                                <asp:TextBox ID="txtSearch" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 5px">
                </td>
            </tr>
            <tr>
                <td style="width: 44%">
                    &nbsp;
                </td>
                <td align="right" valign="top" colspan="3">
                    <uc:ctrlPaging ID="ctrlPageProperty" runat="server" OnGetPage="GetPage" />
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 5px">
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <table cellpadding="0" cellspacing="0" border="0" style="text-align: right; width: 100%;">
                        <tr>
                            <td>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Click here to delete Diary Details"
                                    OnClick="btnDelete_Click" />
                                <asp:Button ID="btnAddNew" runat="server" Text="Add New" ToolTip="Add new Diary Details"
                                    OnClick="btnAddNew_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 5px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">
                                <asp:GridView ID="gvSecurity" runat="server" AutoGenerateColumns="false" DataKeyNames="PK_Security_ID"
                                    Width="100%" OnRowCreated="gvSecurity_RowCreated" OnSorting="gvSecurity_Sorting"
                                    AllowSorting="True" OnRowCommand="gvSecurity_RowCommand" OnRowDataBound="gvSecurity_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemStyle Width="5%" />
                                            <ItemTemplate>
                                                <input name="chkItem" type="checkbox" value='<%# Eval("PK_Security_ID")%>' onclick="javascript:UnCheckHeader('gvSecurity')" />
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <input type="checkbox" name="chkHeader" id="chkHeader" runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                                            </HeaderTemplate>
                                            <HeaderStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="User Name" SortExpression="USER_NAME">
                                            <ItemStyle Width="35%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblUserName" runat="server" Text='<%# Eval("USER_NAME")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="First Name" SortExpression="FIRST_NAME">
                                            <ItemStyle Width="25%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblFirstName" runat="server" Text='<%# Eval("FIRST_NAME")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Last Name" SortExpression="LAST_NAME">
                                            <ItemStyle Width="25%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblLastName" runat="server" Text='<%# Eval("LAST_NAME")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Admin Access" SortExpression="USER_ROLE">
                                            <ItemStyle Width="25%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblUserRole" runat="server" Text='<%# Eval("USER_ROLE")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemStyle Width="15%" />
                                            <ItemTemplate>
                                                <asp:Button ID="btnEdit" CommandName="EditItem" CommandArgument='<%#Eval("PK_Security_ID")%>'
                                                    runat="server" Text="Edit" ToolTip="Edit the Security Details" />
                                            </ItemTemplate>
                                            <ItemStyle Horizontalalign="center" Width="60px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%#Eval("PK_Security_ID")%>'
                                                    ToolTip="View the Security Details" />
                                            </ItemTemplate>
                                            <ItemStyle Horizontalalign="center" Width="60px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataRowStyle ForeColor="#7f7f7f" Horizontalalign="center" />
                                    <EmptyDataTemplate>
                                        No Record found.
                                    </EmptyDataTemplate>
                                    <PagerSettings Visible="False" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div runat="server" id="divModifyAdmin" style="display: none;">
        <div runat="server" id="DivEditSecuirty">
            <table width="100%" cellpadding="3" cellspacing="1" border="0">
                <tr>
                    <td class="bandHeaderRow" colspan="6" align="left">
                        Security
                    </td>
                </tr>
                <tr>
                    <td style="width: 18%;" align="left">
                        User ID<span style="color: Red;">*</span>
                    </td>
                    <td style="width: 4%;" align="center">
                        :
                    </td>
                    <td align="left" width="26%">
                        <asp:TextBox runat="server" ID="txtUserID" MaxLength="65" ValidationGroup="vsErrorGroup"
                            Width="170px"></asp:TextBox>&nbsp;
                        <asp:HiddenField runat="server" ID="hdnPKUserID" />
                        <asp:RequiredFieldValidator ID="rfvUserID" ControlToValidate="txtUserID" Display="None"
                            runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter User ID."></asp:RequiredFieldValidator>
                    </td>
                    <td align="left" width="12%">
                        &nbsp;
                    </td>
                    <td align="center" width="4%">
                        &nbsp;
                    </td>
                    <td width="36%">
                        <a href="#" onclick="OPenChangePasswordPopup();" id="PopupPassword" runat="Server"
                            style="display: none;">Change Password</a>
                    </td>
                </tr>
                <tr runat="server" id="trPassword">
                    <td align="left" >
                        Password<span style="color: Red;">*</span>
                    </td>
                    <td align="center" >
                        :
                    </td>
                    <td align="left" >
                        <asp:TextBox runat="server" ID="txtPassword" MaxLength="15" ValidationGroup="vsErrorGroup"
                            Width="170px" TextMode="Password"></asp:TextBox>&nbsp;
                        <asp:RequiredFieldValidator ID="rfvPassword" ControlToValidate="txtPassword" Display="None"
                            runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Password."></asp:RequiredFieldValidator>
                    </td>
                    <td align="left" >
                        Confirm Password<span style="color: Red;">*</span>
                    </td>
                    <td align="center" >
                        :
                    </td>
                    <td align="left" >
                        <asp:TextBox runat="server" ID="txtConfirmPassword" MaxLength="15" ValidationGroup="vsErrorGroup"
                            Width="170px" TextMode="Password"></asp:TextBox>&nbsp;
                        <asp:RequiredFieldValidator ID="rfvConfirmPassword" ControlToValidate="txtConfirmPassword"
                            Display="None" runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup"
                            ErrorMessage="Please Enter Confirm Password."></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cmpPWD" runat="server" ControlToValidate="txtConfirmPassword"
                            ValidationGroup="vsErrorGroup" ErrorMessage="Password and Confirm Password should be same."
                            Type="String" Operator="Equal" Text="*" ControlToCompare="txtPassword" Display="none">
                        </asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        First Name<span style="color: Red;">*</span>
                    </td>
                    <td align="center" >
                        :
                    </td>
                    <td align="left" >
                        <asp:TextBox runat="server" ID="txtFirstName" MaxLength="20" Width="170px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFirstName" ControlToValidate="txtFirstName" Display="None"
                            runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter First Name."></asp:RequiredFieldValidator>
                    </td>
                    <td align="left" >
                        Last Name<span style="color: Red;">*</span>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td align="left" >
                        <asp:TextBox runat="server" ID="txtLastName" MaxLength="20" Width="170px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvLastName" ControlToValidate="txtLastName" Display="None"
                            runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Last Name."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Admin Access<span style="color: Red;">*</span>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td align="left">
                        <asp:RadioButtonList runat="Server" ID="rdoAdminRole" SkinID="YesNoType">
                        </asp:RadioButtonList>
                    </td>
                    <td colspan="3" align="left">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%"  id="tdRigionalOfficer" runat="server" style="display: none;">
                            <tr style="width:100%">
                                <td width="22%" align="left">
                                    Is Regional Officer<span style="color: red">*</span>
                                </td>
                                <td width="9%" align="center">
                                    :
                                </td>
                                <td>
                                    <asp:RadioButtonList runat="Server" ID="rdoIsRegionalOfficer" onClick="checkIsRegion();"
                                        SkinID="YesNoTypeNullSelection">
                                    </asp:RadioButtonList>
                                    <asp:RequiredFieldValidator ID="revIsRegionalOfficer" runat="server" ValidationGroup="vsErrorGroup"
                                        ErrorMessage="Please check Is Regional Officer?" Text="*" Display="none" Enabled="false"
                                        ControlToValidate="rdoIsRegionalOfficer"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Email<span style="color: Red;">*</span>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtEmail" MaxLength="65" Width="170px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" ControlToValidate="txtEmail" Display="None"
                            runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Email."></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                            ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="Email Address Is Invalid."
                            SetFocusOnError="True" Text="*" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                    </td>
                    <td align="left">
                        Is Sonic Employee?<span style="color: red">*</span>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td>
                        <asp:RadioButtonList runat="server" ID="rdoIsSonicEmployee" onClick="CheckEmployee();"
                            AutoPostBack="true" SkinID="YesNoTypeNullSelection" OnSelectedIndexChanged="rdoIsSonicEmployee_OnSelectedIndexChanged">
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="rfvIsSonicEmployee" runat="server" ValidationGroup="vsErrorGroup"
                            ErrorMessage="Please check Is Sonic Employee?" Text="*" Display="none" ControlToValidate="rdoIsSonicEmployee"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr valign="top">
                    <td align="left">
                        Phone<br />
                        (xxx-xxx-xxxx)
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td align="left">
                        <asp:TextBox runat="Server" ID="txtPhone" Width="170px" MaxLength="12"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revPhone" ControlToValidate="txtPhone" runat="server"
                            ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Phone Number in xxx-xxx-xxxx format."
                            Display="none" Text="*" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                    </td>
                    <td colspan="3">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%" id="tdEmployee" runat="server">
                            <tr>
                                <td style="width: 22%" align="left">
                                    Employee<span style="color: red">*</span>
                                </td>
                                <td style="width: 9%" align="center">
                                    :
                                </td>
                                <td>
                                    <a href="#" id="lnkAssName" onclick="OpenAssociateName();" runat="server">Associate
                                        Name</a>
                                    <asp:Button ID="btnAssName" OnClick="btnAssName_OnClick" runat="server" Style="display: none;" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top">
                        Corporate User
                    </td>
                    <td align="center" valign="top">
                        :
                    </td>
                    <td align="left" valign="top">
                        <asp:RadioButtonList runat="Server" ID="rdCorporateUser" SkinID="YesNoType">
                        </asp:RadioButtonList>
                    </td>
                    <td colspan="3">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%" id="tdRegion" runat="server" style="display: none;">
                            <tr>
                                <td style="width: 22%" align="left" valign="top">
                                    Region
                                </td>
                                <td style="width: 9%" align="center" valign="top">
                                    :
                                </td>
                                <td valign="top">
                                    <asp:ListBox runat="server" ID="lstRegion" SelectionMode="Multiple"></asp:ListBox>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvRegion" ControlToValidate="lstRegion"
                                        ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="Please select at least one Region."
                                        Enabled="false"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="trReportType" runat="server">
                                <td align="left" valign="top">
                                    Report Type
                                </td>
                                <td align="center" valign="top">
                                    :
                                </td>
                                <td valign="top">
                                    <asp:ListBox runat="server" ID="lstReportType" SelectionMode="Multiple">
                                        <asp:ListItem Value="WC">Worker's Compensation</asp:ListItem>
                                        <asp:ListItem Value="AL">Auto Liability</asp:ListItem>
                                        <asp:ListItem Value="DPD">Dealer Physical Damage</asp:ListItem>
                                        <asp:ListItem Value="Property">Property</asp:ListItem>
                                        <asp:ListItem Value="PL">Premises Liability</asp:ListItem>
                                    </asp:ListBox>
                                    <%--<asp:RequiredFieldValidator runat="server" ID="rfvReportType" ControlToValidate="lstReportType"
                                         ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="Please select at least one Report Type." Enabled="false"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td style="width: 33%;">
                                    Groups
                                </td>
                                <td style="width: 33%;">
                                    Inherited Rights
                                </td>
                                <td style="width: 33%;">
                                    Additional Rights
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:UpdatePanel runat="server" ID="updGroup">
                                        <ContentTemplate>
                                            <asp:CheckBoxList runat="server" ID="chkGroup" RepeatColumns="2" RepeatDirection="Vertical"
                                                AutoPostBack="true" OnSelectedIndexChanged="chkGroup_SelectedIndexChanged">
                                            </asp:CheckBoxList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td valign="top">
                                    <asp:UpdatePanel runat="server" ID="udpInRights" UpdateMode="conditional">
                                        <ContentTemplate>
                                            <asp:ListBox runat="server" ID="lstInheritedRights" Width="150px"></asp:ListBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="chkGroup" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                                <td valign="top">
                                    <asp:UpdatePanel runat="server" ID="updRight" UpdateMode="Always">
                                        <ContentTemplate>
                                            <asp:CheckBoxList runat="server" ID="chkRights" RepeatColumns="2" RepeatDirection="Horizontal" OnSelectedIndexChanged="chkRights_SelectedIndexChanged" AutoPostBack="true"  >
                                            </asp:CheckBoxList>
                                        </ContentTemplate> 
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="chkRights"/>
                                        </Triggers>                                        
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <table width="100%" cellpadding="2" cellspacing="2">
                            <tr valign="top">
                                <td style="width: 16%">
                                    FROI E-Mail Recipients
                                </td>
                                <td style="width: 2%;" align="center">
                                    :
                                </td>
                                <td style="width: 72%">
                                    <table width="100%">
                                        <tr>
                                            <td align="left" style="width: 250px">
                                                Locations Available
                                                <asp:ListBox ID="lstFROIeMailRecipients" runat="server" Rows="10" SelectionMode="Multiple"
                                                    Width="250px"></asp:ListBox>
                                            </td>
                                            <td valign="middle" align="center" style="width: 125px">
                                                <table width="100%">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Button ID="btnSelectFields" runat="server" Text=">" Width="50px" OnClick="btnSelectFields_Click"
                                                                Enabled="false" OnClientClick="javascript:return CheckListItemLocation();" ValidationGroup="vsErrorAvailFieldss" />
                                                            <br />
                                                            <br />
                                                            <asp:Button ID="btnSelectAllFields" runat="server" Text=">>" Width="50px" Enabled="false"
                                                                OnClick="btnSelectAllFields_Click" />
                                                            <br />
                                                            <br />
                                                            <asp:Button ID="btnDeselectFields" runat="server" Text="<" Width="50px" OnClick="btnDeselectFields_Click"
                                                                Enabled="false" OnClientClick="javascript:return CheckListItemSelected();" ValidationGroup="vsErrorSelectFieldss" />
                                                            <br />
                                                            <br />
                                                            <asp:Button ID="btnDeselectAllFields" runat="server" Text="<<" Width="50px" OnClientClick="javascript:return CheckListItemSelectedAll();"
                                                                Enabled="false" OnClick="btnDeselectAllFields_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td align="left">
                                                Locations Selected<br />
                                                <asp:ListBox ID="lstSelectedFields" runat="server" Rows="10" SelectionMode="Multiple"
                                                    Width="250px"></asp:ListBox>
                                                <%--<asp:ImageButton ID="imgUp" ImageUrl="~/Images/up-arrow.gif" runat="server" ImageAlign="top"
                                                    OnClientClick="javascript:return CheckListItemSelected();" OnClick="imgUp_Click" />
                                                <asp:ImageButton ID="imgDown" ImageUrl="~/Images/down-arrow.gif" runat="server" ImageAlign="top"
                                                    OnClientClick="javascript:return CheckListItemSelected();" OnClick="imgDown_Click" />
                                                <asp:CustomValidator ID="cstvlCompany" runat="server" ErrorMessage="Please Select at least one Location field"
                                                    Display="None" ValidationGroup="vsErrorGroup" ClientValidationFunction="CheckLocationField"></asp:CustomValidator>--%>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <table width="100%" cellpadding="2" cellspacing="2">
                            <tr valign="top">
                                <td style="width: 16%">
                                    ACI Location Selection
                                </td>
                                <td style="width: 2%;" align="center">
                                    :
                                </td>
                                <td style="width: 72%">
                                    <table width="100%">
                                        <tr>
                                            <td align="left" style="width: 250px">
                                                Locations Available
                                                <asp:ListBox ID="lstSecurityLocation" runat="server" Rows="10" SelectionMode="Multiple"
                                                    Width="250px"></asp:ListBox>
                                            </td>
                                            <td valign="middle" align="center" style="width: 125px">
                                                <table width="100%">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Button ID="btnSelectLocationFields" runat="server" Text=">" Width="50px" OnClick="btnSelectLocationFields_Click"  OnClientClick="javascript:return CheckACIListItemLocation();"
                                                                Enabled="false"  ValidationGroup="vsErrorAvailFieldss" />
                                                            <br />
                                                            <br />
                                                            <asp:Button ID="btnSelectAllLocationFields" runat="server" Text=">>" Width="50px" Enabled="false"
                                                                OnClick="btnSelectAllLocationFields_Click" />
                                                            <br />
                                                            <br />
                                                            <asp:Button ID="btnDeSelectLocationFields" runat="server" Text="<" Width="50px" OnClick="btnDeSelectLocationFields_Click" OnClientClick="javascript:return CheckACIListItemSelected();"
                                                                Enabled="false"  ValidationGroup="vsErrorSelectFieldss" />
                                                            <br />
                                                            <br />
                                                            <asp:Button ID="btnDeSelectAllLocationFields" runat="server" Text="<<" Width="50px" OnClientClick="javascript:return CheckACIListItemSelectedAll();"
                                                                Enabled="false" OnClick="btnDeSelectAllLocationFields_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td align="left">
                                                Locations Selected<br />
                                                <asp:ListBox ID="lstSecuritySelectedLocation" runat="server" Rows="10" SelectionMode="Multiple"
                                                    Width="250px"></asp:ListBox>                                                
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                 
            </table>
        </div>
        <div runat="server" id="DivViewSecurity">
            <table width="100%" cellpadding="3" cellspacing="1" border="0">
                <tr>
                    <td class="bandHeaderRow" colspan="6" align="left">
                        Security
                    </td>
                </tr>
                <tr>
                    <td style="width: 18%;" align="left">
                        User ID
                    </td>
                    <td style="width: 4%;" align="center">
                        :
                    </td>
                    <td colspan="4" align="left">
                        <asp:Label runat="server" ID="lblUserID"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="width: 18%;">
                        First Name
                    </td>
                    <td align="center" style="width: 4%;">
                        :
                    </td>
                    <td align="left" style="width: 28%;">
                        <asp:Label runat="server" ID="lblFirstName"></asp:Label>
                    </td>
                    <td align="left" style="width: 18%;">
                        Last Name
                    </td>
                    <td align="center" style="width: 4%;">
                        :
                    </td>
                    <td align="left" style="width: 28%;">
                        <asp:Label runat="server" ID="lblLastName"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Admin Role
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td align="left">
                        <asp:Label runat="server" ID="lblUserRole">
                        </asp:Label>
                    </td>
                    <td colspan="3" >
                        <table cellpadding="0" cellspacing="0" border="0" width="100%" id="tdRigionalOfficerView" runat="server" style="display: none;">
                            <tr>
                                <td style="width: 35%" align="left">
                                    Is Regional Officer
                                </td>
                                <td style="width: 10%" align="center">
                                    :
                                </td>
                                <td >
                                    <asp:Label runat="server" ID="lblIsRegionalOfficer"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Email
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblEmail"></asp:Label>
                    </td>
                    <td align="left">
                        Is Sonic Employee?
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td>
                        <asp:Label ID="lblIsSonicEmployee" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr valign="top">
                    <td align="left">
                        Phone<br />
                        (xxx-xxx-xxxx)
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td align="left">
                        <asp:Label runat="Server" ID="lblPhone"></asp:Label>
                    </td>
                    <td colspan="3" id="tdEmployeeView" runat="server" style="display: none;">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td style="width: 35%" align="left">
                                    Employee
                                </td>
                                <td style="width: 10%" align="center">
                                    :
                                </td>
                                <td >
                                    <asp:Label runat="server" ID="lblEmployee"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr valign="top">
                    <td align="left" valign="top">
                        Corporate User
                    </td>
                    <td align="center" valign="top">
                        :
                    </td>
                    <td align="left" valign="top">
                        <asp:Label runat="server" ID="lblCorporateUser"></asp:Label>
                    </td>
                    <td colspan="3" id="tdRegionView" runat="server" style="display: none;">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td style="width: 35%" align="left">
                                    Region
                                </td>
                                <td style="width: 10%" align="center">
                                    :
                                </td>
                                <td colspan="4">
                                    <asp:Label runat="server" ID="lblRegion"></asp:Label>
                                </td>
                            </tr>
                            <tr id="trReportTypeView" runat="server">
                                <td align="left">
                                    Report Type
                                </td>
                                <td align="center">
                                    :
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblReportType"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td style="width: 33%;">
                                    Groups
                                </td>
                                <td style="width: 33%;">
                                    Inherited Rights
                                </td>
                                <td style="width: 33%;">
                                    Additional Rights
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:UpdatePanel runat="server" ID="updGroupView">
                                        <ContentTemplate>
                                            <asp:CheckBoxList runat="server" ID="chkGroupView" RepeatColumns="2" RepeatDirection="Vertical">
                                            </asp:CheckBoxList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td valign="top">
                                    <asp:UpdatePanel runat="server" ID="udpInRightsView" UpdateMode="conditional">
                                        <ContentTemplate>
                                            <asp:ListBox runat="server" ID="lstInheritedRightsView" Width="150px"></asp:ListBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td valign="top">
                                    <asp:UpdatePanel runat="server" ID="updRightView" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:CheckBoxList runat="server" ID="chkRightsView" RepeatColumns="2" RepeatDirection="Horizontal">
                                            </asp:CheckBoxList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <table width="100%" cellpadding="2" cellspacing="2">
                            <tr valign="top">
                                <td style="width: 16%">
                                    FROI E-Mail Recipients (Locations Selected)
                                </td>
                                <td style="width: 2%;" align="center">
                                    :
                                </td>
                                <td style="width: 82%">
                                    <asp:ListBox ID="lstSelectedFieldsView" runat="server" Rows="10" SelectionMode="Single"
                                        Width="250px"></asp:ListBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                 <tr>
                    <td colspan="6">
                        <table width="100%" cellpadding="2" cellspacing="2">
                            <tr valign="top">
                                <td style="width: 16%">
                                    ACI Location Selection (Locations Selected)
                                </td>
                                <td style="width: 2%;" align="center">
                                    :
                                </td>
                                <td style="width: 82%">
                                    <asp:ListBox ID="lstSelectedLocationView" runat="server" Rows="10" SelectionMode="Single"
                                        Width="250px"></asp:ListBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
               
            </table>
        </div>
        <br />
         <asp:UpdatePanel runat="server" ID="UpdatePanel2">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="100%">
                            <table cellpadding="3" cellspacing="0" width="100%" id="tblDocumentFolder" runat="server">
                                <tr>
                                    <td style="width: 12%; padding-left: 10px" align="left" valign="top">
                                        Document Folder Security
                                    </td>
                                    <td style="width: 4%" align="center" valign="top">
                                        :
                                    </td>
                                    <td colspan="4" align="left" width="34%">
                                        <asp:ListBox ID="lstFolderSecurity" runat="server" SelectionMode="Multiple" Width="280px"
                                            Height="130px"></asp:ListBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />

        <table width="100%" cellpadding="3" cellspacing="1" border="0">
            <tr>
                <td align="center">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td align="center">
                                &nbsp;<asp:Label runat="server" ID="lblError" CssClass="error" EnableViewState="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnSave" runat="server" Text=" Save " CausesValidation="true" ValidationGroup="vsErrorGroup"
                                    OnClick="btnSave_Click" OnClientClick="return CheckVal();" />&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false"
                                    OnClick="btnCancel_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
