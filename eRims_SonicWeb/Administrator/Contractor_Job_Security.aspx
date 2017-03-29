<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="Contractor_Job_Security.aspx.cs" Inherits="Administrator_Contractor_Job_Security" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/NotesWithSpellCheck/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>

    <script type="text/javascript" src="<%=AppConfig.SiteURL%>JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript">        
        $(function () {
            var rdoLstLocationAccess = document.getElementById("ctl00_ContentPlaceHolder1_rdoLocationAccess");
            var rdoLstProjectAccess = document.getElementById("ctl00_ContentPlaceHolder1_rdoProjectAccess");
            var rdos = rdoLstLocationAccess.getElementsByTagName("input");
            for (var i = 0; i < rdos.length; i++) {
                rdos[i].disabled = true;
            }
            document.getElementById("ctl00_ContentPlaceHolder1_lstLocations").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_rfvLocations").style.visibility = "hidden";
            document.getElementById("ctl00_ContentPlaceHolder1_rfvLocations").enabled = false;
            document.getElementById("ctl00_ContentPlaceHolder1_revLocationAccess").style.visibility = "hidden";
            document.getElementById("ctl00_ContentPlaceHolder1_revLocationAccess").enabled = false;

            rdos = rdoLstProjectAccess.getElementsByTagName("input");
            for (var i = 0; i < rdos.length; i++) {
                rdos[i].disabled = true;
            }
            document.getElementById("ctl00_ContentPlaceHolder1_lstProjects").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_rfvProjects").style.visibility = "hidden";
            document.getElementById("ctl00_ContentPlaceHolder1_rfvProjects").enabled = false;
            document.getElementById("ctl00_ContentPlaceHolder1_revProjectAccess").style.visibility = "hidden";
            document.getElementById("ctl00_ContentPlaceHolder1_revProjectAccess").enabled = false;
        });
        function EnableDisableContent() {
            var rdoLstLocationAccess = document.getElementById("ctl00_ContentPlaceHolder1_rdoLocationAccess");
            var rdoLstProjectAccess = document.getElementById("ctl00_ContentPlaceHolder1_rdoProjectAccess");
            if (document.getElementById("ctl00_ContentPlaceHolder1_chkBoxProject").checked) {
                rdos = rdoLstProjectAccess.getElementsByTagName("input");
                rdos = rdoLstProjectAccess.getElementsByTagName("input");
                for (var i = 0; i < rdos.length; i++) {
                    rdos[i].disabled = false;
                }
                document.getElementById("ctl00_ContentPlaceHolder1_rdoProjectAccess").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_lstProjects").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_rfvProjects").style.visibility = "visible";
                document.getElementById("ctl00_ContentPlaceHolder1_rfvProjects").enabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_revProjectAccess").style.visibility = "visible";
                document.getElementById("ctl00_ContentPlaceHolder1_revProjectAccess").enabled = true;
            }
            else {
                rdos = rdoLstProjectAccess.getElementsByTagName("input");
                for (var i = 0; i < rdos.length; i++) {
                    rdos[i].disabled = true;
                }
                document.getElementById("ctl00_ContentPlaceHolder1_lstProjects").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_rfvProjects").style.visibility = "hidden";
                document.getElementById("ctl00_ContentPlaceHolder1_rfvProjects").enabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_revProjectAccess").style.visibility = "hidden";
                document.getElementById("ctl00_ContentPlaceHolder1_revProjectAccess").enabled = false;
            }
            if (document.getElementById("ctl00_ContentPlaceHolder1_chkBoxLocation").checked) {                
                rdos = rdoLstLocationAccess.getElementsByTagName("input");
                for (var i = 0; i < rdos.length; i++) {
                    rdos[i].disabled = false;
                }
                document.getElementById("ctl00_ContentPlaceHolder1_lstLocations").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_rfvLocations").style.visibility = "visible";
                document.getElementById("ctl00_ContentPlaceHolder1_rfvLocations").enabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_revLocationAccess").style.visibility = "visible";
                document.getElementById("ctl00_ContentPlaceHolder1_revLocationAccess").enabled = true;
            }
            else {
                rdos = rdoLstLocationAccess.getElementsByTagName("input");
                for (var i = 0; i < rdos.length; i++) {
                    rdos[i].disabled = true;
                }
                document.getElementById("ctl00_ContentPlaceHolder1_lstLocations").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_rfvLocations").style.visibility = "hidden";
                document.getElementById("ctl00_ContentPlaceHolder1_rfvLocations").enabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_revLocationAccess").style.visibility = "hidden";
                document.getElementById("ctl00_ContentPlaceHolder1_revLocationAccess").enabled = false;
            }
        }
        function OpenAuditPopUp() {
            var winHeight = window.screen.availHeight - 400;
            var winWidth = window.screen.availWidth - 900;

            obj = window.open('AuditPopup_Contractor_Job_Security.aspx?id=<%=ViewState["PK_Contractor_Job_Security"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }
        function Validate() {
            //  var el = document.getElementById('').selectedIndex;
            //  if (el == 0) {
            //      alert("Please Select Location");
            //      return false;
            //  }
            //  else {
            //      var ep = document.getElementById('').selectedIndex;
            //      if (ep == 0) {
            //          alert("Please Select Project Number");
            //          return false;
            //      }
            //      else {
            //          return true;
            //      }
            //  }

        }
    </script>

    <table cellpadding="0" cellspacing="0" width="100%">

        <tr>
            <td align="left" class="Spacer"></td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="2"></td>
                    </tr>
                    <tr>
                        <td class="bandHeaderRow" align="left">Location/Project Access Grid Screen
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 3px;"></td>
                    </tr>
                    <tr>

                        <td valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td width="5px" class="Spacer">&nbsp;
                                    </td>

                                    <td class="dvContainer">
                                        <div id="dvEdit" runat="server" width="100%">
                                            <%--<asp:Panel ID="pnl1" runat="server" Style="display: inline;">--%>
                                            <%--<div class="bandHeaderRow">
                                                    Location/Project Access Grid Screen</div>--%>
                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                <tr>
                                                    <td align="left" valign="top" colspan="3">
                                                        <asp:CheckBox ID="chkBoxProject" runat="server" Text="Projects" onclick="EnableDisableContent();" />

                                                    </td>
                                                    <td align="left" valign="top" colspan="2">
                                                        <asp:CheckBox ID="chkBoxLocation" runat="server" Text="Sonic Location Code" onclick="EnableDisableContent();" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" valign="top">:
                                                    </td>
                                                    <td align="left" colspan="2" valign="top">
                                                        <asp:ListBox runat="server" ID="lstProjects" Width="300px" Height="150px" SelectionMode="Multiple"></asp:ListBox>
                                                        <asp:RequiredFieldValidator runat="server" ID="rfvProjects" ControlToValidate="lstProjects"
                                                            ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="Please select at least one Projects."></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td align="left" colspan="2" valign="top">
                                                        <asp:ListBox runat="server" ID="lstLocations" Width="300px" Height="150px" SelectionMode="Multiple"></asp:ListBox>
                                                        <asp:RequiredFieldValidator runat="server" ID="rfvLocations" ControlToValidate="lstLocations"
                                                            ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="Please select at least one Locations."></asp:RequiredFieldValidator>
                                                    </td>
                                                    <%--<td align="left" valign="top">&nbsp;
                                                    </td>
                                                    <td align="center" valign="top">&nbsp;
                                                    </td>
                                                    <td align="left" valign="top">&nbsp;
                                                    </td>--%>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="1" valign="top">Access&nbsp;<span id="Span5" style="color: Red;" runat="server">*</span> :
                                                    </td>
                                                    <%--<td align="center" valign="top">:
                                                    </td>--%>
                                                    <td align="left" colspan="2" valign="top">
                                                        <asp:RadioButtonList ID="rdoProjectAccess" runat="server">
                                                            <asp:ListItem Text="Read Only" Value="R"></asp:ListItem>
                                                            <asp:ListItem Text="Read/Write" Value="RW"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                        <asp:RequiredFieldValidator ID="revProjectAccess" runat="server" ValidationGroup="vsErrorGroup"
                                                            ErrorMessage="Please check Project Access?" Text="*" Display="None"
                                                            ControlToValidate="rdoProjectAccess"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td align="left" colspan="2" valign="top">
                                                        <asp:RadioButtonList ID="rdoLocationAccess" runat="server">
                                                            <asp:ListItem Text="Read Only" Value="R"></asp:ListItem>
                                                            <asp:ListItem Text="Read/Write" Value="RW"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                        <asp:RequiredFieldValidator ID="revLocationAccess" runat="server" ValidationGroup="vsErrorGroup"
                                                            ErrorMessage="Please check Location Access?" Text="*" Display="None"
                                                            ControlToValidate="rdoLocationAccess"></asp:RequiredFieldValidator>
                                                    </td>

                                                    <%--<td align="left" valign="top">&nbsp;
                                                    </td>
                                                    <td align="center" valign="top">&nbsp;
                                                    </td>
                                                    <td align="left" valign="top">&nbsp;
                                                    </td>--%>
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
                                        <div id="dvView" runat="server" width="100%">
                                            <%--<div class="bandHeaderRow">
                                                    Location/Project Access Grid Screen</div>--%>
                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                <tr>
                                                    <%--<td align="left" width="18%" valign="top">Location
                                                    </td>
                                                    <td align="center" width="4%" valign="top">:
                                                    </td>
                                                    <td align="left" width="28%" valign="top">
                                                        <asp:Label ID="lblLocation" runat="server"></asp:Label>
                                                    </td>--%>
                                                    <td colspan="2" align="left" width="18%" valign="top">Project Number
                                                    </td>
                                                    <td align="center" width="4%" valign="top">:
                                                    </td>
                                                    <td colspan="3" align="left" width="28%" valign="top">
                                                        <asp:Label ID="lblProject_Number" runat="server" Style="word-wrap: normal; word-break: break-all"></asp:Label>
                                                    </td>
                                                </tr>
                                                <%--   <tr>
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
                                                </tr>--%>
                                                <%--  <tr>
                                                    <td align="left" valign="top">Project Description
                                                    </td>
                                                    <td align="center" valign="top">:
                                                    </td>
                                                    <td align="left" valign="top" colspan="4">
                                                        <%--<asp:Label ID="lblProject_Description" style="word-wrap:normal;word-break:break-all" runat="server"></asp:Label>
                                                        <uc:ctrlMultiLineTextBox ControlType="Label" ID="lblProject_Description" runat="server" />
                                                    </td>
                                                    <td align="left" valign="top">&nbsp;
                                                    </td>
                                                    <td align="center" valign="top">&nbsp;
                                                    </td>
                                                    <td align="left" valign="top">&nbsp;
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td align="left" colspan="2" valign="top">Access
                                                    </td>
                                                    <td align="center" valign="top">:
                                                    </td>
                                                    <td align="left" colspan="3" valign="top">
                                                        <asp:Label ID="lblAccess" runat="server"></asp:Label>
                                                    </td>
                                                    <%-- <td align="left" valign="top"></td>
                                                    <td align="center" valign="top"></td>
                                                    <td align="left" valign="top"></td>--%>
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
                                            <asp:Button ID="btnSave" runat="server" Text="Save & Continue" OnClick="btnSave_Click"
                                                CausesValidation="true" ValidationGroup="vsErrorGroup" />
                                            <asp:Button ID="btnEdit" runat="server" Text=" Edit " OnClick="btnEdit_Click" />
                                            <%--<asp:Button runat="server" ID="btnAuditTrail" Text="View Audit Trail" CausesValidation="false"
                                                Visible="true" OnClientClick="javascript:return OpenAuditPopUp();" />--%>
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

