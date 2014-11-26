<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="Management.aspx.cs" Inherits="Management_Management" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ManagementTab/ManagementTab.ascx" TagName="ctrlManagementTab"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Date_Validation.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery.maskedinput.js"></script>



    <script type="text/javascript">

        function ConfirmDelete() {
            return confirm("Are you sure that you want to delete the selected information and all of its subordinate data (if exists)?");
        }

        function AuditPopUp() {

            var winHeight = window.screen.availHeight - 300;
            if (window.screen.availHeight == 728) {
                winHeight = winHeight + 20;
            }
            var winWidth = window.screen.availWidth - 200;
            obj = window.open("AuditPopup_Management.aspx?id=" + '<%=ViewState["PK_Management"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }

        jQuery(function ($) {
            $("#<%=txtdate_Scheduled.ClientID%>").mask("99/99/9999");
            $("#<%=txtDate_Completed.ClientID%>").mask("99/99/9999");
            $("#<%=txtCR_Approved.ClientID%>").mask("99/99/9999");

        });
    </script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" CssClass="errormessage" ValidationGroup="vsErrorGroup"
            BorderColor="DimGray" BorderWidth="1" HeaderText="Verify the following fields:"
            ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
    </div>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                <uc:ctrlManagementTab runat="server" ID="ctrlMgmtTab" />
            </td>
        </tr>
        <%--<tr>
            <td>
                <div class="bandHeaderRow">
                    <table width="100%" border="0" cellpadding="2" cellspacing="0">
                        <tr>
                            <td align="left">
                                Management
                            </td>
                            <td align="right">
                                <asp:Label ID="lblLastModifiedDateTime" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>--%>
        <%-- <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="Spacer" style="height: 10px;" colspan="2">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>--%>
        <tr>
            <td valign="top">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td width="5px" class="Spacer">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="">
                            <div id="dvEdit" runat="server" width="999px">
                                <asp:Panel ID="pnl1" runat="server" Style="display: block;" Width="999px">
                                    <div class="bandHeaderRow">
                                        Management
                                    </div>
                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                        <tr>
                                            <td style="height: 5px" colspan="6"></td>
                                        </tr>
                                        <tr>
                                            <%--<td align="left" width="18%" valign="top">
                                                Company<span class="mf">*</span>
                                            </td>
                                            <td align="center" width="4%" valign="top">
                                                :
                                            </td>
                                            <td align="left" width="28%" valign="top">
                                                <asp:TextBox ID="txtCompany" MaxLength="50" runat="server" Width="170px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtCompany" runat="server" ControlToValidate="txtCompany"
                                                    ErrorMessage="Please Enter Company" Display="None" SetFocusOnError="true" ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                            </td>--%>
                                            <td align="left" width="18%" valign="top">DBA<span class="mf">*</span>
                                            </td>
                                            <td align="center" width="4%" valign="top">:
                                            </td>
                                            <td align="left" width="28%" valign="top">
                                                <asp:DropDownList ID="drpLocation" runat="server" Width="170px" SkinID="dropGen" AutoPostBack="true" OnSelectedIndexChanged="drpLocation_SelectedIndexChanged"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvdrpLocation" runat="server" ControlToValidate="drpLocation"
                                                    InitialValue="0" ErrorMessage="Please Select DBA" Display="None" SetFocusOnError="true"
                                                    ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                            </td>
                                            <td align="left" width="18%" valign="top">Location Code
                                            </td>
                                            <td align="center" width="4%" valign="top">:
                                            </td>
                                            <td align="left" width="28%" valign="top">
                                                <asp:UpdatePanel ID="upnlCode" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtLocation_Code" runat="server" Width="175px" MaxLength="4" autocomplete="off"
                                                            onKeyPress="return FormatInteger(event);" onpaste="return false" />
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="drpLocation" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <%--<tr>
                                           <td align="left" valign="top">
                                                Company Phone
                                            </td>
                                            <td align="center" valign="top">
                                                :
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:TextBox ID="txtCompany_Phone" runat="server" Width="170px" MaxLength="12" onpaste="return false;"
                                                    SkinID="txtPhone" />
                                                <asp:RegularExpressionValidator ID="revPhone" ControlToValidate="txtCompany_Phone"
                                                    runat="server" SetFocusOnError="true" ErrorMessage="Please Enter valid Company Phone No"
                                                    Display="none" ValidationGroup="vsErrorGroup" ValidationExpression="[0-9\-\(\)]+"></asp:RegularExpressionValidator>
                                            </td>
                                            <td align="left" valign="top" colspan="3">
                                            </td>
                                        </tr>--%>
                                        <%-- <tr>
                                            <td align="left" valign="top">
                                                State
                                            </td>
                                            <td align="center" valign="top">
                                                :
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:DropDownList ID="drpState" runat="server" Width="175px">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left" valign="top">
                                                City
                                            </td>
                                            <td align="center" valign="top">
                                                :
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:TextBox ID="txtCity" MaxLength="100" runat="server" Width="170px"></asp:TextBox>
                                            </td>

                                            
                                        </tr>--%>
                                        <%--<tr>
                                          <td align="left" valign="top">
                                                Region
                                            </td>
                                            <td align="center" valign="top">
                                                :
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:DropDownList ID="drpRegion" runat="server" Width="175px">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left" valign="top">
                                                County
                                            </td>
                                            <td align="center" valign="top">
                                                :
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:TextBox ID="txtCounty" MaxLength="50" runat="server" Width="170px"></asp:TextBox>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td align="left" valign="top">Camera Number
                                            </td>
                                            <td align="center" valign="top">:
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:TextBox ID="txtCameraNumber" MaxLength="30" runat="server" Width="170px"></asp:TextBox>
                                            </td>
                                            <td align="left" valign="top">Camera Type
                                            </td>
                                            <td align="center" valign="top">:
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:DropDownList ID="drpCameraType" runat="server" Width="175px" SkinID="dropGen">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">Date Scheduled
                                            </td>
                                            <td align="center" valign="top">:
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:TextBox ID="txtdate_Scheduled" runat="server" SkinID="txtDate" />
                                                <asp:TextBox ID="txtCurrentDate" runat="server" Width="180px" MaxLength="10" Style="display: none;"></asp:TextBox>
                                                <img alt="Scheduled Date" onclick="return showCalendar('<%= txtdate_Scheduled.ClientID %>', 'mm/dd/y');"
                                                    onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                    align="middle" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="vsErrorGroup"
                                                    Display="none" ErrorMessage="Scheduled Date is not a valid date" SetFocusOnError="true"
                                                    ControlToValidate="txtdate_Scheduled" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                <asp:CompareValidator ID="cmpvalid" runat="server" ErrorMessage="Date Sheduled should be less than or equal to current date"
                                                    Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToCompare="txtCurrentDate"
                                                    ControlToValidate="txtdate_Scheduled" Type="Date" Operator="LessThanEqual"></asp:CompareValidator>
                                            </td>
                                            <td align="left" valign="top">Date Completed
                                            </td>
                                            <td align="center" valign="top">:
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:TextBox ID="txtDate_Completed" runat="server" SkinID="txtDate" />
                                                <img alt="Completed Date" onclick="return showCalendar('<%= txtDate_Completed.ClientID %>', 'mm/dd/y');"
                                                    onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                    align="middle" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="vsErrorGroup"
                                                    Display="none" ErrorMessage="Completed Date is not a valid date" SetFocusOnError="true"
                                                    ControlToValidate="txtDate_Completed" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Date Completed should be less than or equal to current date"
                                                    Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToCompare="txtCurrentDate"
                                                    ControlToValidate="txtDate_Completed" Type="Date" Operator="LessThanEqual"></asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">Sonic Task
                                            </td>
                                            <td align="center" valign="top">:
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:DropDownList ID="drpClientIssue" runat="server" Width="175px" SkinID="dropGen">
                                                    <asp:ListItem Selected="True" Value="0" Text="--Select--"></asp:ListItem>
                                                    <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                    <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left" valign="top">ACI Task
                                            </td>
                                            <td align="center" valign="top">:
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:DropDownList ID="drpFacilitiesIssue" runat="server" Width="175px" SkinID="dropGen">
                                                    <asp:ListItem Selected="True" Value="0" Text="--Select--"></asp:ListItem>
                                                    <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                    <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">Cost
                                            </td>
                                            <td align="center" valign="top">:
                                            </td>
                                            <td align="left" valign="top">$<asp:TextBox ID="txtCost" autocomplete="off" onpaste="return false;" runat="server" Width="165px" onkeypress="javascript:return FormatNumber(event,this.id,12,false,true);" />
                                            </td>
                                            <td align="left" valign="top">CR Approved
                                            </td>
                                            <td align="center" valign="top">:
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:TextBox ID="txtCR_Approved" runat="server" SkinID="txtDate" />
                                                <img alt="CR Approved Date" onclick="return showCalendar('<%= txtCR_Approved.ClientID %>', 'mm/dd/y');"
                                                    onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                    align="middle" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="vsErrorGroup"
                                                    Display="none" ErrorMessage="CR Approved Date is not a valid date" SetFocusOnError="true"
                                                    ControlToValidate="txtCR_Approved" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="CR Approved should be less than or equal to current date"
                                                    Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToCompare="txtCurrentDate"
                                                    ControlToValidate="txtCR_Approved" Type="Date" Operator="LessThanEqual"></asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">Task Complete?
                                            </td>
                                            <td align="center" valign="top">:
                                            </td>
                                            <td align="left" valign="top" colspan="4">
                                                <asp:RadioButtonList ID="rblTask_Complete" runat="server">
                                                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="0" Selected="True"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">Camera Concern<span class="mf">*</span>
                                            </td>
                                            <td align="center" valign="top">:
                                            </td>
                                            <td align="left" valign="top" colspan="4">
                                                <uc:ctrlMultiLineTextBox ID="ctrlCameraConcern" runat="server" IsRequired="true"
                                                    ValidationGroup="vsErrorGroup" RequiredFieldMessage="Please Enter Camera Concern" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">Recommendation<span class="mf">*</span>
                                            </td>
                                            <td align="center" valign="top">:
                                            </td>
                                            <td align="left" valign="top" colspan="4">
                                                <uc:ctrlMultiLineTextBox ID="ctrlRecommendation" runat="server" IsRequired="true"
                                                    ValidationGroup="vsErrorGroup" RequiredFieldMessage="Please Enter Recommendation" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">&nbsp;</td>
                                        </tr>
                                        <tr runat="server" id="trstoreGrid">
                                            <td align="left" valign="top">
                                                <b>Store Contact</b>
                                            </td>
                                            <td align="center" valign="top">
                                                <b>:</b>
                                            </td>
                                            <td align="left" valign="top" colspan="4">
                                                <table width="100%">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:GridView ID="gvStoreContact" runat="server" Width="90%" AutoGenerateColumns="false"
                                                                PageSize="10" EnableViewState="true" AllowPaging="true" OnRowCommand="gvStoreContact_RowCommand"
                                                                OnPageIndexChanging="gvStoreContact_PageIndexChanging" OnRowDataBound="gvStoreContact_RowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="First Name">
                                                                        <ItemStyle Width="20%" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("First_Name")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Last Name">
                                                                        <ItemStyle Width="20%" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Last_name")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Phone">
                                                                        <ItemStyle Width="20%" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Phone")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Email">
                                                                        <ItemStyle Width="20%" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Email")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="">
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkEdit" Text=" Edit " CommandName="EditRecord" CommandArgument='<%#Eval("PK_Management_Sonic_Contact") %>'>
                                                                            </asp:LinkButton>
                                                                            &nbsp;&nbsp;&nbsp;
                                                                                    <asp:LinkButton runat="server" ID="lnkDelete" Text=" Delete " OnClientClick="return ConfirmDelete();" CommandName="DeleteRecord" CommandArgument='<%#Eval("PK_Management_Sonic_Contact") %>'>
                                                                                    </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <table cellpadding="4" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                                                                <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding-bottom: 5px;">
                                                            <asp:LinkButton Style="display: inline" ID="lnkAddStoreNew" OnClick="lnkAddStoreNew_Click"
                                                                runat="server" Text="Add New"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                                                    <asp:LinkButton Style="display: none" ID="lnkStoreCancel" OnClick="lnkStoreCancel_Click"
                                                                        runat="server" Text="Cancel"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trstoreContact" style="display: none;">
                                            <td colspan="6">
                                                <table width="100%">
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <b>Store Contact :</b>
                                                        </td>
                                                        <td align="center" valign="top" colspan="5">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">First Name
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtStore_Contact_First_Name" MaxLength="40" runat="server" Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Last Name
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtStore_Contact_Last_Name" MaxLength="40" runat="server" Width="170px"></asp:TextBox>
                                                            <asp:Button ID="btnStore_Contact" runat="server" Text="V" OnClientClick="javascript: return OpenAssociateName();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Phone
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtStore_Contact_Phone" runat="server" Width="170px" SkinID="txtPhone" MaxLength="12" autocomplete="off"
                                                                onpaste="return false"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revtxtCell_phone" ControlToValidate="txtStore_Contact_Phone"
                                                                runat="server" ErrorMessage="Please Enter Store Contact Phone in XXX-XXX-XXXX format."
                                                                Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"
                                                                ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">Email
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtStore_Contact_Email" runat="server" Width="170px" MaxLength="100"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revtxtStore_Contact_Email" runat="server" ControlToValidate="txtStore_Contact_Email"
                                                                Display="None" ErrorMessage="Store contact Email Address is not valid" SetFocusOnError="True"
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"></td>
                                                        <td align="center"></td>
                                                        <td align="left" colspan="4">
                                                            <asp:Button ID="btnStoreAdd" OnClick="btnStoreAdd_Click" runat="server" ValidationGroup="vsErrorGroup"
                                                                Text="Add" Width="70px"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:Button ID="btnStoreCancel" OnClick="lnkStoreCancel_Click" runat="server" Text="Cancel" Width="70px"></asp:Button>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">&nbsp;</td>
                                        </tr>
                                        <tr runat="server" id="trACIGrid">
                                            <td align="left" valign="top">
                                                <b>ACI Contact</b>
                                            </td>
                                            <td align="center" valign="top">
                                                <b>:</b>
                                            </td>
                                            <td align="left" valign="top" colspan="4">
                                                <table width="100%">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:GridView ID="gvACIContact" runat="server" Width="90%" AutoGenerateColumns="false"
                                                                PageSize="10" EnableViewState="true" AllowPaging="true" OnRowCommand="gvACIContact_RowCommand"
                                                                OnPageIndexChanging="gvACIContact_PageIndexChanging" OnRowDataBound="gvACIContact_RowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="First Name">
                                                                        <ItemStyle Width="20%" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("First_Name")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Last Name">
                                                                        <ItemStyle Width="20%" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Last_name")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Phone">
                                                                        <ItemStyle Width="20%" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Phone")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Email">
                                                                        <ItemStyle Width="20%" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Email")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="">
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkEdit" Text=" Edit " CommandName="EditRecord" CommandArgument='<%#Eval("PK_Management_ACI_Contact") %>'>
                                                                            </asp:LinkButton>
                                                                            &nbsp;&nbsp;&nbsp;
                                                                                    <asp:LinkButton runat="server" ID="lnkDelete" Text=" Delete " OnClientClick="return ConfirmDelete();" CommandName="DeleteRecord" CommandArgument='<%#Eval("PK_Management_ACI_Contact") %>'>
                                                                                    </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <table cellpadding="4" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                                                                <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding-bottom: 5px;">
                                                            <asp:LinkButton Style="display: inline" ID="lnkAddACINew" OnClick="lnkAddACINew_Click"
                                                                runat="server" Text="Add New"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                                                    <asp:LinkButton Style="display: none" ID="lnkACICancel" OnClick="lnkACICancel_Click"
                                                                        runat="server" Text="Cancel"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trACIContact" style="display: none;">
                                            <td colspan="6">
                                                <table width="100%">
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <b>ACI Contact :</b>
                                                        </td>
                                                        <td align="center" valign="top" colspan="5">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">First Name
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtAci_Contact_First_Name" MaxLength="40" runat="server" Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Last Name
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtAci_Contact_Last_Name" MaxLength="40" runat="server" Width="170px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Phone
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtAci_Contact_Phone" runat="server" Width="170px" SkinID="txtPhone" MaxLength="12" autocomplete="off"
                                                                onpaste="return false"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revtxtAci_Contact_Phone" ControlToValidate="txtAci_Contact_Phone"
                                                                runat="server" ErrorMessage="Please Enter ACI Contact Phone in XXX-XXX-XXXX format."
                                                                Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"
                                                                ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">Email
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtAci_Contact_Email" runat="server" Width="170px" MaxLength="100"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revtxtAci_Contact_Email" runat="server" ControlToValidate="txtAci_Contact_Email"
                                                                Display="None" ErrorMessage="ACI contact Email Address is not valid" SetFocusOnError="True"
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"></td>
                                                        <td align="center"></td>
                                                        <td align="left" colspan="4">
                                                            <asp:Button ID="btnACIAdd" OnClick="btnACIAdd_Click" runat="server" ValidationGroup="vsErrorGroup"
                                                                Text="Add" Width="70px"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:Button ID="btnACICancel" OnClick="lnkACICancel_Click" runat="server" Text="Cancel" Width="70px"></asp:Button>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </div>
                            <div id="dvView" runat="server" width="993px">
                                <asp:Panel ID="pnlView" runat="server" Style="display: none;" Width="993px">
                                    <div class="bandHeaderRow">
                                        Management
                                    </div>
                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                        <tr>
                                            <td style="height: 5px" colspan="6"></td>
                                        </tr>
                                        <tr>
                                            <%--<td align="left" width="18%" valign="top">
                                                Company
                                            </td>
                                            <td align="center" width="4%" valign="top">
                                                :
                                            </td>
                                            <td align="left" width="28%" valign="top">
                                                <asp:Label ID="lblCompany" runat="server"></asp:Label>
                                            </td>--%>
                                            <td align="left" width="18%" valign="top">DBA
                                            </td>
                                            <td align="center" width="4%" valign="top">:
                                            </td>
                                            <td align="left" width="28%" valign="top">
                                                <asp:Label ID="lblLocation" runat="server"></asp:Label>
                                            </td>
                                            <td align="left" width="18%" valign="top">Location Code
                                            </td>
                                            <td align="center" width="4%" valign="top">:
                                            </td>
                                            <td align="left" width="28%" valign="top">
                                                <asp:Label ID="lblLocation_Code" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <%--  <tr>
                                            <td align="left" valign="top">
                                                Company Phone
                                            </td>
                                            <td align="center" valign="top">
                                                :
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:Label ID="lblCompany_Phone" runat="server"></asp:Label>
                                            </td>
                                            <td align="left" valign="top" colspan="3">
                                            </td>
                                        </tr>--%>
                                        <%-- <tr>
                                            <td align="left" valign="top">
                                                State
                                            </td>
                                            <td align="center" valign="top">
                                                :
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:Label ID="lblState" runat="server"></asp:Label>
                                            </td>
                                            <td align="left" valign="top">
                                                City
                                            </td>
                                            <td align="center" valign="top">
                                                :
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:Label ID="lblCity" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                Region
                                            </td>
                                            <td align="center" valign="top">
                                                :
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:Label ID="lblRegion" runat="server"></asp:Label>
                                            </td>
                                            <td align="left" valign="top">
                                                County
                                            </td>
                                            <td align="center" valign="top">
                                                :
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:Label ID="lblCounty" runat="server"></asp:Label>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td align="left" valign="top">Camera Number
                                            </td>
                                            <td align="center" valign="top">:
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:Label ID="lblCameraNumber" runat="server"></asp:Label>
                                            </td>
                                            <td align="left" valign="top" width="18%">Camera Type
                                            </td>
                                            <td align="center" valign="top" width="4%">:
                                            </td>
                                            <td align="left" valign="top" width="28%">
                                                <asp:Label ID="lblCameraType" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">Date Scheduled
                                            </td>
                                            <td align="center" valign="top">:
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:Label ID="lblDateScheduled" runat="server"></asp:Label>
                                            </td>
                                            <td align="left" valign="top">Date Completed
                                            </td>
                                            <td align="center" valign="top">:
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:Label ID="lblDateComleted" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">Client Issue
                                            </td>
                                            <td align="center" valign="top">:
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:Label ID="lblClientIssue" runat="server"></asp:Label>
                                            </td>
                                            <td align="left" valign="top">Facilities Issue
                                            </td>
                                            <td align="center" valign="top">:
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:Label ID="lblFacilitiesIssue" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">Cost
                                            </td>
                                            <td align="center" valign="top">:
                                            </td>
                                            <td align="left" valign="top">$<asp:Label runat="server" ID="lblCost"></asp:Label>
                                            </td>
                                            <td align="left" valign="top">CR Approved
                                            </td>
                                            <td align="center" valign="top">:
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:Label ID="lblCRApproved" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">Task Complete?
                                            </td>
                                            <td align="center" valign="top">:
                                            </td>
                                            <td align="left" valign="top" colspan="4">
                                                <asp:Label runat="server" ID="lblTask_Complete"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">Camera Concern
                                            </td>
                                            <td align="center" valign="top">:
                                            </td>
                                            <td align="left" valign="top" colspan="4">
                                                <uc:ctrlMultiLineTextBox ID="lblCameraConcern" runat="server" ControlType="Label" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">Recommendation
                                            </td>
                                            <td align="center" valign="top">:
                                            </td>
                                            <td align="left" valign="top" colspan="4">
                                                <uc:ctrlMultiLineTextBox ID="lblRecommendation" runat="server" ControlType="Label" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">&nbsp;</td>
                                        </tr>
                                        <tr runat="server" id="trgridstoreview">
                                            <td align="left" valign="top">
                                                <b>Store Contact</b>
                                            </td>
                                            <td align="center" valign="top">
                                                <b>:</b>
                                            </td>
                                            <td align="left" valign="top" colspan="4">
                                                <table width="100%">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:GridView ID="gvStoreContactView" runat="server" Width="90%" AutoGenerateColumns="false"
                                                                PageSize="10" EnableViewState="true" AllowPaging="true">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="First Name">
                                                                        <ItemStyle Width="20%" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("First_Name")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Last Name">
                                                                        <ItemStyle Width="20%" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Last_name")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Phone">
                                                                        <ItemStyle Width="20%" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Phone")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Email">
                                                                        <ItemStyle Width="20%" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Email")%>&nbsp;
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <table cellpadding="4" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                                                                <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <%-- <tr>
                                            <td colspan="6">
                                                <b>Store Contact :</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">First Name
                                            </td>
                                            <td align="center" valign="top">:
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:Label ID="lblStore_Contact_First_Name" runat="server"></asp:Label>
                                            </td>
                                            <td align="left" valign="top">Last Name
                                            </td>
                                            <td align="center" valign="top">:
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:Label ID="lblStore_Contact_Last_Name" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">Phone
                                            </td>
                                            <td align="center" valign="top">:
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:Label ID="lblStore_Contact_Phone" runat="server"></asp:Label>
                                            </td>
                                            <td align="left" valign="top">Email
                                            </td>
                                            <td align="center" valign="top">:
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:Label ID="lblStore_Contact_Email" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <b>ACI Contact :</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">First Name
                                            </td>
                                            <td align="center" valign="top">:
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:Label ID="lblAci_Contact_First_Name" runat="server"></asp:Label>
                                            </td>
                                            <td align="left" valign="top">Last Name
                                            </td>
                                            <td align="center" valign="top">:
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:Label ID="lblAci_Contact_Last_Name" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">Phone
                                            </td>
                                            <td align="center" valign="top">:
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:Label ID="lblAci_Contact_Phone" runat="server"></asp:Label>
                                            </td>
                                            <td align="left" valign="top">Email
                                            </td>
                                            <td align="center" valign="top">:
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:Label ID="lblAci_Contact_Email" runat="server"></asp:Label>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td colspan="6">&nbsp;
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trgridACIview">
                                            <td align="left" valign="top">
                                                <b>ACI Contact</b>
                                            </td>
                                            <td align="center" valign="top">
                                                <b>:</b>
                                            </td>
                                            <td align="left" valign="top" colspan="4">
                                                <table width="100%">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:GridView ID="gvACIContactView" runat="server" Width="90%" AutoGenerateColumns="false"
                                                                PageSize="10" EnableViewState="true" AllowPaging="true">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="First Name">
                                                                        <ItemStyle Width="20%" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("First_Name")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Last Name">
                                                                        <ItemStyle Width="20%" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Last_name")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Phone">
                                                                        <ItemStyle Width="20%" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Phone")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Email">
                                                                        <ItemStyle Width="20%" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Email")%>&nbsp;
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <table cellpadding="4" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                                                                <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnSave" runat="server" Text="Save" CausesValidation="true" ValidationGroup="vsErrorGroup"
                                OnClick="btnSave_Click" />
                            <asp:Button ID="btnEdit" runat="server" Text=" Edit " CausesValidation="false" OnClick="btnEdit_Click"
                                Visible="false" />
                            &nbsp; &nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false"
                                OnClick="btnCancel_Click" />
                            &nbsp; &nbsp;
                            <asp:Button ID="btnViewAudit" runat="server" Text="View Audit Trail" CausesValidation="false"
                                Visible="false" OnClientClick="javascript:return AuditPopUp();" ToolTip="View Audit Trail" />
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

    <script type="text/javascript">

        var GB_ROOT_DIR = '<%=AppConfig.SiteURL%>' + 'greybox/';
        function OpenAssociateName() {
            var pk_Location = document.getElementById('<%=drpLocation.ClientID %>')
              if (pk_Location.selectedIndex > 0)
                  GB_showCenter('Employee Name', '<%=AppConfig.SiteURL%>Management/EmployeePopup.aspx?pk=' + pk_Location.value, 500, 500, '');
              else
                  alert('Please select DBA');
              return false;
          }

    </script>

    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/gb_scripts.js"></script>
</asp:Content>
