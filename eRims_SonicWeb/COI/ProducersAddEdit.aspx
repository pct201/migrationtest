<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.master" CodeFile="ProducersAddEdit.aspx.cs"
    Inherits="Admin_ProducersAddEdit" %>

<%@ Register Src="~/Controls/Attachment_COI/Attachment_COI.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_COI/AttachmentDetails_COI.ascx" TagName="ctrlAttachmentDetails"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlNotes" TagPrefix="uc" %>
<%@ Register Src="~/Controls/COIInfo/COIInfo.ascx" TagName="ctrlCOIInfo" TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript">
        function CheckForValidation() {
            if (Page_ClientValidate('vsErrorGroup') == false)
                return false;
            else return true;
        }
        function SetMenuStyle(index) {
            var tb;
            var tbOther;
            if (index == 1) {
                tb = document.getElementById("Menu1");
                tbOther = document.getElementById("Menu2");
            }
            else {
                tb = document.getElementById("Menu2");
                tbOther = document.getElementById("Menu1");
            }
            tb.className = "LeftMenuSelected";
            tb.onmouseover = function () { this.className = 'LeftMenuSelected'; }
            tb.onmouseout = function () { this.className = 'LeftMenuSelected'; }

            tbOther.className = "LeftMenuStatic";
            tbOther.onmouseover = function () { this.className = 'LeftMenuHover'; }
            tbOther.onmouseout = function () { this.className = 'LeftMenuStatic'; }

        }

        function ConfirmDelete() {
            return confirm("Are you sure that you want to remove the data that was selected for deletion?");
        }

        function SetFocusOnFirstControl(index) {
            switch (index) {
                case 1:
                    document.getElementById('ctl00_ContentPlaceHolder1_txtCompany').focus(); break;
                case 2:
                    document.getElementById('ctl00_ContentPlaceHolder1_Attachment_drpAttachType').focus(); break;
                default:
                    break;
            }
        }

        function ShowPanel(index) {

            SetMenuStyle(index);
            var i;

            var op = '<%=StrOperation%>';

            if (op == "view") {

                document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                ShowPanelView(index);
            }
            else {
                document.getElementById('<%=dvEdit.ClientID%>').style.display = "block";
                document.getElementById('<%=btnSave.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnReturn.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnBack.ClientID%>').style.display = "none";

                if (index == 1) {
                    document.getElementById("ctl00_ContentPlaceHolder1_Panel1").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_Div1").style.display = "none";
                    document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                }
                else {
                    document.getElementById("ctl00_ContentPlaceHolder1_Panel1").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_Div1").style.display = "block";
                    document.getElementById("<%=dvAttachment.ClientID%>").style.display = "block";
                }
                SetFocusOnFirstControl(index);
            }
        }

        function ShowPanelView(index) {
            SetMenuStyle(index);
            document.getElementById('<%=dvView.ClientID%>').style.display = "block";
            document.getElementById('<%=btnSave.ClientID%>').style.display = "none";
            document.getElementById('<%=btnReturn.ClientID%>').style.display = "none";
            document.getElementById('<%=btnBack.ClientID%>').style.display = "block";

            if (index == 1) {
                document.getElementById("ctl00_ContentPlaceHolder1_Panel2").style.display = "block";
                document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder1_Panel2").style.display = "none";
                document.getElementById("<%=dvAttachment.ClientID%>").style.display = "block";
            }

        }
        function IfSave() {
            var values = '<%=ViewState["ProducersID"]%>';
            if (values == '' || values == '0') {
                alert('Please Save Producers Record First');
                ShowPanel(1);
                return false;
            }
            else return Page_ClientValidate('AddAttachment');
        }

        function ValSave() {
            if (Page_ClientValidate("vsErrorGroup"))
                return true;
            else
                return false;
        }
        function ShowDialogBox() {

            var w = 480, h = 340;
            var width = 670, height = 500;
            if (document.all || document.layers) {
                w = screen.availWidth;
                h = screen.availHeight;
            }

            var leftPos, topPos;
            var popW = width, popH = height;
            if (document.all)
            { leftPos = (w - popW) / 2; topPos = (h - popH) / 2; }
            else
            { leftPos = w / 2; topPos = h / 2; }
            var QryString = 'Search.aspx?coi=<%=Encryption.Encrypt(FK_COI.ToString())%>&tbl=<%=(int)clsGeneral.Tables.Producers%>'
            window.open(QryString, "popup", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=" + popW + ",height=" + popH + ",top=" + topPos + ",left=" + leftPos);
            return false;
        }

        function ValidateFields(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDs.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgs.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDs.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text": if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                    }
                    if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
                    if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                }
                if (msg.length > 0) {
                    sender.errormessage = msg;
                    args.IsValid = false;
                }
                else
                    args.IsValid = true;
            }
            else {
                args.IsValid = true;
            }
        }
    </script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <div style="width: 100%" id="contmain">
        <table cellpadding="0" cellspacing="0" width="100%" align="left">
            <tr>
                <td style="height: 15px;" class="Spacer" colspan="3">
                </td>
            </tr>
            <tr>
                <td width="100%" colspan="3">
                    <uc:ctrlCOIInfo id="ucCtrlCOIInfo" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 5px;" colspan="3" width="100%">
                </td>
            </tr>
            <tr>
                <td class="leftMenu">
                    <table cellpadding="5" cellspacing="0" width="175px">
                        <tr>
                            <td style="height: 10px;" class="Spacer">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">Producer</span>
                                <span id="MenuAsterisk1" runat="server" style="color:Red;display:none;">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu2" onclick="javascript:ShowPanel(2);" class="LeftMenuStatic">Attachment</span>                                
                            </td>
                        </tr>
                        <%--<tr>
                            <td style="padding-left: 5px;">
                                <asp:Menu ID="mnuRiskProfile" runat="server" Width="100%" DataSourceID="dsPropertyMenu"
                                    StaticEnableDefaultPopOutImage="false">
                                    <StaticItemTemplate>
                                        <table cellpadding="3" cellspacing="2" width="100%">
                                            <tr>
                                                <td align="left" width="100%">
                                                    <span id="mnuRiskProfile<%#Container.ItemIndex+1%>" onclick="javascript:ShowPanel(<%#Container.ItemIndex+1%>);"
                                                        class="LeftMenuStatic">
                                                        <%#Eval("Text")%>
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </StaticItemTemplate>
                                </asp:Menu>
                                <asp:SiteMapDataSource ID="dsPropertyMenu" runat="server" SiteMapProvider="COIProcedureProvider"
                                    ShowStartingNode="false" />
                            </td>
                        </tr>--%>
                        <tr>
                            <td style="height: 10px;" class="Spacer">
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 5px;" class="Spacer">
                    &nbsp;
                </td>
                <td valign="top" width="100%">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td class="dvContainer">
                                <div id="dvEdit" runat="server" style="display: none">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td class="tblGrid" align="left">
                                                <asp:Panel ID="Panel1" runat="server" Style="display: block; height: 100%">
                                                    <div class="bandHeaderRow">
                                                        Producers</div>
                                                    <table cellpadding="3" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td colspan="7">
                                                                <asp:LinkButton ID="btnFind" runat="server" Text="Find" OnClientClick="javascript:return ShowDialogBox()" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="18%" align="left">
                                                                Company&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td width="2%" align="center">
                                                                :
                                                            </td>
                                                            <td width="26%" align="left">
                                                                <asp:TextBox ID="txtCompany" Width="200px" runat="server" MaxLength="254" TabIndex="1"></asp:TextBox>
                                                                <%--<asp:RequiredFieldValidator ID="rfvCompany" runat="server" ValidationGroup="vsErrorGroup"
                                                                    ErrorMessage="Please Enter [Producers]/Company" ControlToValidate="txtCompany"
                                                                    Display="None" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                                                            </td>
                                                            <td width="2%">
                                                                &nbsp;
                                                            </td>
                                                            <td width="18%" align="left">
                                                                Contact Last Name&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td width="2%" align="center">
                                                                :
                                                            </td>
                                                            <td width="30%" align="left">
                                                                <asp:TextBox ID="txtContactLastName" Width="200px" runat="server" MaxLength="50"
                                                                    TabIndex="8"></asp:TextBox>
                                                                <%--<asp:RequiredFieldValidator ID="rfvContact" runat="server" ValidationGroup="vsErrorGroup"
                                                                    ErrorMessage="Please Enter [Producers]/Contact Last Name" ControlToValidate="txtContactLastName"
                                                                    Display="None" SetFocusOnError="true" />--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Address 1&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtAddress1" Width="200px" runat="server" MaxLength="50" TabIndex="2"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Contact First Name&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtContactFirstName" Width="200px" runat="server" MaxLength="50"
                                                                    TabIndex="9"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Address 2&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtAddress2" Width="200px" runat="server" MaxLength="50" TabIndex="3"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Contact Title&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtContactTitle" Width="200px" runat="server" MaxLength="50" TabIndex="10"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                City&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtCity" Width="200px" runat="server" MaxLength="50" TabIndex="4"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Contact Phone&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtContactPhone" Width="200px" runat="server" MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);"
                                                                    TabIndex="11"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="revContactPhone" runat="server" ValidationGroup="vsErrorGroup"
                                                                    ErrorMessage="Please Enter Valid [Producers]/Contact Phone" ControlToValidate="txtContactPhone"
                                                                    ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b" Display="none" SetFocusOnError="true" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                State&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="drpState" runat="server" Width="205px" SkinID="Default" TabIndex="5">
                                                                </asp:DropDownList>
                                                                <%--<asp:RequiredFieldValidator ID="rfvState" runat="server" ValidationGroup="vsErrorGroup"
                                                                    ErrorMessage="Please Select [Producers]/State" ControlToValidate="drpState" InitialValue="--Select--"
                                                                    Display="None" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Contact Fax&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtContactFax" Width="200px" runat="server" MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);"
                                                                    TabIndex="12"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="revContactFax" runat="server" ValidationGroup="vsErrorGroup"
                                                                    ErrorMessage="Please Enter Valid [Producers]/Contact Fax" ControlToValidate="txtContactFax"
                                                                    ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b" Display="None" SetFocusOnError="true" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Zip Code&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtZipCode" Width="200px" runat="server" MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);"
                                                                    TabIndex="6"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="revZipCode" runat="server" ValidationGroup="vsErrorGroup"
                                                                    ErrorMessage="Please Enter Valid [Producers]/Zip Code" ControlToValidate="txtZipCode"
                                                                    ValidationExpression="\b[0-9]{5}-[0-9]{4}\b|\b[0-9]{5}\b" Display="none" SetFocusOnError="true" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Contact E-Mail&nbsp;<span id="Span12" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtContactEmail" Width="200px" runat="server" MaxLength="254" TabIndex="13"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ValidationGroup="vsErrorGroup"
                                                                    ErrorMessage="Please Enter Valid [Producers]/ Contact E-Mail" ControlToValidate="txtContactEmail"
                                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="None"
                                                                    SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                Notes&nbsp;<span id="Span13" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" colspan="5" valign="top">
                                                                <uc:ctrlNotes ID="txtNotes" runat="server" TabIndex="14" Width="600" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 15px;" class="Spacer" colspan="7">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="Div1" runat="server" style="display: none;">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td width="100%">
                                                <uc:ctrlAttachment ID="Attachment" runat="Server" ShowAttachmentType="true" ShowAttachmentButton="true"
                                                    OnbtnHandler="Attachment_btnHandler" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Spacer" style="height: 10px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Spacer" style="height: 60px;">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="dvView" runat="server" style="display: none;">
                                    <asp:Panel ID="Panel2" runat="server" Style="display: block; height: 100%">
                                        <div class="bandHeaderRow">
                                            Producers</div>
                                        <table cellpadding="3" cellspacing="1" width="100%">
                                            <tr>
                                                <td width="20%" align="left" valign="top">
                                                    Company
                                                </td>
                                                <td width="2%" align="center" valign="top">
                                                    :
                                                </td>
                                                <td width="26%" align="left" valign="top">
                                                    <asp:Label ID="lblCompany" runat="server"></asp:Label>
                                                </td>
                                                <td width="2%" valign="top">
                                                    &nbsp;
                                                </td>
                                                <td align="left" valign="top" width="20%">
                                                    Contact Last Name
                                                </td>
                                                <td width="2%" align="center" valign="top">
                                                    :
                                                </td>
                                                <td width="26%" align="left" valign="top">
                                                    <asp:Label ID="lblContactLastName" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    Address 1
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblAddress1" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    Contact First Name
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblContactFirstName" runat="server"></asp:Label>
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
                                                    <asp:Label ID="lblAddress2" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    Contact Title
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblContactTitle" runat="server"></asp:Label>
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
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    Contact Phone
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblContactPhone" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    State
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblState" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    Contact Fax
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblContactFax" runat="server"></asp:Label>
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
                                                    <asp:Label ID="lblZipCode" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    Contact E-Mail
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblContactEmail" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">
                                                    Notes
                                                </td>
                                                <td align="center" valign="top">
                                                    :
                                                </td>
                                                <td align="left" colspan="5" valign="top">
                                                    <uc:ctrlNotes ID="lblNotes" runat="server" ControlType="Label" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 5px;" colspan="7" class="Spacer">
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </div>
                                <asp:Panel ID="dvAttachment" runat="server" Style="display: none;">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td width="100%">
                                                <uc:ctrlAttachmentDetails ID="AttachDetails" runat="Server" ShowReplaceColumn="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Spacer" style="height: 100px;">
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 15px;">
                </td>
                <td style="width: 5px;" class="Spacer">
                    &nbsp;
                </td>
                <td class="Spacer" style="height: 15px;">
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 25px;">
                </td>
                <td style="width: 5px;" class="Spacer">
                    &nbsp;
                </td>
                <td align="center">
                    <asp:Button ID="btnSave" runat="server" SkinID="SaveAndView" CausesValidation="true"
                        TabIndex="15" OnClick="btnSave_Click" OnClientClick="return CheckForValidation();" />&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnReturn" runat="server" SkinID="Revert&Return" CausesValidation="false"
                        TabIndex="16" OnClick="btnReturn_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnBack" runat="server" SkinID="Back" CausesValidation="false" OnClick="btnBack_Click" />
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 15px;">
                </td>
                <td style="width: 5px;" class="Spacer">
                    &nbsp;
                </td>
                <td class="Spacer" style="height: 15px;">
                </td>
            </tr>
        </table>
    </div>
    <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsErrorGroup" />
    <input id="hdnControlIDs" runat="server" type="hidden" />
    <input id="hdnErrorMsgs" runat="server" type="hidden" />
</asp:Content>
