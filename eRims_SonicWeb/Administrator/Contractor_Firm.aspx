<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Contractor_Firm.aspx.cs" Inherits="Administrator_Contractor_Firm" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery.maskedinput.js"></script>


    <script type="text/javascript">
        var GB_ROOT_DIR = '<%=AppConfig.SiteURL%>' + 'greybox/';
        jQuery(function ($) {
            <%--$("#<%=txtZipCode.ClientID%>").mask("99999-9999");--%>
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

    <div runat="Server" id="divViewContractorFirmList">
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td class="bandHeaderRow" colspan="4" align="left">Contractor Firm 
                </td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;<asp:HiddenField runat="server" ID="HdnPK_Contractor_Firm" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td style="width: 70%" align="right">Search by Firm Name
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
                                <asp:GridView ID="gvContractorFirm" runat="server" AutoGenerateColumns="false" DataKeyNames="PK_Contractor_Firm"
                                    Width="100%" OnRowCreated="gvContractorFirm_RowCreated" OnSorting="gvContractorFirm_Sorting"
                                    AllowSorting="True" OnRowCommand="gvContractorFirm_RowCommand" OnRowDataBound="gvContractorFirm_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemStyle Width="5%" />
                                            <ItemTemplate>
                                                <input name="chkItem" type="checkbox" value='<%# Eval("PK_Contractor_Firm")%>' onclick="javascript: UnCheckHeader('gvContractorFirm')" />
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <input type="checkbox" name="chkHeader" id="chkHeader" runat="Server" onclick="javascript: SelectAllCheckboxes(this)" />
                                            </HeaderTemplate>
                                            <HeaderStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Firm Name" SortExpression="Contractor_Firm_Name">
                                            <ItemStyle Width="20%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblContractor_Firm_Name" runat="server" Text='<%# Eval("Contractor_Firm_Name")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Address" SortExpression="Address_1">
                                            <ItemStyle Width="20%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblAddress_1" runat="server" Text='<%# FormatAddress(Eval("Address_1"), Eval("Address_2")) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="City" SortExpression="City">
                                            <ItemStyle Width="10%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblCity" runat="server" Text='<%# Eval("City")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="State" SortExpression="FK_State">
                                            <ItemStyle Width="15%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblFK_State" runat="server" Text='<%# CheckState(Eval("FK_State"))%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField HeaderText="Zip" SortExpression="Zip_Code">
                                            <ItemStyle Width="10%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblZip_Code" runat="server" Text='<%# Eval("Zip_Code")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Office" SortExpression="Office_Telephone">
                                            <ItemStyle Width="10%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblOffice_Telephone" runat="server" Text='<%# Eval("Office_Telephone")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mobile" SortExpression="Cell_Telephone">
                                            <ItemStyle Width="10%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblCell_Telephone" runat="server" Text='<%# Eval("Cell_Telephone")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Email" SortExpression="Email">
                                            <ItemStyle Width="20%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemStyle Width="15%" />
                                            <ItemTemplate>
                                                <asp:Button ID="btnEdit" CommandName="EditItem" CommandArgument='<%#Eval("PK_Contractor_Firm")%>'
                                                    runat="server" Text="Edit" ToolTip="Edit the Contractor Firm Details" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" Width="60px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%#Eval("PK_Contractor_Firm")%>'
                                                    ToolTip="View the Contractor Firm Details" />
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
        <div runat="server" id="DivEditContractorFirm">
            <table width="100%" cellpadding="3" cellspacing="1" border="0">
                <tr>
                    <td class="bandHeaderRow" style="height: 14px;" colspan="6" align="left">Contractor Firm
                    </td>
                </tr>                         

                <tr>
                    <td align="left" width="20%">Contractor Firm Name <span style="color: Red;">*</span>
                    </td>
                    <td align="center" width="4%">:
                    </td>
                    <td align="left" width="28%" >
                        <asp:TextBox runat="server" ID="txtContractorFirmName" MaxLength="50" Width="170px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFirstName" ControlToValidate="txtContractorFirmName" Display="None"
                            runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Contractor Firm Name."></asp:RequiredFieldValidator>
                    </td>                    
                   <td align="left">Firm Type<%--<span style="color: Red;">*</span>--%>
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                         <asp:DropDownList ID="ddlFirmType" runat="server" Width="170px" SkinID="ddlSONIC">
                        </asp:DropDownList>
                        <%--<asp:RequiredFieldValidator ID="rfvtxtAddress2" ControlToValidate="txtAddress2" Display="None"
                            runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Address 2."></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>                               
                <tr>
                    <td align="left">Address 1<span style="color: Red;">*</span>
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:TextBox runat="server" ID="txtAddress1" MaxLength="75" Width="170px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtAddress1" ControlToValidate="txtAddress1" Display="None"
                            runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Address 1."></asp:RequiredFieldValidator>
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
                    <td align="left">City<span style="color: Red;">*</span>
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:TextBox runat="server" ID="txtCity" MaxLength="50" Width="170px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtCity" ControlToValidate="txtCity" Display="None"
                            runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter City."></asp:RequiredFieldValidator>
                    </td>
                    <td align="left">State <span style="color: Red;">*</span>
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlState" runat="server" Width="170px" SkinID="ddlSONIC">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvddlState" ControlToValidate="ddlState" Display="None"
                            runat="server" InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please select State."></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td align="left">Zip Code (99999-9999)<span style="color: Red;">*</span>
                    </td>
                    <td style="width: 4%;" align="center">:
                    </td>
                    <td align="left" width="26%" >
                        <asp:TextBox runat="server" ID="txtZipCode" MaxLength="10" ValidationGroup="vsErrorGroup"
                            Width="170px"></asp:TextBox>&nbsp;
                        <asp:RequiredFieldValidator ID="rfvtxtZipCode1" ControlToValidate="txtZipCode" Display="None"
                            runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Zip Code."></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rfvtxtZipCode" ControlToValidate="txtZipCode" runat="server"
                            ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Zip Code in xxxxx-xxxx format."
                            Display="none" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                    </td>
                     <td align="left">Contact Name</td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:TextBox runat="server" ID="txtContactName" MaxLength="50" Width="170px"></asp:TextBox>
                        <%--<asp:RequiredFieldvalidator id="rfvtxtaddress2" controltovalidate="txtaddress2" display="none"
                            runat="server" initialvalue="" text="*" validationGroup="vsErrorGroup" ErrorMessage="Please Enter Address 2."></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>

                <tr>
                    <td align="left">Office Telephone (999-999-9999)<span style="color: Red;">*</span>
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:TextBox runat="server" ID="txtOfficeTelephone" MaxLength="12" Width="170px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtOfficeTelephone1" ControlToValidate="txtOfficeTelephone" Display="None"
                            runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Office Telephone."></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rfvtxtOfficeTelephone" ControlToValidate="txtOfficeTelephone"
                            runat="server" ErrorMessage="Please Enter Office TelePhone in XXX-XXX-XXXX format."
                            Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                    </td>
                    <td align="left">Cell Phone (999-999-9999)<span style="color: Red;">*</span>
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:TextBox runat="server" ID="txtCellPhone" MaxLength="12" Width="170px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtCellPhone2" ControlToValidate="txtCellPhone" Display="None"
                            runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Cell Phone."></asp:RequiredFieldValidator>
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
                    <td align="left" width="26%">
                        <asp:TextBox runat="server" ID="txtPager" MaxLength="12" ValidationGroup="vsErrorGroup"
                            Width="170px"></asp:TextBox>&nbsp;
                        <%--<asp:RequiredFieldValidator ID="rfvtxtPager" ControlToValidate="txtPager" Display="None"
                            runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Pager."></asp:RequiredFieldValidator>--%>
                        <asp:RegularExpressionValidator ID="rfvtxtPager" ControlToValidate="txtPager"
                            runat="server" ErrorMessage="Please Enter Pager in XXX-XXX-XXXX format."
                            Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                    </td>
                     <td align="left">Facsimile Number
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:TextBox runat="server" ID="txtFacsimile_Number" MaxLength="13" Width="170px"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="rfvtxtAddress2" ControlToValidate="txtAddress2" Display="None"
                            runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Address 2."></asp:RequiredFieldValidator>--%>
                    </td>

                </tr>
                <tr>
                    <td align="left">Email <span style="color: Red;">*</span>
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
                        <asp:TextBox runat="server" ID="txtVendor_Number" MaxLength="50" Width="170px"></asp:TextBox>
                    </td>
                </tr>    

             </table>
        </div>

        <div runat="server" id="DivViewSecurity">
            <table width="100%" cellpadding="3" cellspacing="1" border="0">
                <tr>
                    <td class="bandHeaderRow" colspan="6" align="left">Contractor Firm
                    </td>
                </tr>
                <tr>
                    <td align="left" style="width: 18%;">Contractor Firm Name
                    </td>
                    <td align="center" style="width: 4%;">:
                    </td>
                    <td align="left" style="width: 28%;">
                        <asp:Label runat="server" ID="lblContractorFirmName" Style="word-wrap: normal; word-break: break-all"></asp:Label>
                    </td>
                    <td align="left" style="width: 18%;">Firm Type
                    </td>
                    <td align="center" style="width: 4%;">:
                    </td>
                    <td align="left" style="width: 28%;">
                        <asp:Label runat="server" ID="lblFirmType" Style="word-wrap: normal; word-break: break-all"></asp:Label>
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
                    <td align="left" >
                        <asp:Label runat="server" ID="lblZipCode">
                        </asp:Label>
                    </td>
                     <td align="left" style="width: 18%;">Contact Name
                    </td>
                    <td align="center" style="width: 4%;">:
                    </td>
                    <td align="left" style="width: 28%;">
                        <asp:Label runat="server" ID="lblContactName"></asp:Label>
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
                    <td align="left">
                        <asp:Label runat="server" ID="lblPager">
                        </asp:Label>
                    </td>
                    <td align="left" style="width: 18%;">Facsimile Number
                    </td>
                    <td align="center" style="width: 4%;">:
                    </td>
                    <td align="left" style="width: 28%;">
                        <asp:Label runat="server" ID="lblFacsimileNumber"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">Email
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:Label runat="server" ID="lblEmail" Style="word-wrap: normal; word-break: break-all"></asp:Label>
                    </td>
                    <td align="left">Vendor Number
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:Label runat="server" ID="lblVendor_Number" Style="word-wrap: normal; word-break: break-all"></asp:Label>
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

