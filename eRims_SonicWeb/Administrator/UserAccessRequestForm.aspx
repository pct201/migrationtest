<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="UserAccessRequestForm.aspx.cs" Inherits="UserAccessRequestForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/NotesWithSpellCheck/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <script type="text/javascript" src="../JavaScript/JFunctions.js">
    </script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery.maskedinput.js"></script>
    <script type="text/javascript">
        var GB_ROOT_DIR = '<%=AppConfig.SiteURL%>' + 'greybox/';

        function OpenAssociateName() {
            GB_showCenter('Associate Name', '<%=AppConfig.SiteURL%>SONIC/FirstReport/AssociateNamePopup.aspx', 500, 500, '');
        }

        function AssignValue(EmpName, EmpID) {
            document.getElementById('<%=lnkAssName.ClientID%>').innerText = EmpName;
            document.getElementById('hdnEmpval').value = EmpID;
            document.getElementById('<%=HdnEmployeeID.ClientID %>').value = EmpID;
            document.getElementById('<%=HdnEmployeeName.ClientID %>').value = EmpName;
        }


        function CheckListItemLocation() {
            var lstLocation = document.getElementById('<%=lstLocationsAvailable.ClientID %>');

            if (lstLocation.length <= 0) {
                alert('No record!');
                return false;
            }
            if (lstLocation.selectedIndex < 0) {
                alert('Please select at least one Locations field(s)');
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

        function CheckListItemSelectedAll() {
            var lstSelected = document.getElementById('<%=lstSelectedFields.ClientID %>');
            if (lstSelected.length <= 0)
            { alert('No records'); return false; }
        }

        function CheckVal() {            
            if (document.getElementById('<%=txtTelephone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtTelephone.ClientID%>').value = "";

            //ctl = document.getElementById('<=rdoIsSonicEmployee.ClientID %>');
            //rdo = document.getElementById(ctl.id + "_0");
            ////check if Is employee is true than only check employee is selected or not.
            //if (rdo.checked == true) {
            //    //check Employee is selected or not.        
            //    if (document.getElementById('<%=HdnEmployeeID.ClientID %>').value == "") {
            //        alert('Please select Employee.');
            //        return false;
            //    }
            //}
            if (Page_ClientValidate()) {
                return true;
            }
            else
                return false;
        }

    </script>
    <script type="text/javascript">
        jQuery(function ($) {
            $("#<%=txtTelephone.ClientID%>").mask("999-999-9999");         

        });
    </script>

    <link href="<%=AppConfig.SiteURL%>greybox/gb_styles.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/gb_scripts.js"></script>
    <br />
    <asp:HiddenField ID="hdnMode" runat="server" Value="0"></asp:HiddenField>
    <div runat="Server" id="divViewAccessUserList">
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td class="bandHeaderRow" colspan="4" align="left">User Access Request
                </td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;<asp:HiddenField runat="server" ID="HiddenField1" />
                    <asp:HiddenField runat="server" ID="HiddenField2" />
                    <input type="hidden" id="Hidden1" name="hdnEmpval" />
                    <input type="hidden" id="Hidden2" name="hdnEmpName" />
                </td>
            </tr>
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td align="left">
                                <span class="heading">User Access Request Grid</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">&nbsp;
                                        <asp:Label ID="lblNumber" runat="server" Text="0"></asp:Label>&nbsp;records Found
                            </td>
                        </tr>
                    </table>
                </td>
                <td colspan="3">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td style="width: 58%" align="right">Search by Last Name
                            </td>
                            <td style="width: 5%">&nbsp;
                            </td>
                            <td style="width: 12%" align="right">
                                <asp:TextBox ID="txtSearch" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                            &nbsp;&nbsp;&nbsp;
                            <td style="width: 10%" align="center">
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 5px">&nbsp;<asp:HiddenField runat="server" ID="HdnEmployeeID" />
                    <asp:HiddenField runat="server" ID="HdnEmployeeName" />
                    <input type="hidden" id="hdnEmpval" name="hdnEmpval" />
                    <input type="hidden" id="hdnEmpName" name="hdnEmpName" />
                </td>
            </tr>
            <tr>
                <td style="width: 44%">&nbsp;
                </td>
                <td align="right" valign="top" colspan="3">
                    <uc:ctrlPaging ID="ctrlPageProperty" runat="server" OnGetPage="GetPage" />
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 5px"></td>
            </tr>
            <tr>
                <td colspan="4">
                    <table cellpadding="0" cellspacing="0" border="0" style="text-align: right; width: 100%;">
                        <tr>
                            <td>
                                <asp:Button ID="btnAddNew" runat="server" Text="Add New" Visible="false" OnClick="btnAddNew_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 5px;"></td>
                        </tr>
                        <tr>
                            <td style="height: 5px;"></td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">
                                <asp:GridView ID="gvUserAccess" runat="server" AutoGenerateColumns="false" DataKeyNames="PK_U_A_Request"
                                    Width="100%" OnRowCreated="gvUserAccess_RowCreated" OnSorting="gvUserAccess_Sorting" OnRowCommand="gvUserAccess_RowCommand"
                                    OnRowDataBound="gvUserAccess_RowDataBound"
                                    AllowSorting="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="First Name" SortExpression="FIRST_NAME">
                                            <ItemStyle Width="15%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblFirstName" runat="server" Style="word-wrap: normal; word-break: break-all" Text='<%# Eval("FIRST_NAME")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Last Name" SortExpression="LAST_NAME">
                                            <ItemStyle Width="15%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblLastName" runat="server" Text='<%# Eval("LAST_NAME")%>' Style="word-wrap: normal; word-break: break-all"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="State" SortExpression="State">
                                            <ItemStyle Width="12%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblState" runat="server" Text='<%# Eval("State")%>' Style="word-wrap: normal; word-break: break-all"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Dealership" SortExpression="dba">
                                            <ItemStyle Width="30%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblDealership" runat="server" Text='<%# Eval("Dealership")%>' Style="word-wrap: normal; word-break: break-all"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date Request Submitted" SortExpression="S.[Created_Date]" HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblCreated_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Created_Date"))%>' Style="word-wrap: normal; word-break: break-all"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Acccess Granted" SortExpression="[Deny]">
                                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Image ID="imgAccessGranted" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemStyle Width="20%" />
                                            <ItemTemplate>
                                                <asp:Button ID="btnEdit" CommandName="EditItem" CommandArgument='<%#Eval("PK_U_A_Request")%>'
                                                    runat="server" Text="Edit" ToolTip="Edit the UserAccess Details" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" Width="60px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%#Eval("PK_U_A_Request")%>'
                                                    ToolTip="View the UserAccess Details" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" Width="60px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="center" />
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
    <div runat="server" id="divModifyAccessUser" style="display: block;">
        <div runat="server" id="DivEditAccessUser">
            <table width="100%" cellpadding="3" cellspacing="1" border="0">
                <tr>
                    <td class="bandHeaderRow" colspan="6" align="left">eRIMS2 User Access Request Form
                    </td>
                </tr>
                <tr>
                    <td align="left">First Name<span style="color: Red;">*</span>
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:TextBox runat="server" ID="txtFirstName" MaxLength="50" Width="170px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFirstName" ControlToValidate="txtFirstName" Display="None"
                            runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter First Name."></asp:RequiredFieldValidator>
                    </td>
                    <td align="left">Last Name<span style="color: Red;">*</span>
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:TextBox runat="server" ID="txtLastName" MaxLength="50" Width="170px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvLastName" ControlToValidate="txtLastName" Display="None"
                            runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Last Name."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left">E-Mail<span style="color: Red;">*</span>
                    </td>
                    <td align="center">:
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtEmail" MaxLength="65" Width="170px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtEmail" ControlToValidate="txtEmail" Display="None"
                            runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Email."></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                            ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="Email Address Is Invalid."
                            SetFocusOnError="True" Text="*" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                    </td>
                    <td align="left">Telephone (999-999-9999)
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:TextBox runat="server" ID="txtTelephone" MaxLength="12" Width="170px"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="rfvtxtOfficeTelephone" ControlToValidate="txtOfficeTelephone" Display="None"
                            runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Telephone."></asp:RequiredFieldValidator>--%>
                        <asp:RegularExpressionValidator ID="rfvtxtTelephone" ControlToValidate="txtTelephone"
                            runat="server" ErrorMessage="Please Enter TelePhone in (999-999-9999) format."
                            Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left">Dealership
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:DropDownList runat="server" ID="ddlDealership" Width="135px"></asp:DropDownList>
                    </td>
                    <td align="left">State
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:Label runat="server" ID="lblStateEdit" Width="135px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">Market
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:Label runat="server" ID="lblMarketEdit" Width="135px"></asp:Label>
                    </td>
                    <td align="left"></td>
                    <td align="center"></td>
                    <td align="left"></td>
                </tr>
                <tr>
                    <td align="left">Are you a Sonic Automotive/EchoPark<br />
                        Automotive Associate?
                    </td>
                    <td align="center">:
                    </td>
                    <td>
                        <asp:RadioButtonList runat="server" ID="rdlSA_EA_Associate" SkinID="YesNoTypeNullSelection">
                        </asp:RadioButtonList>
                    </td>
                    <td align="left">Associate Name
                    </td>
                    <td align="center">:
                    </td>
                    <td>
                        <a href="#" id="lnkAssName" onclick="OpenAssociateName();" runat="server">Associate Name</a>
                        <asp:Button ID="btnAssName" OnClick="btnAssName_OnClick" runat="server" Style="display: none;" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="6" width="100%">
                        <table width="100%">
                            <tr>
                                <td>
                                    <b>Check Applicable Job Function</b>
                                </td>
                            </tr>
                            <%--<tr><td>&nbsp;</td></tr>--%>
                            <tr>
                                <td width="70%">
                                    <table width="100%">
                                        <tr>
                                            <td width="25%">
                                                <asp:CheckBox runat="server" ID="chkGeneral_Manager" Text="General Manager"></asp:CheckBox>
                                            </td>
                                            <td width="25%">
                                                <asp:CheckBox runat="server" ID="chkService" Text="Service"></asp:CheckBox>
                                            </td>
                                            <td width="25%">
                                                <asp:CheckBox runat="server" ID="chkParts" Text="Parts"></asp:CheckBox>
                                            </td>
                                            <td width="25%">
                                                <asp:CheckBox runat="server" ID="chkHome_Office" Text="Home Office"                                                    
                                                     OnCheckedChanged="chkHomeOffice_CheckedChanged" AutoPostBack="true"></asp:CheckBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="30%">
                                    <table cellpadding="0" cellspacing="0" border="0" width="100%" id="tdHomeOffice" runat="server" style="display: none;">
                                        <tr style="width: 100%">
                                            <td>
                                                <asp:TextBox ID="txtHome_Office_Text" runat="server" MaxLength="50"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td width="70%">
                                    <table width="100%">
                                        <tr>
                                            <td width="25%">
                                                <asp:CheckBox runat="server" ID="chkController" Text="Controller"></asp:CheckBox>
                                            </td>
                                            <td width="25%">
                                                <asp:CheckBox runat="server" ID="chkSales" Text="Sales"></asp:CheckBox>
                                            </td>
                                            <td width="25%">
                                                <asp:CheckBox runat="server" ID="chkBusiness_Office" Text="Business Office"></asp:CheckBox>
                                            </td>
                                            <td width="25%">
                                                <asp:CheckBox runat="server" ID="chkField_Operastions" Text="Field Operations" AutoPostBack="true" OnCheckedChanged="chkFieldOperations_CheckedChanged"></asp:CheckBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <table cellpadding="0" cellspacing="0" border="0" width="100%" id="tdFieldOperations" runat="server" style="display: none;">
                                        <tr style="width: 100%">
                                            <td>
                                                <asp:TextBox ID="txtField_Operations_Text" runat="server" MaxLength="50"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="left">Reason for Requesting Access
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left" colspan="4">
                        <uc:ctrlMultiLineTextBox ControlType="TextBox" ID="ctrlReason_For_Access" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="left">Are you a Regional/Market/Area<br />
                        Associate?
                    </td>
                    <td align="center">:
                    </td>
                    <td>
                        <asp:RadioButtonList runat="Server" ID="rdlRegional_Market_Area_Associate"
                            SkinID="YesNoTypeNullSelection">
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="revIsRegionalOfficer" runat="server" ValidationGroup="vsErrorGroup"
                            ErrorMessage="Please check Is Regional Officer?" Text="*" Display="none" Enabled="false"
                            ControlToValidate="rdlRegional_Market_Area_Associate"></asp:RequiredFieldValidator>
                    </td>
                    <td align="left">Do you have responsibility for multiple locations?
                    </td>
                    <td align="center">:
                    </td>
                    <td>
                        <asp:RadioButtonList runat="Server" ID="rdlMultiple_Locations"
                            SkinID="YesNoTypeNullSelection">
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="rfvResponsibilityforML" runat="server" ValidationGroup="vsErrorGroup"
                            ErrorMessage="Please check Responsibility for multiple locations?" Text="*" Display="none" Enabled="false"
                            ControlToValidate="rdlMultiple_Locations"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <table width="100%" cellpadding="2" cellspacing="2">
                            <tr valign="top">
                                <td style="width: 16%">Choose Location(s)
                                </td>
                                <td style="width: 2%;" align="center">:
                                </td>
                                <td style="width: 72%">
                                    <table width="100%">
                                        <tr>
                                            <td align="left" style="width: 250px">Locations Available
                                                <asp:ListBox ID="lstLocationsAvailable" runat="server" Rows="10" SelectionMode="Multiple"
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
                                            <td align="left">Locations Selected<br />
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
                    <td align="left">Do you need to access<br />
                        building information?<%--<span style="color: red">*</span>--%>
                    </td>
                    <td align="center">:
                    </td>
                    <td>
                        <asp:RadioButtonList runat="Server" ID="rdlBuilding_Access" valign="top"
                            SkinID="YesNoTypeNullSelection">
                        </asp:RadioButtonList>
                    </td>
                    <td align="left">Do you need to access<br />
                        Environmental, Safety, and<br />
                        Health Information?
                    </td>
                    <td align="center">:
                    </td>
                    <td>
                        <asp:RadioButtonList runat="Server" ID="rdlE_S_H_Access" valign="top"
                            SkinID="YesNoTypeNullSelection">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="left">Do you need the ability to<br />
                        report claims?
                    </td>
                    <td align="center">:
                    </td>
                    <td>
                        <asp:RadioButtonList runat="Server" ID="rdlClaim_Report_Access" valign="top"
                            SkinID="YesNoTypeNullSelection">
                        </asp:RadioButtonList>
                    </td>
                    <td align="left">Do you need to the ability to<br />
                        view claim information?
                    </td>
                    <td align="center">:
                    </td>
                    <td>
                        <asp:RadioButtonList runat="Server" ID="rdlClaim_View_Access" valign="top"
                            SkinID="YesNoTypeNullSelection">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="left">Do you need access to<br />
                        Security Events?
                    </td>
                    <td align="center">:
                    </td>
                    <td>
                        <asp:RadioButtonList runat="Server" ID="rdlSecurity_Access" valign="top"
                            SkinID="YesNoTypeNullSelection">
                        </asp:RadioButtonList>
                    </td>
                    <td align="left">Are you a member of the<br />
                        Safety Leadership Team?
                    </td>
                    <td align="center">:
                    </td>
                    <td>
                        <asp:RadioButtonList runat="Server" ID="rdlSLT_Access" valign="top"
                            SkinID="YesNoTypeNullSelection">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="left">Do you need access to the
                        <br />
                        Facilities Construction Module?                        
                    </td>
                    <td align="center">:
                    </td>
                    <td colspan="4">
                        <asp:RadioButtonList runat="Server" ID="rdlFacilities_Construction_Access" valign="top"
                            SkinID="YesNoTypeNullSelection">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="color: red" align="center">Please allow at least one business day to process this request.</td>
                </tr>
                <%--<tr>
                    <td>&nbsp;</td>
                </tr>--%>
                <%--<tr>
                    <td align="center">&nbsp;<asp:Label runat="server" ID="lblError" CssClass="error" EnableViewState="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="color: red" align="center">
                        <asp:Button ID="btnSave" runat="server" Text=" Save " CausesValidation="true" ValidationGroup="vsErrorGroup" OnClick="btnSave_Click"
                            OnClientClick="return CheckVal();" />&nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />&nbsp;
                        <asp:Button ID="btnClear" runat="server" Text="Clear" />
                    </td>
                </tr>--%>                
            </table>
        </div>
        <div runat="server" id="DivViewAccessUser">
            <table width="100%" cellpadding="3" cellspacing="1" border="0">
                <tr>
                    <td class="bandHeaderRow" colspan="6" align="left">eRIMS2 User Access Request Form
                    </td>
                </tr>
                <tr>
                    <td align="left">First Name
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:Label runat="server" ID="lblFirstName"></asp:Label>
                    </td>
                    <td align="left">Last Name
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:Label runat="server" ID="lblLastName"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">E-Mail
                    </td>
                    <td align="center">:
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblEmail"></asp:Label>
                    </td>
                    <td align="left">Telephone (999-999-9999)
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:Label runat="server" ID="lblTelephone"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">Dealership
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:Label runat="server" ID="lblDealership"></asp:Label>
                    </td>
                    <td align="left">State
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:Label runat="server" ID="lblState" Width="135px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">Market
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:Label runat="server" ID="lblMarket" Width="135px"></asp:Label>
                    </td>
                    <td align="left"></td>
                    <td align="center"></td>
                    <td align="left"></td>
                </tr>
                <tr>
                    <td align="left">Are you a Sonic Automotive/EchoPark<br />
                        Automotive Associate?
                    </td>
                    <td align="center">:
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblSA_EA_Associate">
                        </asp:Label>
                    </td>
                    <td align="left">Associate Name
                    </td>
                    <td align="center">:
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblAssociateName"></asp:Label>
                        <asp:Label runat="server" ID="lblEmployeeId" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="6" width="100%">
                        <table width="100%">
                            <tr>
                                <td>
                                    <b>Check Applicable Job Function</b>
                                </td>
                            </tr>
                            <%--<tr><td>&nbsp;</td></tr>--%>
                            <tr>
                                <td width="70%">
                                    <table width="100%">
                                        <tr>
                                            <td width="25%">
                                                <asp:CheckBox runat="server" ID="chkGeneral_ManagerView" Text="General Manager" Enabled="false"></asp:CheckBox>
                                            </td>
                                            <td width="25%">
                                                <asp:CheckBox runat="server" ID="chkServiceView" Text="Service" Enabled="false"></asp:CheckBox>
                                            </td>
                                            <td width="25%">
                                                <asp:CheckBox runat="server" ID="chkPartsView" Text="Parts" Enabled="false"></asp:CheckBox>
                                            </td>
                                            <td width="25%">
                                                <asp:CheckBox runat="server" ID="chkHome_OfficeView" Text="Home Office" Enabled="false"></asp:CheckBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="30%">
                                    <table cellpadding="0" cellspacing="0" border="0" width="100%" id="tdHome_Office_TextView" runat="server" style="display: none;">
                                        <tr style="width: 100%">
                                            <td>
                                                <asp:Label ID="lblHome_Office_Text" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td width="70%">
                                    <table width="100%">
                                        <tr>
                                            <td width="25%">
                                                <asp:CheckBox runat="server" ID="chkControllerView" Text="Controller" Enabled="false"></asp:CheckBox>
                                            </td>
                                            <td width="25%">
                                                <asp:CheckBox runat="server" ID="chkSalesView" Text="Sales" Enabled="false"></asp:CheckBox>
                                            </td>
                                            <td width="25%">
                                                <asp:CheckBox runat="server" ID="chkBusiness_OfficeView" Text="Business Office" Enabled="false"></asp:CheckBox>
                                            </td>
                                            <td width="25%">
                                                <asp:CheckBox runat="server" ID="chkField_OperastionsView" Text="Field Operations" Enabled="false"></asp:CheckBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <table cellpadding="0" cellspacing="0" border="0" width="100%" id="tdFieldOperationsView" runat="server" style="display: none;">
                                        <tr style="width: 100%">
                                            <td>
                                                <asp:Label ID="lblField_Operations_Text" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="left">Reason for Requesting Access
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left" colspan="4">
                        <uc:ctrlMultiLineTextBox ControlType="Label" ID="ctrlReason_For_AccessView" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="left">Are you a Regional/Market/Area<br />
                        Associate?
                    </td>
                    <td align="center">:
                    </td>
                    <td>
                        <asp:Label runat="Server" ID="lblRegional_Market_Area_Associate">
                        </asp:Label>
                    </td>
                    <td align="left">Do you have responsibility for multiple locations?
                    </td>
                    <td align="center">:
                    </td>
                    <td>
                        <asp:Label runat="Server" ID="lblMultiple_Locations">
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <table width="100%" cellpadding="2" cellspacing="2">
                            <tr valign="top">
                                <td style="width: 16%">Locations Selected
                                </td>
                                <td style="width: 2%;" align="center">:
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
                    <td align="left">Do you need to access<br />
                        building information?
                    </td>
                    <td align="center">:
                    </td>
                    <td>
                        <asp:Label runat="Server" ID="lblBuilding_Access" valign="top">
                        </asp:Label>
                    </td>
                    <td align="left">Do you need to access<br />
                        Environmental, Safety, and<br />
                        Health Information?
                    </td>
                    <td align="center">:
                    </td>
                    <td>
                        <asp:Label runat="Server" ID="lblE_S_H_Access" valign="top">
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">Do you need the ability to<br />
                        report claims?
                    </td>
                    <td align="center">:
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblClaim_Report_Access" valign="top">
                        </asp:Label>
                    </td>
                    <td align="left">Do you need to the ability to<br />
                        view claim information?
                    </td>
                    <td align="center">:
                    </td>
                    <td>
                        <asp:Label runat="Server" ID="lblClaim_View_Access" valign="top">
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">Do you need access to<br />
                        Security Events?
                    </td>
                    <td align="center">:
                    </td>
                    <td>
                        <asp:Label runat="Server" ID="lblSecurity_Access" valign="top">
                        </asp:Label>
                    </td>
                    <td align="left">Are you a member of the<br />
                        Safety Leadership Team?
                    </td>
                    <td align="center">:
                    </td>
                    <td>
                        <asp:Label runat="Server" ID="lblSLT_Access" valign="top">
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">Do you need access to the
                        <br />
                        Facilities Construction Module?                        
                    </td>
                    <td align="center">:
                    </td>
                    <td colspan="4">
                        <asp:Label runat="Server" ID="lblFacilities_Construction_Access" valign="top">
                        </asp:Label>
                    </td>
                </tr>
                <%--<tr>
                    <td colspan="6" style="color: red" align="center">Please allow at least one business day to process this request.</td>
                </tr>--%>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <%-- <tr>
                    <td colspan="6" style="color: red" align="center">
                        <asp:Button ID="Button5" runat="server" Text=" Save " CausesValidation="true" ValidationGroup="vsErrorGroup"
                            OnClientClick="return CheckVal();" />&nbsp;
                        <asp:Button ID="Button6" runat="server" Text="Cancel" />&nbsp;
                        <asp:Button ID="Button7" runat="server" Text="Clear" />
                    </td>
                </tr>--%>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>


        <table width="100%" cellpadding="3" cellspacing="1" border="0">
            <tr>
                <td align="center">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td align="center">&nbsp;<asp:Label runat="server" ID="lblError" CssClass="error" EnableViewState="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnSave" runat="server" Text=" Save " CausesValidation="true" ValidationGroup="vsErrorGroup"
                                    OnClick="btnSave_Click" OnClientClick="return CheckVal();" />&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false"
                                    OnClick="btnCancel_Click" />&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnPromote" runat="server" Text="Promote" CausesValidation="false" Visible="false"
                                    OnClick="btnPromote_Click" />&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnDeny" runat="server" Text="Deny" CausesValidation="false" Visible="false"
                                    OnClick="btnDeny_Click" />&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnClear" runat="server" Text="Clear" CausesValidation="false" Visible="false"
                                    OnClick="btnClear_Click" />
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

