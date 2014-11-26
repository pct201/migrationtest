<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="Compliance_Reporting_Paint_Inventory.aspx.cs" Inherits="SONIC_Pollution_Compliance_Reporting_Paint_Inventory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/NotesWithSpellCheck/Notes.ascx" TagName="ctrlMultiLineTextBox"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_Pollution/Attachment_Pollution.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_Pollution/AttachmentDetails_Pollution.ascx"
    TagName="ctrlAttachmentDetails" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposureInfo/EnviroExposureInfo.ascx" TagName="ctrlExposureInfo"
    TagPrefix="uc" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="server">
    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript">
        function returnConfirm() {
            return confirm('Are you sure you want to remove the selected data from eRIMS2?');
        }
        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 2; i++) {
                var tb = document.getElementById("Menu" + i);
                if (i == index) {
                    tb.className = "LeftMenuSelected";
                    tb.onmouseover = function () { this.className = 'LeftMenuSelected'; }
                    tb.onmouseout = function () { this.className = 'LeftMenuSelected'; }
                }
                else {
                    tb.className = "LeftMenuStatic";
                    tb.onmouseover = function () { this.className = 'LeftMenuHover'; }
                    tb.onmouseout = function () { this.className = 'LeftMenuStatic'; }
                }
            }
        }

        function ShowPanel(index) {

            SetMenuStyle(index);
            ActiveTabIndex = index;
            var op = '<%=StrOperation%>';
            if (op == "view") {
                ShowPanelView(index);
            }
            else {
                var i;
                if (index < 3) {
                    for (i = 1; i <= 2; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = (i == index) ? "block" : "none";
                    }
                    if (index == 1)
                        document.getElementById('<%=drpFK_LU_Paint_Type.ClientID %>').focus();
                }
                else {
                    for (i = 1; i <= 2; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = "none";
                    }
                }
            }
        }

        function ShowPanelView(index) {
            SetMenuStyle(index);
            document.getElementById('<%=dvView.ClientID%>').style.display = "block";
            var i;
            if (index < 3) {
                for (i = 1; i <= 2; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "View").style.display = (i == index) ? "block" : "none";
                }
            }
            else {
                for (i = 1; i <= 2; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "View").style.display = "none";
                }
            }
        }

        function ValSave() {
            //            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled = false;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = false;
            //            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = false;
            if (Page_ClientValidate('vsErrorGroup'))
                return true;
            else
                return false;
        }

        function ValAttach() {
            //            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled = true;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = true;
            //            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = true;
            if (Page_ClientValidate('vsErrorGroup'))
                return true;
            else
                return false;
        }
        function OpenAuditPopUp() {
            var winHeight = window.screen.availHeight - 400;
            var winWidth = window.screen.availWidth - 500;

            obj = window.open('AuditPopup_PM_Paint_Inventory.aspx?id=<%=ViewState["PK_PM_CR_Paint_Inventory"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
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
                    //if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
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
    <asp:ValidationSummary ID="valSummary" runat="server" ValidationGroup="vsErrorGroup"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following fields:"
        BorderWidth="1" BorderColor="DimGray" CssClass="errormessage" />
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" style="height: 50px;" valign="bottom">
                <uc:CtlTab runat="server" ID="Tab"></uc:CtlTab>
            </td>
        </tr>
        <tr>
            <td class="Spacer" width="100%" style="height: 15px;">
            </td>
        </tr>
        <tr>
            <td width="100%">
                <uc:ctrlExposureInfo ID="ucCtrlExposureInfo" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="ghc" align="left">
                Compliance Reporting - Paint Inventory
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="leftMenu">
                            <table cellpadding="5" cellspacing="0" width="100%">
                                <tr>
                                    <td style="height: 18px;" class="Spacer">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">Paint Inventory</span>&nbsp;<span
                                           id="MenuAsterisk1" runat="server" style="color: Red;display:none">*</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu2" onclick="javascript:ShowPanel(2);" class="LeftMenuStatic">Attachment</span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td width="5px" class="Spacer">
                                        &nbsp;
                                    </td>
                                    <td class="dvContainer">
                                        <div id="dvEdit" runat="server" width="794px">
                                            <asp:Panel ID="pnl1" runat="server" Style="display: inline;">
                                                <div class="bandHeaderRow">
                                                    Paint Inventory</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Paint Type&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="drpFK_LU_Paint_Type" Width="175px" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>                                                            
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            CAS Number&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtCAS_Number" runat="server" Width="170px" MaxLength="25" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Pure/Mixture?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdoPure_Mixture" runat="server">
                                                                <asp:ListItem Text="Pure" Value="P" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="Mixture" Value="M" Selected="False"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Paint Color&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtPaint_Color" runat="server" Width="170px" MaxLength="75" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            If Mixture, List Components&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtMixture_Components" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Product Identification Number&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtProduct_Identification_Number" runat="server" Width="170px" MaxLength="50" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Product Name&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtProduct_Name" runat="server" Width="170px" MaxLength="75" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Manufacturer&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtManufacturer" runat="server" Width="170px" MaxLength="75" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Synonyms&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtSynonyms" runat="server" Width="170px" MaxLength="75" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Issue Date&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtIssue_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Issue Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtIssue_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revIssue_Date" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Paint Inventory]/Issue Date is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtIssue_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Edition Number&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtEdition_Number" runat="server" Width="170px" MaxLength="75" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Chemical Family&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpFK_LU_Chemical_Family" Width="175px" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            MSDS Number&nbsp;<span id="Span12" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtMSDS_Number" runat="server" Width="170px" MaxLength="75" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Emergency Overview&nbsp;<span id="Span13" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtEmergency_Overview" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Composition Information&nbsp;<span id="Span14" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtComposition_Information" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Storage Type&nbsp;<span id="Span15" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpFK_LU_Storage_Type" Width="175px" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Storage Location&nbsp;<span id="Span16" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpFK_LU_Storage_Location" Width="175px" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <div class="bandHeaderRow">
                                                                Paint Inventory</div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Paint Inventory Grid
                                                            <br />
                                                            <asp:LinkButton ID="lbAddPaintInventory" runat="server" Text="--Add--" OnClick="lbAddPaintInventory_Click"
                                                                CausesValidation="true" ValidationGroup="vsErrorGroup"></asp:LinkButton>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:HiddenField ID="hdnPKPropertyPaintInventory" runat="server" />
                                                            <asp:GridView ID="gvPaintInventory" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                OnRowCommand="gvPaintInventory_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Supplier">
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbnSupplier" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_PM_CR_PI_Inventory") %>'
                                                                                Text='<%# Eval("Supplier") %>' Visible='<%# (Convert.ToInt32(Eval("PK_PM_CR_PI_Inventory")) > 0) %>'></asp:LinkButton>
                                                                            <asp:Label ID="lblSupplier" runat="server" Text='<%# Eval("Supplier") %>' Visible='<%# (Convert.ToInt32(Eval("PK_PM_CR_PI_Inventory")) == 0) %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date Purchased">
                                                                        <ItemStyle Width="12%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbnDate_Purchased" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_PM_CR_PI_Inventory") %>'
                                                                                Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Purchased")) %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Amount Purchased" HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Right" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbnAmount_Purchased" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_PM_CR_PI_Inventory") %>'
                                                                                Text='<%# String.Format("{0:N2}",Eval("Amount_Purchased"))%>' Visible='<%# (Convert.ToInt32(Eval("PK_PM_CR_PI_Inventory")) > 0) %>'></asp:LinkButton>
                                                                            <asp:Label ID="lblAmount_Purchased" runat="server" Text='<%# String.Format("{0:N2}",Eval("Amount_Purchased"))%>'
                                                                                Visible='<%# (Convert.ToInt32(Eval("PK_PM_CR_PI_Inventory")) == 0) %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Units">
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbnUnits" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_PM_CR_PI_Inventory") %>'
                                                                                Text='<%# Eval("FK_LU_Units") %>' Visible='<%# (Convert.ToInt32(Eval("PK_PM_CR_PI_Inventory")) > 0) %>'></asp:LinkButton>
                                                                            <asp:Label ID="lblUnits" runat="server" Text='<%# Eval("FK_LU_Units") %>' Visible='<%# (Convert.ToInt32(Eval("PK_PM_CR_PI_Inventory")) == 0) %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Amount Used" HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Right" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbnAmount_Used" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_PM_CR_PI_Inventory") %>'
                                                                                Text='<%# String.Format("{0:N2}",Eval("Amount_Used"))%>' Visible='<%# (Convert.ToInt32(Eval("PK_PM_CR_PI_Inventory")) > 0) %>'></asp:LinkButton>
                                                                            <asp:Label ID="lblAmount_Used" runat="server" Text='<%# String.Format("{0:N2}",Eval("Amount_Used"))%>'
                                                                                Visible='<%# (Convert.ToInt32(Eval("PK_PM_CR_PI_Inventory")) == 0) %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Ending Inventory" HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Right" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbnEnding_Inventory" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_PM_CR_PI_Inventory") %>'
                                                                                Text='<%# String.Format("{0:N2}",Eval("Ending_Inventory"))%>' Visible='<%# (Convert.ToInt32(Eval("PK_PM_CR_PI_Inventory")) > 0) %>'></asp:LinkButton>
                                                                            <asp:Label ID="lblEnding_Inventory" runat="server" Text='<%# String.Format("{0:N2}",Eval("Ending_Inventory"))%>'
                                                                                Visible='<%# (Convert.ToInt32(Eval("PK_PM_CR_PI_Inventory")) == 0) %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="8%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbRemove" runat="server" Text="Remove" OnClientClick="return returnConfirm();"
                                                                                CommandName="Remove" CommandArgument='<%# Eval("PK_PM_CR_PI_Inventory") %>' Visible='<%# (Convert.ToInt32(Eval("PK_PM_CR_PI_Inventory")) > 0) %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    No Record Exists</EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl2" runat="server" Style="display: inline;">
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
                                            </asp:Panel>
                                        </div>
                                        <div id="dvView" runat="server" width="794px">
                                            <asp:Panel ID="pnl1View" runat="server" Style="display: inline;">
                                                <div class="bandHeaderRow">
                                                    Paint Inventory</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Paint Type
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblFK_LU_Paint_Type" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            CAS Number
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblCAS_Number" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Pure/Mixture?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPure_Mixture" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Paint Color
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPaint_Color" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            If Mixture, List Components
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblMixture_Components" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Product Identification Number
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblProduct_Identification_Number" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Product Name
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblProduct_Name" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Manufacturer
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblManufacturer" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Synonyms
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSynonyms" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Issue Date
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblIssue_Date" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Edition Number
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblEdition_Number" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Chemical Family
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_LU_Chemical_Family" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            MSDS Number
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblMSDS_Number" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Emergency Overview
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblEmergency_Overview" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Composition Information
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblComposition_Information" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Storage Type
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_LU_Storage_Type" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Storage Location
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_LU_Storage_Location" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Paint Inventory Grid
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvPaintInventoryView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                OnRowCommand="gvPaintInventoryView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Supplier">
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbnSupplier" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_PM_CR_PI_Inventory") %>'
                                                                                Text='<%# Eval("Supplier") %>' Visible='<%# (Convert.ToInt32(Eval("PK_PM_CR_PI_Inventory")) > 0) %>'></asp:LinkButton>
                                                                            <asp:Label ID="lblSupplierview" runat="server" Text='<%# Eval("Supplier") %>' Visible='<%# (Convert.ToInt32(Eval("PK_PM_CR_PI_Inventory")) == 0) %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date Purchased">
                                                                        <ItemStyle Width="12%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbnDate_Purchased" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_PM_CR_PI_Inventory") %>'
                                                                                Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Purchased")) %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Amount Purchased" HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Right" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbnAmount_Purchased" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_PM_CR_PI_Inventory") %>'
                                                                                Text='<%# String.Format("{0:N2}",Eval("Amount_Purchased"))%>' Visible='<%# (Convert.ToInt32(Eval("PK_PM_CR_PI_Inventory")) > 0) %>'></asp:LinkButton>
                                                                            <asp:Label ID="lblAmount_Purchased" runat="server" Text='<%# String.Format("{0:N2}",Eval("Amount_Purchased"))%>'
                                                                                Visible='<%# (Convert.ToInt32(Eval("PK_PM_CR_PI_Inventory")) == 0) %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Units">
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbnUnits" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_PM_CR_PI_Inventory") %>'
                                                                                Text='<%# Eval("FK_LU_Units") %>' Visible='<%# (Convert.ToInt32(Eval("PK_PM_CR_PI_Inventory")) > 0) %>'></asp:LinkButton>
                                                                            <asp:Label ID="lblUnits" runat="server" Text='<%# Eval("FK_LU_Units") %>' Visible='<%# (Convert.ToInt32(Eval("PK_PM_CR_PI_Inventory")) == 0) %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Amount Used" HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Right" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbnAmount_Used" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_PM_CR_PI_Inventory") %>'
                                                                                Text='<%# String.Format("{0:N2}",Eval("Amount_Used"))%>' Visible='<%# (Convert.ToInt32(Eval("PK_PM_CR_PI_Inventory")) > 0) %>'></asp:LinkButton>
                                                                            <asp:Label ID="lblAmount_Used" runat="server" Text='<%# String.Format("{0:N2}",Eval("Amount_Used"))%>'
                                                                                Visible='<%# (Convert.ToInt32(Eval("PK_PM_CR_PI_Inventory")) == 0) %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Ending Inventory" HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Right" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbnEnding_Inventory" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_PM_CR_PI_Inventory") %>'
                                                                                Text='<%# String.Format("{0:N2}",Eval("Ending_Inventory"))%>' Visible='<%# (Convert.ToInt32(Eval("PK_PM_CR_PI_Inventory")) > 0) %>'></asp:LinkButton>
                                                                            <asp:Label ID="lblEnding_Inventory" runat="server" Text='<%# String.Format("{0:N2}",Eval("Ending_Inventory"))%>'
                                                                                Visible='<%# (Convert.ToInt32(Eval("PK_PM_CR_PI_Inventory")) == 0) %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    No Record Exists</EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl2View" runat="server" Style="display: inline;">
                                                <div id="Div1" runat="server" style="display: inline;">
                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td width="100%">
                                                                <uc:ctrlAttachmentDetails ID="AttachDetailsView" runat="Server" />
                                                            </td>
                                                        </tr>
                                                        <%--<tr>
													<td class="Spacer" style="height: 150px;"></td>
												</tr>--%>
                                                    </table>
                                                </div>
                                            </asp:Panel>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td align="center">
                            <div id="dvSave" runat="server">
                                <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td width="60%" align="right">
                                            <asp:Button ID="btnSave" runat="server" Text="Save & View" OnClick="btnSave_Click"
                                                CausesValidation="true" ValidationGroup="vsErrorGroup" OnClientClick="return ValSave();" />
                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
                                            <asp:Button runat="server" ID="btnAuditTrail" Text="View Audit Trail" CausesValidation="false"
                                                Visible="true" OnClientClick="javascript:return OpenAuditPopUp();" />
                                            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
                                        </td>
                                        <td align="left">
                                            &nbsp;
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
    <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
                    Display="None" ValidationGroup="vsErrorGroup" />
                <input id="hdnControlIDs" runat="server" type="hidden" />
                <input id="hdnErrorMsgs" runat="server" type="hidden" />
</asp:Content>
