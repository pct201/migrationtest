<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="PurchasingAssetInformation.aspx.cs"
    Inherits="SONIC_Purchasing_PurchasingAssetInformation" Title="eRIMS Sonic :: Purchasing :: Asset" %>

<%@ Register Src="../../Controls/SONIC_Purchasing/PurchasingAsset.ascx" TagName="PurchasingAsset"
    TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Attachment-ExecutiveRisk/Attachment.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment-ExecutiveRisk/AttachmentDetails.ascx" TagName="ctrlAttachmentDetails"
    TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery.maskedinput.js"></script>
    <script language="javascript" type="text/javascript">
        //Open Audit Popup
        function AssestInfoAuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("AuditPopup_PurchasingAssetInformation.aspx?id=" + '<%=ViewState["PK_Purchasing_Asset"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }
        function CheckNumericVal(Ctl) {
            if (Ctl.value == "" || isNaN(Number(Ctl.value.replace(/,/g, '')) * 1) == true)
                Ctl.innerText = 0;
        }
        
        var ActiveTabIndex = 1;
        function onNextStep() {
            if (ActiveTabIndex == 3) {
                var op = '<%=strOperation%>';
                document.getElementById("ctl00_ContentPlaceHolder1_btnNextStep").style.display = "block";
                if (op == "view") {
                    ActiveTabIndex = 1;
                    ShowPanel(ActiveTabIndex);
                    return false;
                }
                else {
                    return ValSave();
                }
            }
            else {
                ActiveTabIndex = ActiveTabIndex + 1;
                ShowPanel(ActiveTabIndex);
                if (ActiveTabIndex == 3) {
                    document.getElementById("ctl00_ContentPlaceHolder1_btnNextStep").style.display = "none";
                }
                else {
                    document.getElementById("ctl00_ContentPlaceHolder1_btnNextStep").style.display = "block";
                }
                return false;
            }
        }


        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 3; i++) {
                var tb = document.getElementById("PAMenu" + i);
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
        //used to display panel as per passed index number.
        function ShowPanel(index) {

            SetMenuStyle(index);
            ActiveTabIndex = index;
            var op = '<%=strOperation%>';
            //check page mode. if Mode is View than page open in View mode else open in edit mode
            if (op == "view") {
                document.getElementById("<%=dvSave.ClientID %>").style.display = "none";
                document.getElementById("<%=pnlAttachmentDetailView.ClientID%>").style.display = "block";
                ShowPanelView(index);
            }
            else {
                document.getElementById("<%=dvView.ClientID%>").style.display = "none";
                if (index == 1) {
                    document.getElementById("<%=pnlAsset.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlAsset_Notes.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlAsset_Attachment.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlAttachmentDetailView.ClientID%>").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_btnNextStep").style.display = "block";
                }
                if (index == 2) {
                    document.getElementById("<%=pnlAsset.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlAsset_Notes.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlAsset_Attachment.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlAttachmentDetailView.ClientID%>").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_btnNextStep").style.display = "block";
                }
                if (index == 3) {
                    document.getElementById("<%=pnlAsset.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlAsset_Notes.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlAsset_Attachment.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlAttachmentDetailView.ClientID%>").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_btnNextStep").style.display = "none";
                }
            }
        }
        ///Used to open page in View mode.
        function ShowPanelView(index) {

            SetMenuStyle(index);
            //used to check index value. and accorind to answer Panel is displayed.
            if (index == 1) {
                document.getElementById("<%=pnlAssetView.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlAssetNotes.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachmentDetailView.ClientID%>").style.display = "none";
            }
            if (index == 2) {
                document.getElementById("<%=pnlAssetView.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAssetNotes.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlAttachmentDetailView.ClientID%>").style.display = "none";
            }
            if (index == 3) {
                document.getElementById("<%=pnlAssetView.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAssetNotes.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachmentDetailView.ClientID%>").style.display = "block";

            }
        }
        function OpenEntityPopUp() {
            var txtID = '<%=txtFK_LU_Manufacturer.ClientID%>';
            var hdnEntity = '<%=hdnFK_LU_Manufacturer.ClientID%>';
            ShowDialog("<%=AppConfig.SiteURL%>/SONIC/Purchasing/ManufacturerPopupWinodow.aspx?txtID=" + txtID);
            return false;

        }

        function ValSave() {
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled = false;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = false;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = false;
            if (Page_ClientValidate('vsErrorGroup'))
                return true;
            else
                return false;
        }
        function RedirectTo(index) {
            if (index == 1)
                window.location.href = '<%=AppConfig.SiteURL%>SONIC/Purchasing/PurchasingSearch.aspx';
        }

        function ValAttach() {
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled = true;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = true;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = true;
            if (Page_ClientValidate("vsErrorGroup"))
                return true;
            else
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
                        case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
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

        jQuery(function ($) {
            $("#<%=txtPur_Asset_Note_Date.ClientID%>").mask("99/99/9999");
        });

    </script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" valign="bottom" colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="100%" valign="bottom" colspan="2">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td id="tab1" class="tab" onclick="RedirectTo(1)">
                            Search
                        </td>
                        <td id="tab2" class="tabSelected">
                            Purchasing
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc1:PurchasingAsset ID="PurchasingAssetTab" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 15px;" colspan="2">
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td class="leftMenu">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="height: 18px;" class="Spacer">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%">
                                        <asp:Menu ID="mnuPurchasingAsset" runat="server" DataSourceID="dsPurchasingAssetInfoMenu"
                                            StaticEnableDefaultPopOutImage="false">
                                            <StaticItemTemplate>
                                                <table cellpadding="5" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="100%">
                                                            <span id="PAMenu<%#Container.ItemIndex+1%>" onclick="javascript:ShowPanel(<%#Container.ItemIndex+1%>);"
                                                                class="LeftMenuStatic">
                                                                <%#Eval("Text")%>&nbsp;
                                                                 <asp:Label ID="MenuAsterisk" runat="server" Text="*" style="color: Red;display:none"  ></asp:Label> 
                                                            </span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </StaticItemTemplate>
                                        </asp:Menu>
                                        <asp:SiteMapDataSource ID="dsPurchasingAssetInfoMenu" runat="server" SiteMapProvider="PurchasingAssetInformationMenuProvider"
                                            ShowStartingNode="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 5px;" class="Spacer">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblSubmitMessage" SkinID="lblError"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td width="5px">
                                        &nbsp;
                                    </td>
                                    <td width="794px" valign="top" class="dvContainer">
                                        <div id="dvEdit" runat="server" style="width: 100%;">
                                            <asp:Panel ID="pnlAsset" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Asset</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" style="width: 18%;">
                                                            Type&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" style="width: 4%;">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 22%;">
                                                            <asp:TextBox runat="server" ID="txtType" MaxLength="75"> </asp:TextBox>
                                                            <%--<asp:RequiredFieldValidator ID="rfvType" runat="server" ControlToValidate="txtType"
                                                                Display="none" ErrorMessage="Please Enter Type" SetFocusOnError="true" ValidationGroup="vsErrorGroup" />--%>
                                                        </td>
                                                        <td align="left" style="width: 18%;">
                                                            Manufacturer&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" style="width: 4%;">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 22%;">
                                                            <asp:TextBox runat="server" ID="txtFK_LU_Manufacturer" MaxLength="75" ReadOnly="true"> </asp:TextBox>
                                                            <asp:HiddenField ID="hdnFK_LU_Manufacturer" runat="server" />
                                                            <asp:Button ID="btnEntityPopUp" runat="server" Text="V" OnClientClick="javascript:return OpenEntityPopUp();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Dealership Department&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList runat="server" ID="ddlFK_LU_Dealership_Department">
                                                            </asp:DropDownList>
                                                            <%--<asp:RequiredFieldValidator ID="rfvContractLevel" runat="server" ControlToValidate="ddlFK_LU_Dealership_Department"
                                                                Display="none" ErrorMessage="Please Select Dealership Department" InitialValue="0"
                                                                SetFocusOnError="true" ValidationGroup="vsErrorGroup" />--%>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Serial Number&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtSerial_Number" runat="server" MaxLength="50">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td align="left">
                                                            Model Number&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtModel_Number" runat="server" MaxLength="50">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Supplier&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtSupplier" runat="server" MaxLength="75">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td align="left">
                                                            Acquisition Date&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox runat="server" ID="txtAcquisition_Date" SkinID="txtDate"></asp:TextBox>
                                                            <img alt="Date Opened" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtAcquisition_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                            <asp:RangeValidator ID="revDate" ControlToValidate="txtAcquisition_Date" MinimumValue="01/01/1753"
                                                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Acquisition Date is not valid."
                                                                runat="server" SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Useful Life in Months&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtUseful_Life" runat="server" MaxLength="5" onKeyPress="javascript:return FormatInteger(event);">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td align="left">
                                                            Acquisition Cost&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            $
                                                            <asp:TextBox ID="txtAcquisition_Cost" runat="server" MaxLength="16" onpaste="return false"
                                                                onkeypress="return currencyFormat(this,',','.',event);" OnBlur="CheckNumericVal(this);"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Location&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:DropDownList runat="server" ID="ddlFK_LU_Location" Width="100%">
                                                            </asp:DropDownList>
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlFK_LU_Location"
                                                                Display="none" ErrorMessage="Please Select Location" InitialValue="0" SetFocusOnError="true"
                                                                ValidationGroup="vsErrorGroup" />--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Notes&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlMultiLineTextBox runat="server" ControlType="textbox" ID="txtNotes" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Service Contract Grid
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:GridView ID="grvService" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                OnRowCommand="gvServiceContact_RowCommand" EmptyDataText="No Service Contact Exists."
                                                                PageSize="3" ViewState="true" AllowPaging="true" OnPageIndexChanging="gvServiceContact_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Supplier">
                                                                        <ItemStyle Width="20%" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkSupplier" runat="server" Text='<%#Eval("Supplier")%>' CommandName="ViewService"
                                                                                CommandArgument='<%#Eval("PK_Purchasing_Service_Contract")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Service Type">
                                                                        <ItemStyle Width="18%" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkServicetype" runat="server" Text='<%#Eval("Service_Type")%>'
                                                                                CommandName="ViewService" CommandArgument='<%#Eval("PK_Purchasing_Service_Contract")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Start Date">
                                                                        <ItemStyle Width="12%" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkStartdate" runat="server" CommandArgument='<%#Eval("PK_Purchasing_Service_Contract")%>'
                                                                                CommandName="ViewService" Text='<%# Convert.ToDateTime(Eval("Start_Date")).ToString("MMM-dd-yyyy")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="End Date">
                                                                        <ItemStyle Width="12%" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkEnddate" runat="server" CommandArgument='<%#Eval("PK_Purchasing_Service_Contract")%>'
                                                                                CommandName="ViewService" Text='<%# Convert.ToDateTime(Eval("End_Date")).ToString("MMM-dd-yyyy")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Lease/Rental Agreement
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:GridView ID="gvLRAgreement" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                OnRowCommand="gvLRAgreement_RowCommand" EmptyDataText="No Lease/Rental Agreement Exists."
                                                                PageSize="3" ViewState="true" AllowPaging="true" OnPageIndexChanging="gvLRAgreement_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Supplier">
                                                                        <ItemStyle Width="20%" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkSupplier" runat="server" Text='<%#Eval("Supplier")%>' CommandName="ViewLR"
                                                                                CommandArgument='<%#Eval("PK_Purchasing_LR_Agreement")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Equipment Type">
                                                                        <ItemStyle Width="18%" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkServicetype" runat="server" Text='<%#Eval("Fld_Desc")%>' CommandName="ViewLR"
                                                                                CommandArgument='<%#Eval("PK_Purchasing_LR_Agreement")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Start Date">
                                                                        <ItemStyle Width="12%" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkStartdate" runat="server" CommandArgument='<%#Eval("PK_Purchasing_LR_Agreement")%>'
                                                                                CommandName="ViewLR" Text='<%# Convert.ToDateTime(Eval("Start_Date")).ToString("MMM-dd-yyyy")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="End Date">
                                                                        <ItemStyle Width="12%" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkEnddate" runat="server" CommandArgument='<%#Eval("PK_Purchasing_LR_Agreement")%>'
                                                                                CommandName="ViewLR" Text='<%# Convert.ToDateTime(Eval("End_Date")).ToString("MMM-dd-yyyy")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="center">
                                                            <asp:Button runat="server" ID="btnAssetInfoAudit" Text="View Audit Trail" OnClientClick="javascript:return AssestInfoAuditPopUp();"
                                                                ToolTip="View Audit Trail" CausesValidation="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlAsset_Notes" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Asset-Notes Grid</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top" style="width: 18%;">
                                                            Notes Grid
                                                            <br />
                                                            <asp:LinkButton ID="lblAddNotes" runat="server" Text="--Add--" OnClick="lblAddNotes_Click"
                                                                ValidationGroup="vsErrorGroup" CausesValidation="true">
                                                            </asp:LinkButton>
                                                        </td>
                                                        <td align="center" valign="top" style="width: 4%;">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:GridView ID="gvPurchaseNotes" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                OnRowCommand="gvPurchaseNotes_RowCommand" EmptyDataText="No Asset Note Exists.">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Date of Notes(s)">
                                                                        <ItemStyle Width="20%" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkDate" runat="server" Text='<%# Convert.ToDateTime(Eval("Note_Date")).ToString("MMM-dd-yyyy")%>'
                                                                                CommandName="ViewNote" CommandArgument='<%#Eval("PK_Purchasing_Asset_Notes")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Note Text Snippet">
                                                                        <ItemStyle Width="70%" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkSubject" CssClass="TextClip" Width="400px" runat="server"
                                                                                Text='<%#Eval("Note")%>' CommandName="ViewNote" CommandArgument='<%#Eval("PK_Purchasing_Asset_Notes")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="10%" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" CommandArgument='<%#Eval("PK_Purchasing_Asset_Notes")%>'
                                                                                CommandName="RemoveNote" Text="Remove" OnClientClick="return confirm('Are you sure to delete?');" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%" style="display: none;"
                                                    id="tblAssetNote">
                                                    <tr align="left" style="width: 100%" id="trAssestNoteEdit">
                                                        <td>
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" style="width: 18%;">
                                                                        Note Date
                                                                    </td>
                                                                    <td align="center" style="width: 4%;">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox runat="server" ID="txtPur_Asset_Note_Date"> </asp:TextBox>
                                                                        <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPur_Asset_Note_Date', 'mm/dd/y');"
                                                                            alt="Incident Date" src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                         <asp:RegularExpressionValidator ID="revtxtPur_Asset_Note_Date" runat="server" 
                                                                         ControlToValidate="txtPur_Asset_Note_Date" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"                                                                   
                                                                         ErrorMessage="Date Not Valid(Note Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                  
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Note
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <uc:ctrlMultiLineTextBox runat="server" ControlType="textbox" ID="txtPur_Asset_Note" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr align="left" style="width: 100%" id="trAssestNoteView">
                                                        <td>
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td colspan="3" align="center">
                                                                        <asp:Button runat="server" ID="btnNotesSave" Text="Save" OnClick="btnNotesSave_Click" />
                                                                        <asp:Button runat="server" ID="btnBackfrom" Text="Cancel" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlAsset_Attachment" runat="server" Width="100%">
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="100%">
                                                            <uc:ctrlAttachment ID="Attachment" EnableValidationSummary="true" runat="Server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Spacer" style="height: 20px;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Spacer" style="height: 20px;" colspan="2">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <%--<asp:Panel ID="pnlAttachmentDetails" runat="server" Style="display: none;">
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="100%">
                                                           <uc:ctrlAttachmentDetails ID="AttachDetails" runat="Server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Spacer" style="height: 150px;">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>--%>
                                        </div>
                                        <div id="dvView" runat="server" style="width: 100%;">
                                            <asp:Panel ID="pnlAssetView" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Asset</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr valign="top">
                                                        <td align="left" style="width: 18%;" valign="top">
                                                            Type
                                                        </td>
                                                        <td align="center" style="width: 4%;" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 22%;" valign="top">
                                                            <asp:Label runat="server" ID="lblType"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%;" valign="top">
                                                            Manufacturer
                                                        </td>
                                                        <td align="center" style="width: 4%;" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 22%;" valign="top">
                                                            <asp:Label runat="server" ID="lblFK_LU_Manufacturer"> </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr valign="top">
                                                        <td align="left" valign="top">
                                                            Dealership Department
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label runat="server" ID="lblFK_LU_Dealership_Department"> </asp:Label>
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
                                                    <tr valign="top">
                                                        <td align="left" valign="top">
                                                            Serial Number
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSerial_Number" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Model Number
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblModel_Number" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr valign="top">
                                                        <td align="left" valign="top">
                                                            Supplier
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSupplier" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Acquisition Date
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblAcquisition_Date" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr valign="top">
                                                        <td align="left" valign="top">
                                                            Useful Life
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblUseful_Life" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Acquisition Cost
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            $
                                                            <asp:Label ID="lblAcquisition_Cost" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr valign="top">
                                                        <td align="left" valign="top">
                                                            Location
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <asp:Label ID="lbllocation" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr valign="top">
                                                        <td align="left" valign="top">
                                                            Notes
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox runat="server" ControlType="label" ID="lblNotes" />
                                                        </td>
                                                    </tr>
                                                    <tr valign="top">
                                                        <td align="left" valign="top">
                                                            Service Contract Grid
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <asp:GridView ID="gvServiceContact" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                OnRowCommand="gvServiceContact_RowCommand" EmptyDataText="No Service Contact Exists."
                                                                PageSize="3" AllowPaging="true" OnPageIndexChanging="gvServiceContact_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Supplier">
                                                                        <ItemStyle Width="20%" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkSupplier" runat="server" Text='<%#Eval("Supplier")%>' CommandName="ViewService"
                                                                                CommandArgument='<%#Eval("PK_Purchasing_Service_Contract")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Service Type">
                                                                        <ItemStyle Width="18%" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkServicetype" runat="server" Text='<%#Eval("Service_Type")%>'
                                                                                CommandName="ViewService" CommandArgument='<%#Eval("PK_Purchasing_Service_Contract")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Start Date">
                                                                        <ItemStyle Width="12%" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkStartdate" runat="server" CommandArgument='<%#Eval("PK_Purchasing_Service_Contract")%>'
                                                                                CommandName="ViewService" Text='<%# Convert.ToDateTime(Eval("Start_Date")).ToString("MMM-dd-yyyy")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="End Date">
                                                                        <ItemStyle Width="12%" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkEnddate" runat="server" CommandArgument='<%#Eval("PK_Purchasing_Service_Contract")%>'
                                                                                CommandName="ViewService" Text='<%# Convert.ToDateTime(Eval("End_Date")).ToString("MMM-dd-yyyy")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr valign="top">
                                                        <td align="left" valign="top">
                                                            Lease/Rental Agreement
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <asp:GridView ID="gvLRAgreementView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                OnRowCommand="gvLRAgreement_RowCommand" EmptyDataText="No Lease/Rental Agreement Exists."
                                                                PageSize="3" ViewState="true" AllowPaging="true" OnPageIndexChanging="gvLRAgreement_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Supplier">
                                                                        <ItemStyle Width="20%" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkSupplier" runat="server" Text='<%#Eval("Supplier")%>' CommandName="ViewLR"
                                                                                CommandArgument='<%#Eval("PK_Purchasing_LR_Agreement")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Equipment Type">
                                                                        <ItemStyle Width="18%" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkServicetype" runat="server" Text='<%#Eval("Fld_Desc")%>' CommandName="ViewLR"
                                                                                CommandArgument='<%#Eval("PK_Purchasing_LR_Agreement")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Start Date">
                                                                        <ItemStyle Width="12%" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkStartdate" runat="server" CommandArgument='<%#Eval("PK_Purchasing_LR_Agreement")%>'
                                                                                CommandName="ViewLR" Text='<%# Convert.ToDateTime(Eval("Start_Date")).ToString("MMM-dd-yyyy")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="End Date">
                                                                        <ItemStyle Width="12%" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkEnddate" runat="server" CommandArgument='<%#Eval("PK_Purchasing_LR_Agreement")%>'
                                                                                CommandName="ViewLR" Text='<%# Convert.ToDateTime(Eval("End_Date")).ToString("MMM-dd-yyyy")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="center">
                                                            <asp:Button runat="server" ID="btnAssetInfoAudit_View" Text="View Audit Trail" OnClientClick="javascript:return AssestInfoAuditPopUp();"
                                                                ToolTip="View Audit Trail" CausesValidation="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlAssetNotes" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Asset - Notes</div>
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td style="width: 100%">
                                                            <asp:GridView ID="gvPurchaseNotesView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                OnRowCommand="gvPurchaseNotes_RowCommand" EmptyDataText="No Asset Note Exists.">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Date of Notes(s)">
                                                                        <ItemStyle Width="20%" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkDate" runat="server" Text='<%# Convert.ToDateTime(Eval("Note_Date")).ToString("MMM-dd-yyyy")%>'
                                                                                CommandName="ViewNote" CommandArgument='<%#Eval("PK_Purchasing_Asset_Notes")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Note Text Snippet">
                                                                        <ItemStyle Width="70%" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkSubject" runat="server" CssClass="TextClip" Width="600px"
                                                                                Text='<%#Eval("Note")%>' CommandName="ViewNote" CommandArgument='<%#Eval("PK_Purchasing_Asset_Notes")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="10%" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" CommandArgument='<%#Eval("PK_Purchasing_Asset_Notes")%>'
                                                                                CommandName="RemoveNote" Text="Remove" OnClientClick="return confirm('Are you sure to delete?');" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%" style="display: none;"
                                                    id="Table1">
                                                    <tr align="left" style="width: 100%" id="tr1">
                                                        <td>
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" style="width: 18%;">
                                                                        Note Date
                                                                    </td>
                                                                    <td align="center" style="width: 4%;">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label runat="server" ID="lblNotedate"> </asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Note
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <uc:ctrlMultiLineTextBox runat="server" ControlType="textbox" ID="CtrlMultiLineTextBox1" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr align="left" style="width: 100%" id="tr2">
                                                        <td>
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td colspan="3" align="center">
                                                                        <asp:Button runat="server" ID="Button2" Text="Back" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                        <asp:Panel ID="pnlAttachmentDetailView" runat="server" Width="100%">
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td width="100%">
                                                        <uc:ctrlAttachmentDetails ID="AttachDetailsView" runat="Server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="Spacer" style="height: 150px;">
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <div id="dvSave" runat="server">
                    <table cellpadding="5" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td style="width: 50%" align="right">
                                <asp:Button runat="server" ID="btnSaveAndView" Text="Save & View" OnClick="btnSaveAndView_Click"
                                    ValidationGroup="vsErrorGroup" OnClientClick="return ValSave();" CausesValidation="true" />
                            </td>
                            <td style="width: 50%" align="left">
                                <asp:Button ID="btnNextStep" runat="server" Text="Next Step" CausesValidation="true"
                                    ValidationGroup="vsErrorGroup" OnClientClick="return onNextStep();" OnClick="btnNextStep_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 10px;" colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2" width="100%" class="Spacer" style="height: 6px;">
            </td>
        </tr>
        <tr>
            <td colspan="2" width="100%" align="center">
                <asp:Button ID="btnBack" runat="server" Text="Back & Edit" Visible="false" OnClick="btnBack_Click" />
                <asp:Button ID="btnNextStepView" runat="server" Text="Next Step" CausesValidation="false"
                    Visible="false" OnClientClick="return onNextStep();" OnClick="btnNextStepView_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2" width="100%" class="Spacer" style="height: 6px;">
            </td>
        </tr>
        <tr>
            <td colspan="2" class="Spacer" style="height: 25px;">
            </td>
        </tr>
    </table>
    <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsErrorGroup" />
    <input id="hdnControlIDs" runat="server" type="hidden" />
    <input id="hdnErrorMsgs" runat="server" type="hidden" />
</asp:Content>
