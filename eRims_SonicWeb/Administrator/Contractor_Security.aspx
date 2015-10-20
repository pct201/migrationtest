<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Contractor_Security.aspx.cs"
    Inherits="Administrator_Contractor_Security" Title="eRIMS Sonic :: Contractor Security" MaintainScrollPositionOnPostback="true" %>

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
        jQuery(function ($) {
            $("#<%=txtZipCode.ClientID%>").mask("99999-9999");
            $("#<%=txtOfficeTelephone.ClientID%>").mask("999-999-9999");
            $("#<%=txtCellPhone.ClientID%>").mask("999-999-9999");
            $("#<%=txtPager.ClientID%>").mask("999-999-9999");
        });
        function CheckVal() {            
            if (document.getElementById('<%=txtCellPhone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtCellPhone.ClientID%>').value = "";
            if (document.getElementById('<%=txtOfficeTelephone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtOfficeTelephone.ClientID%>').value = "";
            if (document.getElementById('<%=txtPager.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtPager.ClientID%>').value = "";
            if (document.getElementById('<%=txtZipCode.ClientID%>').value == "_____-____")
                document.getElementById('<%=txtZipCode.ClientID%>').value = "";

            if (Page_ClientValidate()) {
                return true;
            }
            else
                return false;
        }
        function OPenCSChangePasswordPopup() {
            GB_showCenter('Associate Name', '<%=AppConfig.SiteURL%>Administrator/ChangePasswordContractorSecurity_Popup.aspx?UserName=' + document.getElementById('<%=txtLoginUserName.ClientID %>').value + '&id=0&UID=' + document.getElementById('<%=HdnPK_Contactor_Security.ClientID %>').value, 500, 500, '');
        }

        function OpenVCardPopup() {
            //GB_showCenter('Load VCard', '<%=AppConfig.SiteURL%>Administrator/LoadVCard.aspx', 200, 500, '');
            //var window = window.open(, "", "height=200,width=500")
            var left = (screen.width / 2) - (500 / 2);
            var top = (screen.height / 2) - (200 / 2);
            var window1 = window.open('<%=AppConfig.SiteURL%>Administrator/LoadVCard.aspx', "vCard", 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=500 , height=200, top=' + top + ', left=' + left);
            window1.focus();
            return false;
        }
    </script>
    <link href="<%=AppConfig.SiteURL%>greybox/gb_styles.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/gb_scripts.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>
    <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>
    <br />
    <asp:HiddenField ID="hdnMode" runat="server" Value="0"></asp:HiddenField>
    <div runat="Server" id="divViewContractSecurityList">
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td class="bandHeaderRow" colspan="4" align="left">Contractor Security 
                </td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;<asp:HiddenField runat="server" ID="HdnPK_Contactor_Security" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td style="width: 70%" align="right">Search by User Name
                            </td>
                            <td style="width: 5%">&nbsp;
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
                <td colspan="4" style="height: 5px"></td>
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
                                <asp:Button ID="btnLoadVCard" runat="server" ToolTip="click here to Load VCARD" Text="Load VCARD" OnClientClick="return OpenVCardPopup();" />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Click here to delete "
                                    OnClick="btnDelete_Click" />
                                <asp:Button ID="btnAddNew" runat="server" Text="Add New" ToolTip="Add new "
                                    OnClick="btnAddNew_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 5px;"></td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">
                                <asp:GridView ID="gvContractorSecurity" runat="server" AutoGenerateColumns="false" DataKeyNames="PK_Contactor_Security"
                                    Width="100%" OnRowCreated="gvContractorSecurity_RowCreated" OnSorting="gvContractorSecurity_Sorting"
                                    AllowSorting="True" OnRowCommand="gvContractorSecurity_RowCommand" OnRowDataBound="gvContractorSecurity_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemStyle Width="5%" />
                                            <ItemTemplate>
                                                <input name="chkItem" type="checkbox" value='<%# Eval("PK_Contactor_Security")%>' onclick="javascript: UnCheckHeader('gvContractorSecurity')" />
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <input type="checkbox" name="chkHeader" id="chkHeader" runat="Server" onclick="javascript: SelectAllCheckboxes(this)" />
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
                                        <asp:TemplateField>
                                            <ItemStyle Width="15%" />
                                            <ItemTemplate>
                                                <asp:Button ID="btnEdit" CommandName="EditItem" CommandArgument='<%#Eval("PK_Contactor_Security")%>'
                                                    runat="server" Text="Edit" ToolTip="Edit the Contractor Security Details" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" Width="60px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%#Eval("PK_Contactor_Security")%>'
                                                    ToolTip="View the Contractor Security Details" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" Width="60px" />
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

    <div runat="server" id="divModifyAdmin" style="display: none;">
        <div runat="server" id="DivEditContractorSecuirty">
            <table width="100%" cellpadding="3" cellspacing="1" border="0">
                <tr>
                    <td class="bandHeaderRow" style="height: 14px;" colspan="6" align="left">Contractor Security
                    </td>
                </tr>
                <tr>
                    <td style="width: 18%;" align="left">Login User Name<span style="color: Red;">*</span>
                    </td>
                    <td style="width: 4%;" align="center">:
                    </td>
                    <td align="left" width="26%">
                        <asp:TextBox runat="server" ID="txtLoginUserName" MaxLength="75" ValidationGroup="vsErrorGroup"
                            Width="170px"></asp:TextBox>&nbsp;
                        <asp:HiddenField runat="server" ID="hdnPKLoginUserName" />
                        <asp:RequiredFieldValidator ID="rfvLoginUserName" ControlToValidate="txtLoginUserName" Display="None"
                            runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Login User Name."></asp:RequiredFieldValidator>
                    </td>
                    <td align="left" width="15%">&nbsp;
                    </td>
                    <td align="center" width="4%">&nbsp;
                    </td>
                    <td width="36%">
                        <a href="#" onclick="OPenCSChangePasswordPopup();" id="PopupPassword" runat="Server"
                            style="display: none;">Change Password</a>
                    </td>
                </tr>
                <tr runat="server" id="trPassword" style="display: none;">
                    <td align="left">Password<span style="color: Red;">*</span>
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:TextBox runat="server" ID="txtPassword" MaxLength="50" ValidationGroup="vsErrorGroup"
                            Width="170px" TextMode="Password"></asp:TextBox>&nbsp;
                        <asp:RequiredFieldValidator ID="rfvPassword" ControlToValidate="txtPassword" Display="None"
                            runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Password."></asp:RequiredFieldValidator>
                    </td>
                    <td align="left">Confirm Password<span style="color: Red;">*</span>
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:TextBox runat="server" ID="txtConfirmPassword" MaxLength="50" ValidationGroup="vsErrorGroup"
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
                    <td align="left">Contractor Firm<span style="color: Red;">*</span>
                    </td>
                    <td style="width: 4%;" align="center">:
                    </td>
                    <%--<td align="left" width="26%">
                        <asp:TextBox runat="server" ID="txtContractorCompany" MaxLength="75" ValidationGroup="vsErrorGroup"
                            Width="170px"></asp:TextBox>&nbsp;
                    </td>--%>
                    <td align="left" width="26%">
                        <asp:DropDownList ID="ddlContractorfirm" runat="server" Width="170px" SkinID="ddlSONIC">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlContractorfirm" Display="None"
                             ValidationGroup="vsErrorGroup" Text="*" InitialValue="0" runat="server" ErrorMessage="Please select atleast one Contractor Firm."></asp:RequiredFieldValidator>
                    </td>
                    <td align="left">Contractor Type<span style="color: Red;">*</span>
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlContractoType" runat="server" Width="170px" SkinID="ddlSONIC">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvddlContractoType" ControlToValidate="ddlContractoType" Display="None"
                            ValidationGroup="vsErrorGroup" Text="*" InitialValue="0" runat="server" ErrorMessage="Please select atleast one Contractor Type."></asp:RequiredFieldValidator>
                    </td>

                </tr>

                <tr>
                    <td align="left">Alert Method<span style="color: Red;">*</span>
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlAlertMethod" runat="server" Width="170px" SkinID="ddlSONIC">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvddlAlertMethod" ControlToValidate="ddlAlertMethod" Display="None"
                            ValidationGroup="vsErrorGroup" Text="*" InitialValue="0" runat="server" ErrorMessage="Please select atleast one Alert Method."></asp:RequiredFieldValidator>
                    </td>
                    <td align="left">Dashboard<span style="color: Red;">*</span>
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlDashboardType" runat="server" Width="170px" SkinID="ddlSONIC">
                            <asp:ListItem Value="0">-- Select --</asp:ListItem>
                            <asp:ListItem Value="1">Pie Charts</asp:ListItem>
                            <asp:ListItem Value="2">Task List</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvddlDashboard" ControlToValidate="ddlDashboardType" Display="None"
                            ValidationGroup="vsErrorGroup" Text="*" InitialValue="0" runat="server" ErrorMessage="Please select atleast one Dashboard."></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td align="left">Address 1<%--<span style="color: Red;">*</span>--%>
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:TextBox runat="server" ID="txtAddress1" MaxLength="75" Width="170px"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="rfvtxtAddress1" ControlToValidate="txtAddress1" Display="None"
                            runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Address 1."></asp:RequiredFieldValidator>--%>
                    </td>
                    <td align="left">Address 2<%--<span style="color: Red;">*</span>--%>
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:TextBox runat="server" ID="txtAddress2" MaxLength="75" Width="170px"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="rfvtxtAddress2" ControlToValidate="txtAddress2" Display="None"
                            runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Address 2."></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>

                <tr>
                    <td align="left">City<%--<span style="color: Red;">*</span>--%>
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:TextBox runat="server" ID="txtCity" MaxLength="50" Width="170px"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="rfvtxtCity" ControlToValidate="txtCity" Display="None"
                            runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter City."></asp:RequiredFieldValidator>--%>
                    </td>
                    <td align="left">State<%--<span style="color: Red;">*</span>--%>
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlState" runat="server" Width="170px" SkinID="ddlSONIC">
                        </asp:DropDownList>

                    </td>
                </tr>
                <tr>
                    <td align="left">Zip Code (99999-9999)<%--<span style="color: Red;">*</span>--%>
                    </td>
                    <td style="width: 4%;" align="center">:
                    </td>
                    <td align="left" width="26%" colspan="4">
                        <asp:TextBox runat="server" ID="txtZipCode" MaxLength="10" ValidationGroup="vsErrorGroup"
                            Width="170px"></asp:TextBox>&nbsp;
                        <%--<asp:RequiredFieldValidator ID="rfvtxtZipCode" ControlToValidate="txtZipCode" Display="None"
                            runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Zip Code."></asp:RequiredFieldValidator>--%>
                        <asp:RegularExpressionValidator ID="rfvtxtZipCode" ControlToValidate="txtZipCode" runat="server"
                            ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Zip Code in xxxxx-xxxx format."
                            Display="none" ValidationExpression="((\(\d{2}\) ?)|(\d{5}-))?\d{4}$"></asp:RegularExpressionValidator>
                    </td>

                </tr>

                <tr>
                    <td align="left">Office Telephone (999-999-9999)
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:TextBox runat="server" ID="txtOfficeTelephone" MaxLength="12" Width="170px"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="rfvtxtOfficeTelephone" ControlToValidate="txtOfficeTelephone" Display="None"
                            runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Office Telephone."></asp:RequiredFieldValidator>--%>
                        <asp:RegularExpressionValidator ID="rfvtxtOfficeTelephone" ControlToValidate="txtOfficeTelephone"
                            runat="server" ErrorMessage="Please Enter Office TelePhone in XXX-XXX-XXXX format."
                            Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                    </td>
                    <td align="left">Cell Phone (999-999-9999)<%--<span style="color: Red;">*</span>--%>
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:TextBox runat="server" ID="txtCellPhone" MaxLength="12" Width="170px"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="rfvtxtCellPhone" ControlToValidate="txtCellPhone" Display="None"
                            runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Cell Phone."></asp:RequiredFieldValidator>--%>
                        <asp:RegularExpressionValidator ID="rfvtxtCellPhone" ControlToValidate="txtCellPhone"
                            runat="server" ErrorMessage="Please Enter Cell Phone in XXX-XXX-XXXX format."
                            Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left">Pager (999-999-9999)<%--<span style="color: Red;">*</span>--%>
                    </td>
                    <td style="width: 4%;" align="center">:
                    </td>
                    <td align="left" width="26%" colspan="4">
                        <asp:TextBox runat="server" ID="txtPager" MaxLength="12" ValidationGroup="vsErrorGroup"
                            Width="170px"></asp:TextBox>&nbsp;
                        <%--<asp:RequiredFieldValidator ID="rfvtxtPager" ControlToValidate="txtPager" Display="None"
                            runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Pager."></asp:RequiredFieldValidator>--%>
                        <asp:RegularExpressionValidator ID="rfvtxtPager" ControlToValidate="txtPager"
                            runat="server" ErrorMessage="Please Enter Pager in XXX-XXX-XXXX format."
                            Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                    </td>

                </tr>
                <tr>
                    <td align="left">Email<span style="color: Red;">*</span>
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:TextBox runat="server" ID="txtEmail" MaxLength="100" Width="170px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtEmail" ControlToValidate="txtEmail" Display="None"
                            runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Email."></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                            ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="Email Address Is Invalid."
                            SetFocusOnError="True" Text="*" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                    </td>
                    <td align="left">Vendor Number
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:TextBox runat="server" ID="txtVendorNumber" MaxLength="50" Width="170px"></asp:TextBox>                                                
                    </td>
                </tr>
                <tr>
                    <td align="left">Firm/Contract Type
                    </td>
                    <td style="width: 4%;" align="center">:
                    </td>
                    <td align="left" width="26%" colspan="4">
                        <asp:DropDownList ID="ddlContractType" runat="server" Width="170px" SkinID="ddlSONIC">
                        </asp:DropDownList>
                    </td>

                </tr>
                <tr>
                    <td align="left" valign="top">Location/Project Access Grid<br />
                        <asp:LinkButton ID="lnkAddLocationProjectAccessGrid" runat="server" Text="--Add--"
                            OnClick="lnkAddLocationProjectAccessGrid_Click" />
                        <%--OnClientClick="return CheckVal();" ValidationGroup="vsErrorGroup" CausesValidation="true" --%>
                    </td>
                    <td align="center" valign="top">:
                    </td>
                    <td colspan="4" align="left" valign="top">
                        <asp:GridView ID="gvLocationProjectAccess" runat="server" Width="100%" AutoGenerateColumns="false"
                            EmptyDataText="No Record Exists" OnRowCommand="gvLocationProjectAccess_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Location" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle Width="20%" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkLocation" runat="server" Text='<%# Eval("dba") %>'
                                            CommandName="EditDetails" Style="word-wrap: normal; word-break: break-all;" CommandArgument='<%# Eval("PK_Contractor_Job_Security") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Project Number" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle Width="20%" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkProject_Number" Style="word-wrap: normal; word-break: break-all;" runat="server" Text='<%# Eval("Project_Number") %>'
                                            CommandName="EditDetails" CommandArgument='<%# Eval("PK_Contractor_Job_Security") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Project Start Date" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle Width="20%" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkEstimated_Start_Date" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Estimated_Start_Date","{0:MM/dd/yyyy}") %>'
                                            CommandName="EditDetails" CommandArgument='<%# Eval("PK_Contractor_Job_Security") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Access" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle Width="20%" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkAccess" runat="server" Text='<%# Eval("Access") %>'
                                            CommandName="EditDetails" CommandArgument='<%# Eval("PK_Contractor_Job_Security") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveDetails"
                                            CommandArgument='<%# Eval("PK_Contractor_Job_Security") %>' OnClientClick="return confirm('Are you sure to remove the record?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>



            </table>
        </div>

        <div runat="server" id="DivViewSecurity">
            <table width="100%" cellpadding="3" cellspacing="1" border="0">
                <tr>
                    <td class="bandHeaderRow" colspan="6" align="left">Contractor Security
                    </td>
                </tr>
                <tr>
                    <td style="width: 18%;" align="left">Login User Name
                    </td>
                    <td style="width: 4%;" align="center">:
                    </td>
                    <td colspan="4" align="left">
                        <asp:Label runat="server" ID="lblLoginUserName" Style="word-wrap: normal; word-break: break-all"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="width: 18%;">First Name
                    </td>
                    <td align="center" style="width: 4%;">:
                    </td>
                    <td align="left" style="width: 28%;">
                        <asp:Label runat="server" ID="lblFirstName" Style="word-wrap: normal; word-break: break-all"></asp:Label>
                    </td>
                    <td align="left" style="width: 18%;">Last Name
                    </td>
                    <td align="center" style="width: 4%;">:
                    </td>
                    <td align="left" style="width: 28%;">
                        <asp:Label runat="server" ID="lblLastName" Style="word-wrap: normal; word-break: break-all"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">Contractor Firm
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:Label runat="server" Style="word-wrap: normal; word-break: break-all" ID="lblContractorFirm">
                        </asp:Label>
                    </td>
                    <td align="left" style="width: 18%;">Contractor Type
                    </td>
                    <td align="center" style="width: 4%;">:
                    </td>
                    <td align="left" style="width: 28%;">
                        <asp:Label runat="server" Style="word-wrap: normal; word-break: break-all" ID="lblContractorType"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">Alert Method
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:Label runat="server" Style="word-wrap: normal; word-break: break-all" ID="lblAlertMethod"></asp:Label>
                    </td>
                    <td align="left" style="width: 18%;">Dashboard
                    </td>
                    <td align="center" style="width: 4%;">:
                    </td>
                    <td align="left" style="width: 28%;">
                        <asp:Label runat="server" Style="word-wrap: normal; word-break: break-all" ID="lblDashboardType"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="width: 18%;">Address 1
                    </td>
                    <td align="center" style="width: 4%;">:
                    </td>
                    <td align="left" style="width: 28%;">
                        <asp:Label runat="server" Style="word-wrap: normal; word-break: break-all" ID="lblAddress1"></asp:Label>
                    </td>
                    <td align="left" style="width: 18%;">Address 2
                    </td>
                    <td align="center" style="width: 4%;">:
                    </td>
                    <td align="left" style="width: 28%;">
                        <asp:Label runat="server" Style="word-wrap: normal; word-break: break-all" ID="lblAddress2"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="width: 18%;">City
                    </td>
                    <td align="center" style="width: 4%;">:
                    </td>
                    <td align="left" style="width: 28%;">
                        <asp:Label runat="server" ID="lblCity" Style="word-wrap: normal; word-break: break-all"></asp:Label>
                    </td>
                    <td align="left" style="width: 18%;">State
                    </td>
                    <td align="center" style="width: 4%;">:
                    </td>
                    <td align="left" style="width: 28%;">
                        <asp:Label runat="server" ID="lblState"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">Zip Code (99999-9999)
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left" colspan="4">
                        <asp:Label runat="server" ID="lblZipCode">
                        </asp:Label>
                    </td>

                </tr>
                <tr>
                    <td align="left" style="width: 18%;">Office Telephone (999-999-9999)
                    </td>
                    <td align="center" style="width: 4%;">:
                    </td>
                    <td align="left" style="width: 28%;">
                        <asp:Label runat="server" ID="lblOfficeTelephone"></asp:Label>
                    </td>
                    <td align="left" style="width: 18%;">Cell Phone (999-999-9999)
                    </td>
                    <td align="center" style="width: 4%;">:
                    </td>
                    <td align="left" style="width: 28%;">
                        <asp:Label runat="server" ID="lblCellPhone"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">Pager (99999-9999)
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left" colspan="4">
                        <asp:Label runat="server" ID="lblPager">
                        </asp:Label>
                    </td>

                </tr>
                <tr>
                    <td align="left">Email
                    </td>
                    <td align="center">:
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblEmail" Style="word-wrap: normal; word-break: break-all"></asp:Label>
                    </td>
                    <td align="left">Vendor Number
                    </td>
                    <td align="center">:
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblVendorNumber" Style="word-wrap: normal; word-break: break-all"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">Firm/Contract Type
                    </td>
                    <td align="center">:
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblContractType" Style="word-wrap: normal; word-break: break-all"></asp:Label>
                    </td>
                </tr
                <tr>
                    <td align="left" valign="top">Location/Project Access Grid<br />

                    </td>
                    <td align="center" valign="top">:
                    </td>
                    <td colspan="4" align="left" valign="top">
                        <asp:GridView ID="gvViewLocationProjectAccess" runat="server" Width="100%" AutoGenerateColumns="false"
                            EmptyDataText="No Record Exists" OnRowCommand="gvViewLocationProjectAccess_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Location">
                                    <ItemStyle Width="20%" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkdbaview" runat="server" Text='<%# Eval("dba") %>'
                                            CommandName="ViewDetails" CommandArgument='<%# Eval("PK_Contractor_Job_Security") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Project Number">
                                    <ItemStyle Width="20%" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkProject_NumberView" runat="server" Text='<%# Eval("Project_Number") %>'
                                            CommandName="ViewDetails" CommandArgument='<%# Eval("PK_Contractor_Job_Security") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Project Start Date">
                                    <ItemStyle Width="20%" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkEstimated_Start_DateView" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Estimated_Start_Date","{0:MM/dd/yyyy}") %>'
                                            CommandName="ViewDetails" CommandArgument='<%# Eval("PK_Contractor_Job_Security") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Access">
                                    <ItemStyle Width="20%" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkAccessview" runat="server" Text='<%# Eval("Access") %>'
                                            CommandName="ViewDetails" CommandArgument='<%# Eval("PK_Contractor_Job_Security") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%-- 
                                <asp:TemplateField HeaderText="Remove">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveDetails"
                                            CommandArgument='<%# Eval("PK_Contractor_Job_Security") %>' OnClientClick="return confirm('Are you sure to remove the record?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                    </td>
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
                            <td align="center">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnSave" runat="server" Text=" Save & View" CausesValidation="true" ValidationGroup="vsErrorGroup"
                                    OnClick="btnSave_Click" OnClientClick="return CheckVal();" />&nbsp;&nbsp;&nbsp;
                                  <asp:Button ID="btnEdit" runat="server" Text=" Edit " OnClick="btnEdit_Click" />&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false"
                                    OnClick="btnCancel_Click" />
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

