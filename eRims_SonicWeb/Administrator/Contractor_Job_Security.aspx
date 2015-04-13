<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="Contractor_Job_Security.aspx.cs" Inherits="Administrator_Contractor_Job_Security" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript">
        function OpenAuditPopUp() {
            var winHeight = window.screen.availHeight - 400;
            var winWidth = window.screen.availWidth - 500;

            obj = window.open('AuditPopup_Contractor_Job_Security.aspx?id=<%=ViewState["PK_Contractor_Job_Security"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }
    </script>

    <table cellpadding="0" cellspacing="0" width="100%">

        <tr>
            <td class="ghc" align="left">Location/Project Access Grid Screen
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="2"></td>
                    </tr>
                    <tr>

                        <td valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td width="5px" class="Spacer">&nbsp;
                                    </td>
                                    <td class="dvContainer">
                                        <div id="dvEdit" runat="server" width="794px">
                                            <%--<asp:Panel ID="pnl1" runat="server" Style="display: inline;">--%>
                                            <%--<div class="bandHeaderRow">
                                                    Location/Project Access Grid Screen</div>--%>
                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                <tr>
                                                    <td align="left" width="18%" valign="top">Location&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                    </td>
                                                    <td align="center" width="4%" valign="top">:
                                                    </td>
                                                    <td align="left" width="28%" valign="top">
                                                        <asp:DropDownList ID="ddlLocation" Width="175px" runat="server" AutoPostBack="true" SkinID="dropGen" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="left" width="18%" valign="top">Project Number&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                    </td>
                                                    <td align="center" width="4%" valign="top">:
                                                    </td>
                                                    <td align="left" width="28%" valign="top">
                                                        <asp:DropDownList ID="ddlProjectNumber" Width="175px" AutoPostBack="true" runat="server" SkinID="dropGen" OnSelectedIndexChanged="ddlProjectNumber_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top">Project Start Date&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                    </td>
                                                    <td align="center" valign="top">:
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <asp:TextBox ID="txtProject_Start_Date" runat="server" Width="170px" SkinID="txtDate" MaxLength="10"></asp:TextBox>
                                                        <img alt="Date of Hire" onclick="return showCalendar('<%= txtProject_Start_Date.ClientID %>', 'mm/dd/y');"
                                                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                            align="middle" id="img1" /><br />
                                                        <asp:RegularExpressionValidator ID="rvProject_Start_Date" runat="server" ControlToValidate="txtProject_Start_Date"
                                                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                            ErrorMessage="Project Start Date is Not Valid Date." Display="none" SetFocusOnError="true">
                                                        </asp:RegularExpressionValidator>
                                                    </td>
                                                    <td align="left" valign="top">&nbsp;
                                                    </td>
                                                    <td align="center" valign="top">&nbsp;
                                                    </td>
                                                    <td align="left" valign="top">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top">Project Description&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                    </td>
                                                    <td align="center" valign="top">:
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <asp:TextBox ID="txtProject_Description" runat="server" Width="170px" MaxLength="100" TextMode="MultiLine" />
                                                    </td>
                                                    <td align="left" valign="top">&nbsp;
                                                    </td>
                                                    <td align="center" valign="top">&nbsp;
                                                    </td>
                                                    <td align="left" valign="top">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top">Project Description&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                    </td>
                                                    <td align="center" valign="top">:
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <asp:RadioButtonList ID="rdoAccess" runat="server">
                                                            <asp:ListItem Text="Read Only" Value="R"></asp:ListItem>
                                                            <asp:ListItem Text="Read/Write" Value="RW"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td align="left" valign="top">&nbsp;
                                                    </td>
                                                    <td align="center" valign="top">&nbsp;
                                                    </td>
                                                    <td align="left" valign="top">&nbsp;
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td colspan="6">
                                                        <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <%--</asp:Panel>--%>
                                            <%--<asp:Panel ID="pnl2" runat="server" Style="display: inline;">
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="100%">
                                                            <uc:ctrlAttachment ID="Attachment" runat="Server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Spacer" style="height: 20px;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div id="dvAttachment" runat="server" style="display: none;">
                                                                <uc:ctrlAttachmentDetails ID="AttachDetails" runat="Server" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Spacer" style="height: 20px;">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>--%>
                                        </div>
                                        <div id="dvView" runat="server" width="794px">
                                            <%--<div class="bandHeaderRow">
                                                    Location/Project Access Grid Screen</div>--%>
                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                <tr>
                                                    <td align="left" width="18%" valign="top">Location
                                                    </td>
                                                    <td align="center" width="4%" valign="top">:
                                                    </td>
                                                    <td align="left" width="28%" valign="top">
                                                        <asp:Label ID="lblLocation" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="left" width="18%" valign="top">Project Number
                                                    </td>
                                                    <td align="center" width="4%" valign="top">:
                                                    </td>
                                                    <td align="left" width="28%" valign="top">
                                                        <asp:Label ID="lblProject_Number" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top">Project Start Date
                                                    </td>
                                                    <td align="center" valign="top">:
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <asp:Label ID="lblProject_Start_Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="top">&nbsp;
                                                    </td>
                                                    <td align="center" valign="top">&nbsp;
                                                    </td>
                                                    <td align="left" valign="top">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top">Project Description
                                                    </td>
                                                    <td align="center" valign="top">:
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <asp:Label ID="lblProject_Description" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="top">&nbsp;
                                                    </td>
                                                    <td align="center" valign="top">&nbsp;
                                                    </td>
                                                    <td align="left" valign="top">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top">Access
                                                    </td>
                                                    <td align="center" valign="top">:
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <asp:Label ID="lblAccess" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="top"></td>
                                                    <td align="center" valign="top">:
                                                    </td>
                                                    <td align="left" valign="top"></td>
                                                </tr>

                                                <tr>
                                                    <td colspan="6">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6" align="center">&nbsp;
                                                    </td>
                                                </tr>
                                            </table>

                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <div id="dvSave" runat="server">
                                <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td width="60%" align="right">
                                            <asp:Button ID="btnSave" runat="server" Text="Save & View" OnClick="btnSave_Click"
                                                CausesValidation="true" ValidationGroup="vsErrorGroup" />
                                            <asp:Button ID="btnEdit" runat="server" Text=" Edit " OnClick="btnEdit_Click" />
                                            <asp:Button runat="server" ID="btnAuditTrail" Text="View Audit Trail" CausesValidation="false"
                                                Visible="true" OnClientClick="javascript:return OpenAuditPopUp();" />
                                            <asp:Button ID="btnBack" runat="server" Text=" Back " OnClick="btnBack_Click" />
                                        </td>
                                        <td align="left">&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

</asp:Content>

