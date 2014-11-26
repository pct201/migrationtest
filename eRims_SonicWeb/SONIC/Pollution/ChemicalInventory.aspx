<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="ChemicalInventory.aspx.cs" Inherits="SONIC_Pollution_ComplianceReporting_ChemicalInventory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/NotesWithSpellCheck/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_Pollution/Attachment_Pollution.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_Pollution/AttachmentDetails_Pollution.ascx"
    TagName="ctrlAttachmentDetails" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposureInfo/EnviroExposureInfo.ascx" TagName="ctrlExposureInfo"
    TagPrefix="uc" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="server">
    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
    <script type="text/javascript">
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
                if (document.getElementById("ctl00_ContentPlaceHolder1_hdnVisibleAttach").value == "0") {
                    document.getElementById("Menu2").style.display = "block";
                }
                else {
                    document.getElementById("Menu2").style.display = "none";
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
            if (Page_ClientValidate("vsErrorGroup"))
                return true;
            else
                return false;
        }

        function ValAttach() {
            //            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled = true;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = true;
            //            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = true;
            if (Page_ClientValidate())
                return true;
            else
                return false;
        }
        function ConfirmDelete() {
            return confirm("Are you sure to remove the record?");
        }
        function OpenAuditPopUp() {
            var winHeight = window.screen.availHeight - 400;
            var winWidth = window.screen.availWidth - 500;

            obj = window.open('AuditPopup_PM_Chemical_Inventory.aspx?id=<%=ViewState["PK_PM_CR_Chemical_Inventory"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
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
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields :" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="vsErrorGroup"></asp:ValidationSummary>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="false"
        ShowMessageBox="true" HeaderText="Verify the following fields :" BorderWidth="1"
        BorderColor="DimGray" ValidationGroup="vsHazardGroup" CssClass="vsErrorGroup">
    </asp:ValidationSummary>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" style="height: 50px;" valign="bottom" colspan="2">
                <uc:CtlTab runat="server" ID="Tab"></uc:CtlTab>
            </td>
        </tr>
        <tr>
            <td class="Spacer" width="100%" style="height: 15px;" colspan="2">
            </td>
        </tr>
        <tr>
            <td width="100%" colspan="2">
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
                Compliance Reporting - Chemical Inventory
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
                                        <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuSelected">Chemical Inventory</span>&nbsp;<span
                                           id="MenuAsterisk1" runat="server" style="color: Red;display:none">*</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu2" onclick="javascript:ShowPanel(2);" class="LeftMenuStatic">Attachments</span>
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
                                            <asp:Panel ID="pnl1" runat="server">
                                                <asp:Panel ID="pnlDetail" runat="server">
                                                    <div class="bandHeaderRow">
                                                       Chemical Inventory</div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" width="18%" valign="top">
                                                                Chemical Type&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" width="28%" valign="top">
                                                                <asp:DropDownList ID="drpFK_LU_Chemical_Type" Width="175px" runat="server" SkinID="dropGen">
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
                                                                <asp:RadioButtonList ID="rdoPure_Mixture" runat="server" RepeatDirection="Horizontal"
                                                                    CellPadding="0" CellSpacing="0">
                                                                    <asp:ListItem Text="Pure" Value="P" Selected="True"></asp:ListItem>
                                                                    <asp:ListItem Text="Mixture" Value="M"></asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                Chemical Name&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtChemical_Name" runat="server" Width="170px" MaxLength="125" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                If Mixture, List Chemical Components&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
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
                                                                Physical State
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoPhysical_State" runat="server" RepeatDirection="Horizontal"
                                                                    CellPadding="0" CellSpacing="0">
                                                                    <asp:ListItem Text="Solid" Value="S" Selected="True"></asp:ListItem>
                                                                    <asp:ListItem Text="Liquid" Value="L"></asp:ListItem>
                                                                    <asp:ListItem Text="Gas" Value="G"></asp:ListItem>
                                                                </asp:RadioButtonList>
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
                                                                Maximum Amount On-Site In Pounds&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtMaximum_Pounds_On_Site" runat="server" Width="170px" onpaste="return false"
                                                                    onkeypress="return FormatNumber(event,this.id,15,false);" />
                                                            </td>
                                                            <td align="left" valign="top">
                                                                Daily Maximum Amount On-Site in Pounds&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtDaily_maximum_Pounds_On_Site" runat="server" Width="170px" onpaste="return false"
                                                                    onkeypress="return FormatNumber(event,this.id,15,false);" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                               Average Amount On-Site in Pounds&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtAverage_Pounds_On_Site" runat="server" Width="170px" onpaste="return false"
                                                                    onkeypress="return FormatNumber(event,this.id,15,false);" />
                                                            </td>
                                                            <td align="left" valign="top">
                                                               Daily Average Amount On-Site in Pounds&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtDaily_Average_Pounds_On_Site" runat="server" Width="170px" onpaste="return false"
                                                                    onkeypress="return FormatNumber(event,this.id,15,false);" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                Storage Type&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:DropDownList ID="drpFK_LU_Storage_Type" Width="175px" runat="server" SkinID="dropGen">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                Storage Location&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
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
                                                            <td align="left" valign="top">
                                                                State/Local Fees&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                $&nbsp;<asp:TextBox ID="txtState_Local_Fees" runat="server" Width="170px" onpaste="return false"
                                                                    onkeypress="return FormatNumber(event,this.id,15,false);" />
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
                                                            <td valign="top">
                                                                Hazards Identification Grid
                                                                <br />
                                                                <asp:LinkButton ID="lnkAddHazards" runat="server" Text="--Add--" OnClientClick="javascript:return ValSave();"
                                                                    OnClick="lnkAddHazards_Click" />
                                                            </td>
                                                            <td align="center" valign="top">
                                                                : 
                                                            </td>
                                                            <td colspan="4" valign="top">
                                                                <asp:GridView ID="gvHazards" runat="server" Width="90%" AutoGenerateColumns="false"
                                                                     EnableViewState="true" AllowPaging="true" OnRowCommand="gvHazards_RowCommand">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Type">
                                                                            <ItemStyle Width="80%" />
                                                                            <ItemTemplate>
                                                                                <%#Eval("Fld_Desc")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Remove">
                                                                            <ItemStyle Width="10%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton runat="server" ID="lnkDeleteRole" Text=" Remove " CausesValidation="false"
                                                                                    OnClientClick="return ConfirmDelete();" CommandName="DeleteRecord" CommandArgument='<%#Eval("PK_PM_CR_CI_Hazards") %>'>
                                                                                </asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        <table cellpadding="4" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                                                                    <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Exits"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                Method&nbsp;<span id="Span12" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="txtMethod" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                Description&nbsp;<span id="Span13" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" colspan="4" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="txtDescription" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <div class="bandHeaderRow">
                                                                    6H Compliance Reporting</div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                Initial Notification Submitted?
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoInitial_6H_Notification_Submitted" runat="server" SkinID="YesNoNotRequiredType">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                Compliance Verification Submitted?
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoSixH_Compliance_Verification_Submitted" runat="server"
                                                                    SkinID="YesNoNotRequiredType">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                Notification(s) of Changes Report(s) Submitted?
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoNotifications_6H_Changes_Reports_Submitted" runat="server"
                                                                    SkinID="YesNoType">
                                                                </asp:RadioButtonList>
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
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlAddHazard" runat="server" Visible="false">
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td colspan="3" valign="top">
                                                                <div class="bandHeaderRow">
                                                                    Compliance Reporting – Chemical Inventory – Hazards Identification</div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="18%" valign="top">
                                                                Hazard Type&nbsp;<span style="color: Red">*</span>
                                                            </td>
                                                            <td align="center" width="4%" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:DropDownList ID="drpHazardType" Width="400px" runat="server" SkinID="dropGen">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpHazardType"
                                                                    Display="None" ErrorMessage="Please select [Chemical Inventory]/Hazard Type" InitialValue="0" SetFocusOnError="true"
                                                                    ValidationGroup="vsHazardGroup" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" valign="top">
                                                                &nbsp;
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Button ID="btnSaveHazard" runat="server" Text="Save" OnClick="btnSaveHazard_Click"
                                                                    CausesValidation="true" ValidationGroup="vsHazardGroup" />
                                                                &nbsp;
                                                                <asp:Button ID="btnCancelHazard" runat="server" Text="Cancel" OnClick="btnCancelHazard_Click"
                                                                    CausesValidation="false" ValidationGroup="vsHazardGroup" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
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
                                            <asp:Panel ID="pnl1View" runat="server">
                                                <div class="bandHeaderRow">
                                                    Chemical Inventory</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Chemical Type
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblFK_LU_Chemical_Type" runat="server"></asp:Label>
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
                                                            Chemical Name
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblChemical_Name" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            If Mixture, List Chemical Components
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
                                                            Physical State
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPhysical_State" runat="server"></asp:Label>
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
                                                            Maximum Amount On-Site In Pounds
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblMaximum_Pounds_On_Site" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Daily Maximum Amount On-Site in Pounds
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDaily_maximum_Pounds_On_Site" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                           Average Amount On-Site in Pounds
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblAverage_Pounds_On_Site" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Daily Average Amount On-Site in Pounds
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDaily_Average_Pounds_On_Site" runat="server"></asp:Label>
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
                                                            State/Local Fees
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblState_Local_Fees" runat="server"></asp:Label>
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
                                                        <td valign="top">
                                                            Hazards Identification Grid
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" valign="top">
                                                            <asp:GridView ID="gvHazardsView" runat="server" Width="90%" AutoGenerateColumns="false"
                                                                PageSize="10" EnableViewState="true" AllowPaging="true">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Type">
                                                                        <ItemStyle Width="90%" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Fld_Desc")%>
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
                                                        <td align="left" valign="top">
                                                            Method
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblMethod" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Description
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblDescription" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Initial Notification Submitted?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblInitial_6H_Notification_Submitted" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Compliance Verification Submitted?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSixH_Compliance_Verification_Submitted" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Notification(s) of Changes Report(s) Submitted?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblNotifications_6H_Changes_Reports_Submitted" runat="server"></asp:Label>
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
                                         <asp:Button ID="btnCancelView" runat="server" Text=" Edit " CausesValidation="false"
                                                ToolTip="Edit" OnClick="btnEdit_Click" Visible="false" />
                                            <asp:Button ID="btnSave" runat="server" Text="Save & View" OnClick="btnSave_Click"
                                                CausesValidation="true" ValidationGroup="vsErrorGroup" OnClientClick="return ValSave();" />   
                                            <asp:Button runat="server" ID="btnAuditTrail" Text="View Audit Trail" CausesValidation="false"
                                                Visible="true" OnClientClick="javascript:return OpenAuditPopUp();" />
                                            <asp:Button ID="btnback" runat="server" Text="Back" OnClick="btnback_Click" CausesValidation="false" />
                                        </td>
                                        <td align="left">
                                            &nbsp;<asp:HiddenField ID="hdnVisibleAttach" runat="server" Value="0" />
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
